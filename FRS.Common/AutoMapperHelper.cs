using AutoMapper;
using AutoMapper.QueryableExtensions;
using FRS.Common.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FRS.Common
{
    public static class AutoMapperHelper
    {
        public static void Configure()
        {
            Mapper.Initialize(c => { });

            var types = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("FRS"))
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .ToList();

            var defaultProfiles = types
                .Select(t => new
                {
                    Type1 = t,
                    Type2 = t.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapsFrom<>))
                        ?.GetGenericArguments()[0]
                })
                .Where(r => r.Type2 != null);

            var customProfiles = types
                .Where(t => t.GetInterfaces().Any(i => i == typeof(IHasCustomMapping)))
                .Select(t => (IHasCustomMapping)Activator.CreateInstance(t));

            foreach (var profile in defaultProfiles)
            {
                Mapper.Initialize(c => c.CreateMap(profile.Type1, profile.Type2).ReverseMap());
            }

            foreach (var profile in customProfiles)
            {
                Mapper.Initialize(c => profile.ConfigureMapping(c));
            }
        }

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
