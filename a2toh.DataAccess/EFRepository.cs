using FRS.Common;
using FRS.Common.Contracts;
using FRS.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FRS.DataAccess
{
    internal class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbSet<T> DbSet { get; set; }
        internal DbContext Context { get; private set; }

        public EFRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual IQueryable<T> AsQueryable()
        {
            var entitiesQuery = DbSet.AsQueryable();
            return entitiesQuery;
        }

        public virtual IQueryable<T> AsQueryableNoTracking()
        {
            var entitiesQuery = DbSet.AsNoTracking().AsQueryable();
            return entitiesQuery;
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                Delete(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual void Attach(T entity)
        {
            DbSet.Attach(entity);
        }

        public virtual void Detach(T entity)
        {
            EntityEntry entry = Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public virtual EntityState GetState(T entity)
        {
            return Context.Entry(entity).State;
        }

        public virtual void SetState(T entity, EntityState state)
        {
            Context.Entry(entity).State = state;
        }



        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<T> GetAllNoTracking(params Expression<Func<T, object>>[] includes)
        {
            return DbSet.AsNoTracking().IncludeEf6(includes).ToList();
        }

        public IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            return DbSet.IncludeEf6(includes).ToList();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public IEnumerable<T> FilterNoTracking(Expression<Func<T, bool>> predicate)
        {
            return FilterNoTracking(predicate, new List<Expression<Func<T, object>>>());
        }

        public IEnumerable<T> FilterNoTracking(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            return DbSet.AsNoTracking().Where(predicate).IncludeEf6(includes).ToList();
        }

        public IEnumerable<T> FilterIncluding(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            return DbSet.Where(predicate).IncludeEf6(includes).ToList();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Single(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return DbSet.First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }



        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterIncludingAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            if (includes == null) throw new ArgumentNullException(nameof(includes));

            var entitiesQuery = DbSet.Where(predicate);
            entitiesQuery = includes.Aggregate(entitiesQuery, (current, include) => current.Include(include));

            return await entitiesQuery.ToListAsync();
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.SingleAsync(predicate);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstAsync(predicate);
        }
    }
}
