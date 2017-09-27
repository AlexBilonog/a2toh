using EventManager.Common;
using EventManager.Common.Contracts;
using EventManager.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Common.Test;

namespace EventManager.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly Hashtable _repositories = new Hashtable();
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            var typeName = typeof(T).Name;

            if (_repositories.ContainsKey(typeName))
                return (IRepository<T>)_repositories[typeName];

            var repositoryType = typeof(EFRepository<>);
            var genericRepoType = repositoryType.MakeGenericType(typeof(T));
            _repositories.Add(typeName, Activator.CreateInstance(genericRepoType, _context));
            return (IRepository<T>)_repositories[typeName];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        public void BulkInsert<T>(IEnumerable<T> entities, Action<T> doneAction = null, BulkHelperDto dto = null) where T : class, IEntity, IHasId
        {
            if (TestEnvironment.IsSet)
            {
                _context.AddRange(entities);
                if (doneAction != null)
                    entities.ToList().ForEach(doneAction);
                _context.SaveChanges();
                return;
            }

            new BulkHelper<T>()
            {
                Entities = entities.ToList(),
                DoneAction = doneAction,
                Dto = dto,
                Context = _context
            }.Insert();
        }

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (TestEnvironment.IsSet)
                return new FakeIDbContextTransaction();

            //TODOEF7 Event UpdateEvent(Event ev) does not work with syntax:
            //EM-1930 Event basic data cannot be edited, if event has a project number
            //return _context.Database.BeginTransaction(isolationLevel);

            var con = _context.Database.GetDbConnection();

            if (con.State != ConnectionState.Open)
                con.Open();

            var tran = con.BeginTransaction(isolationLevel);
            return _context.Database.UseTransaction(tran);
        }

        public void CommitTransaction()
        {
            if (TestEnvironment.IsSet)
                return;

            _context.Database.CommitTransaction();
        }
    }
}
