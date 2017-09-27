using EventManager.Common;
using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EventManager.DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        void Commit();
        Task<int> CommitAsync();
        //void SetState<T>(IEnumerable<T> entities, EntityState state) where T : class, IEntity;
        void BulkInsert<T>(IEnumerable<T> entities, Action<T> doneAction = null, BulkHelperDto dto = null) where T : class, IEntity, IHasId;
        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CommitTransaction();
    }
}
