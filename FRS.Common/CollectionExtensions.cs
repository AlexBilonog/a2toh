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
    }
}
