using FRS.Common;
using FRS.Common.Contracts;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FRS.Business.Common
{
    public abstract class BaseService
    {
        protected readonly DbContext Context;
        protected readonly ILogger Logger;
        protected readonly ICacheProvider CacheProvider;

        protected BaseService(DbContext context, ILogger<BaseService> logger, ICacheProvider cacheProvider)
        {
            Context = context;
            CacheProvider = cacheProvider;
            Logger = logger;
        }

        private ICollection<T> CreateEntities<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            Context.Set<T>().AddRange(entities);
            Context.SaveChanges();

            return entities.ToList();
        }

        private ICollection<T> UpdateEntities<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            Context.Set<T>().UpdateRange(entities);
            Context.SaveChanges();

            return entities.ToList();
        }

        private ICollection<T> DeleteEntities<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            Context.Set<T>().RemoveRange(entities);
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Logger.LogInformation($"Delete error. {ex}");
                //TODO
                throw new Exception("DeleteEntityException");
                //throw new DeleteEntityException();
            }

            return entities.ToList();
        }

        protected ICollection<T> Cache<T>(Func<IEnumerable<T>> resolveFunc)
        {
            return Cache(null, null, resolveFunc);
        }

        protected ICollection<T> Cache<T>(int minutes, Func<IEnumerable<T>> resolveFunc)
        {
            return Cache(null, minutes, resolveFunc);
        }

        protected ICollection<T> Cache<T>(string key, Func<IEnumerable<T>> resolveFunc)
        {
            return Cache(key, null, resolveFunc);
        }

        protected ICollection<T> Cache<T>(string key, int? minutes, Func<IEnumerable<T>> resolveFunc)
        {
            if (CacheProvider == null)
                throw new InvalidOperationException("Cache is not defined");

            key += "_" + typeof(T);
            minutes = minutes ?? 3;

            if (CacheProvider.Get(key) == null)
            {
                CacheProvider.Add(key, resolveFunc(), minutes.Value);
            }

            return (ICollection<T>)CacheProvider.Get(key);
        }

        protected DataSourceResult GetEntitiesForGrid<TEntity, TDto>(DataSourceRequest request) where TEntity : class, IEntity
        {
            AddDefaultSort(request);
            return Context.Set<TEntity>().ToDataSourceResult(request, entity => entity.Map<TDto>());
        }

        protected DataSourceResult GetEntitiesForGridWithProjection<TEntity, TDto>(DataSourceRequest request) where TEntity : class, IEntity
        {
            AddDefaultSort(request);
            return Context.Set<TEntity>().Project<TDto>().ToDataSourceResult(request);
        }

        private void AddDefaultSort(DataSourceRequest request)
        {
            if (request.Sorts == null || !request.Sorts.Any())
                request.Sorts = new List<SortDescriptor> { new SortDescriptor("Id", ListSortDirection.Descending) };
        }

        protected IEnumerable<TDto> CreateEntitiesForGrid<TEntity, TDto>(IEnumerable<TDto> dtos) where TEntity : class, IEntity
        {
            ValidateDtos(dtos);
            var entities = CreateEntities(dtos.Map<TEntity>());
            return entities.Map<TDto>();
        }

        protected IEnumerable<TDto> UpdateEntitiesForGrid<TEntity, TDto>(IEnumerable<TDto> dtos) where TEntity : class, IEntity
        {
            ValidateDtos(dtos);
            var entities = UpdateEntities(dtos.Map<TEntity>());
            return entities.Map<TDto>();
        }

        protected void DeleteEntitiesForGrid<TEntity, TDto>(IEnumerable<TDto> dtos) where TEntity : class, IEntity
        {
            ValidateDtos(dtos);
            DeleteEntities(dtos.Map<TEntity>());
        }

        protected virtual void ValidateDtos(object model)
        {
        }
    }
}
