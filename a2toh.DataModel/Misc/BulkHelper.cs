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
                    entity.ID = (int)reader[0];
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

        /*private static string InsertBulkOld<T>(DbContext context, bool fillIds, List<T> entityList) where T : class, IEntity, IHasId
        {
            List<string> columnNames = null;
            string insertList = null;
            //var tempTable = "Temp" + typeof(T).Name;
            var tempTable = "tempdb..#Temp";

            var adapter = new SqlDataAdapter($@"
    IF OBJECT_ID('{tempTable}') IS NOT NULL
    DROP TABLE {tempTable}

    SELECT TOP 0 *
    INTO {tempTable}
    FROM {typeof(T).Name}

    SELECT * FROM {tempTable}", (SqlConnection)context.Database.Connection);
            var table = new DataTable();
            adapter.Fill(table);

            var rows = new List<DataRow>();
            foreach (var entity in entityList)
            {
                var entry = context.Entry(entity);
                if (entry.State != EntityState.Added)
                    entry.State = EntityState.Added;

                if (columnNames == null)
                {
                    columnNames = context.Entry(entity).CurrentValues.PropertyNames.ToList();
                    insertList = string.Join(",", columnNames.Where(r => r != "ID"));
                }

                var row = table.NewRow();
                rows.Add(row);

                for (var i = 0; i < columnNames.Count; i++)
                {
                    row[i] = entry.CurrentValues[columnNames[i]] ?? DBNull.Value;
                }
            }

            var bulk = new SqlBulkCopy((SqlConnection)context.Database.Connection);
            bulk.DestinationTableName = $"{tempTable}";
            bulk.WriteToServer(rows.ToArray());

            var s = $@"
    DECLARE @id TABLE (Id int)

    INSERT {typeof(T).Name}({insertList})
    OUTPUT INSERTED.ID INTO @id
    SELECT {insertList}
    FROM {tempTable}
    ORDER BY ID"; // Order By is important (bug if > 100 records)

            if (fillIds)
                s += "\n\nSELECT * FROM @id ORDER BY Id"; // Order By is important

            return s;
        }
        
        private static string InsertBatch<T>(DbContext context, bool fillIds, List<T> entityList) where T : class, IEntity, IHasId
        {
            List<string> columnNames = null;
            string insertList = null;

            var s = new StringBuilder(@"
    DECLARE @id TABLE (Id int)
    ");
            var i = 0;
            foreach (var entity in entityList)
            {
                var entry = context.Entry(entity);
                if (entry.State != EntityState.Added)
                    entry.State = EntityState.Added;

                if (columnNames == null)
                {
                    columnNames = context.Entry(entity).CurrentValues.PropertyNames.ToList();
                    insertList = string.Join(",", columnNames.Where(r => r != "ID"));
                }

                if (i % 1000 == 0)
                {
                    s.Append($@"
    INSERT {typeof(T).Name}({insertList})
    OUTPUT INSERTED.ID INTO @id
    VALUES");
                }
                else
                    s.Append(",");

                var valueList = string.Join(",", columnNames.Where(r => r != "ID").Select(r => SqlEncode(entry.CurrentValues[r])));
                s.Append($"\n({valueList})");

                i++;
            }

            if (fillIds)
                s.Append("\n\nSELECT * FROM @id ORDER BY Id"); // Order By is important

            return s.ToString();
        }

        private static string SqlEncode(object value)
        {
            if (value == null)
                return "null";
            else if (value is DateTime?)
                return "'" + ((DateTime?)value).Value.ToString("yyyy-MM-ddThh:mm:ss.fff") + "'";
            else if (value is string)
                return "N'" + value.ToString().Replace("'", "''") + "'";
            else // bool, int
            {
                var s = value.ToString();
                if (s == "True")
                    s = "1";
                if (s == "False")
                    s = "0";
                return s;
            }
        }*/
    }
}
