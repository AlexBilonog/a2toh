using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FRS.DataAccess.Contracts
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);
        void Detach(T entity);
        EntityState GetState(T entity);
        void SetState(T entity, EntityState state);

        IQueryable<T> AsQueryable();
        IQueryable<T> AsQueryableNoTracking();

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllNoTracking(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FilterIncluding(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
        IEnumerable<T> FilterNoTracking(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FilterNoTracking(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T GetById(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FilterIncludingAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
    }
}
