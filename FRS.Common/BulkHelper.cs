using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace FRS.Common
{
    public class BulkHelperDto
    {
        public bool FillIds { get; set; }
        public bool SetStateUnchanged { get; set; }
        public bool UseTempTable { get; set; }
    }

    public class BulkHelper<T> where T : class, IEntity, IHasId
    {
        public List<T> Entities { get; set; }
        public Action<T> DoneAction { get; set; }
        public BulkHelperDto Dto { get; set; }
        public DbContext Context { get; set; }

        private SqlConnection _connection
        {
            get { return (SqlConnection)Context.Database.GetDbConnection(); }
        }

        public void Insert()
        {
            Dto = Dto ?? new BulkHelperDto();

            if (Entities.Count == 0)
                return;

            Context.ChangeTracker.AutoDetectChangesEnabled = false;

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            var selectText = PerformBulk();
            UpdateProperties(selectText);

            Context.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        private string PerformBulk()
        {
            List<string> columnNames = null;
            string insertList = null;
            var destTable = typeof(T).Name;
            //var tempTable = "Temp" + destTable;
            var tempTable = "tempdb..#Temp";

            var adapter = new SqlDataAdapter($@"
IF OBJECT_ID('{tempTable}') IS NOT NULL
    DROP TABLE {tempTable}

SELECT TOP 0 *
INTO {tempTable}
FROM {destTable}

SELECT * FROM {tempTable}", _connection);
            var table = new DataTable();
            adapter.SelectCommand.Transaction = _connection.GetTransaction();
            adapter.Fill(table);

            columnNames = table.Columns.Cast<DataColumn>().Select(r => r.ColumnName).ToList();
            insertList = string.Join(",", columnNames.Where(r => r != "ID"));

            var propertyFuncs = columnNames.ToDictionary(r => r, r => CreateGetFuncFor(r));

            var rows = new List<DataRow>();
            foreach (var entity in Entities)
            {
                var row = table.NewRow();
                rows.Add(row);

                for (var i = 0; i < columnNames.Count; i++)
                {
                    row[i] = propertyFuncs[columnNames[i]](entity) ?? DBNull.Value;
                }
            }

            var bulk = new SqlBulkCopy(_connection, SqlBulkCopyOptions.Default, _connection.GetTransaction());
            bulk.DestinationTableName = Dto.FillIds ? tempTable : destTable;
            bulk.WriteToServer(rows.ToArray());

            string selectText = null;
            if (Dto.FillIds || Dto.UseTempTable)
            {
                selectText = $@"
DECLARE @id TABLE (Id int)

INSERT {destTable}({insertList})
OUTPUT INSERTED.ID INTO @id
SELECT {insertList}
FROM {tempTable}
ORDER BY ID

SELECT * FROM @id ORDER BY Id"; // Order By's are important!
            }

            return selectText;
        }

        private void UpdateProperties(string selectText)
        {
            IDataReader reader = null;
            if (selectText != null)
            {
                var command = new SqlCommand(selectText, _connection, _connection.GetTransaction()) { CommandTimeout = 0 }; // TODO Timeout ?
                reader = command.ExecuteReader();
            }

            foreach (var entity in Entities)
            {
                if (Dto.FillIds)
                {
                    reader.Read();
                    entity.Id = (int)reader[0];
                }

                if (Dto.SetStateUnchanged)
                {
                    var entry = Context.Entry(entity);
                    if (entry.State != EntityState.Unchanged && entry.State != EntityState.Detached)
                        entry.State = EntityState.Unchanged;
                }

                if (DoneAction != null)
                {
                    DoneAction(entity);
                }
            }

            if (selectText != null)
            {
                reader.Dispose();
            }
        }

        private static Func<T, object> CreateGetFuncFor(string propertyName)
        {
            //http://stackoverflow.com/questions/3989038/given-a-property-name-how-can-i-create-a-delegate-to-get-its-value

            var parameter = Expression.Parameter(typeof(T), "obj");
            var property = Expression.Property(parameter, propertyName);
            var convert = Expression.Convert(property, typeof(object));
            var lambda = Expression.Lambda(typeof(Func<T, object>), convert, parameter);

            return (Func<T, object>)lambda.Compile();
        }
    }
}
