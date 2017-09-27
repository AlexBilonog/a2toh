using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FRS.Common
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> keySelector)
        {
            return items.GroupBy(keySelector, (key, group) => group.First());
        }

        public static IQueryable<T> DistinctBy<T, TKey>(this IQueryable<T> items, Expression<Func<T, TKey>> keySelector)
        {
            return items.GroupBy(keySelector, (key, group) => group.FirstOrDefault());
        }

        public static T Second<T>(this IEnumerable<T> items)
        {
            return items.Skip(1).First();
        }

        public static T MaxOrDefault<T>(this IEnumerable<T> items)
        {
            return items.DefaultIfEmpty().Max();
        }

        public static IEnumerable<T> OnEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);

            return items;
        }

        /// <summary>Convert EF6 includes to EF7 includes. Allows using old select syntax like: ".Select(r2 => r2.NestedEntity)"</summary>
        public static IQueryable<T> IncludeEf6<T>(this IQueryable<T> query, List<Expression<Func<T, object>>> includes) where T : class // not IList<> !
        {
            return query.IncludeEf6(includes.ToArray());
        }

        /// <summary>Convert EF6 includes to EF7 includes. Allows using old select syntax like: ".Select(r2 => r2.NestedEntity)"</summary>
        public static IQueryable<T> IncludeEf6<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            foreach (var include in includes)
                query = ConvertIncludeToEf7(query, include, true);

            return query;
        }

        public static IEnumerable<T> Merge<T>(IEnumerable<T> inMemoryEntities, IEnumerable<T> existingEntities) where T : IHasId
        {
            var dict = new Dictionary<int, T>();
            foreach (var entity in existingEntities)
            {
                dict[entity.ID] = entity;
            }

            foreach (var entity in inMemoryEntities.Where(r => r.ID != 0))
            {
                dict[entity.ID] = entity;
            }

            var result = dict.Values.ToList();
            result.AddRange(inMemoryEntities.Where(r => r.ID == 0));
            return result;
        }

        private static IQueryable<T> ConvertIncludeToEf7<T>(IQueryable<T> source, LambdaExpression expression, bool isFirstLevel) where T : class
        {
            //TODOEF7 Wait until EF team fix Include to cached in memory data
            if (source.GetType().Name.Contains("List`1") || source.GetType().Name.Contains("[]") || source.GetType().Name == "EnumerableQuery`1")
                return source;

            var query = (dynamic)source;
            if (expression.Body is MemberExpression)
            {
                if (isFirstLevel)
                    query = EntityFrameworkQueryableExtensions./**/Include(query, (dynamic)Expression.Lambda(expression.Body, expression.Parameters[0]));
                else
                    query = EntityFrameworkQueryableExtensions.ThenInclude(query, (dynamic)Expression.Lambda(expression.Body, expression.Parameters[0]));
            }
            else
            {
                var args = ((MethodCallExpression)expression.Body).Arguments;

                if (isFirstLevel)
                    query = EntityFrameworkQueryableExtensions./**/Include(query, (dynamic)Expression.Lambda(args[0], expression.Parameters[0]));
                else
                    query = EntityFrameworkQueryableExtensions.ThenInclude(query, (dynamic)Expression.Lambda(args[0], expression.Parameters[0]));

                query = ConvertIncludeToEf7(query, (dynamic)args[1], false);
            }

            return query;
        }
    }
}
