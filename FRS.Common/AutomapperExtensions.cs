using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Common
{
    public static class AutomapperExtensions
    {
        public static TDestination Map<TDestination>(this object source)
        {
            var sourceType = source.GetType();
            var destinationType = typeof(TDestination);

            CreateMapIfNeed(sourceType, destinationType);
            return Mapper.Map<TDestination>(source);
        }

        public static TDestination MapOrDefault<TDestination>(this object source) where TDestination : class
        {
            return source?.Map<TDestination>();
        }

        public static void MapTo(this object source, object destination)
        {
            var sourceType = source.GetType();
            var destinationType = destination.GetType();

            CreateMapIfNeed(sourceType, destinationType);
            Mapper.Map(source, destination, sourceType, destinationType);
        }

        public static List<TDestination> Map<TDestination>(this IEnumerable source)
        {
            var results = new List<TDestination>();
            foreach (var s in source)
                results.Add(s.Map<TDestination>());
            return results;
        }

        public static IQueryable<TDestination> Project<TDestination>(this IQueryable source)
        {
            CreateMapIfNeed(source.GetType().GetGenericArguments()[0], typeof(TDestination));
            return Extensions.ProjectTo<TDestination>((dynamic)source);
        }

        public static void CreateMapIfNeed(Type sourceType, Type destinationType)
        {
            var map = Mapper.Configuration.FindTypeMapFor(sourceType, destinationType);
            if (map == null || map.SourceType != sourceType || map.DestinationType != destinationType)
            {
                // https://github.com/AutoMapper/AutoMapper/wiki/Mapping-inheritance
                Mapper.Initialize(config => config.CreateMap(sourceType, destinationType));
            }
        }
    }
}
