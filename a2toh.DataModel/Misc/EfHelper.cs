using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FRS.Common
{
    public static class EfHelper
    {
        public static string ConnectionString
        {
            get
            {
                //TODO
                return null;
                //return Environment.GetEnvironmentVariable("ConnectionString") ?? ConfigurationManager.ConnectionStrings["EventManagerEF"].ConnectionString;
            }
        }

        public static void ApplyAuditRules(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries();
            foreach (var entry in entries
                .Where(e => e.Entity is AuditInfo &&
                (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                var entity = (AuditInfo)entry.Entity;
                if (entity == null) continue;

                string currentUserName = string.Empty;

                //TODO
                currentUserName = "em_admin@evolvice.de";// AppSecurityContext.UserName ?? "__service";

                if (string.IsNullOrEmpty(currentUserName))
                    currentUserName = "__webanonymous";

                if (entry.State == EntityState.Added)
                {
                    entity.CreationDateTime = DateTime.UtcNow;
                    entity.CreationUser = currentUserName;
                }
                else
                {
                    context.Entry(entity).Property(x => x.CreationDateTime).IsModified = false;
                    context.Entry(entity).Property(x => x.CreationUser).IsModified = false;
                }

                entity.LastModificationDateTime = DateTime.UtcNow;
                entity.LastModificationUser = currentUserName;
            }
        }

        public static void AddOrUpdateSeed<T>(this DbContext context, Func<T, T, bool> predicate = null, params T[] entities) where T : class, IHasId
        {
            if (entities.Any(r => r.ID == 0) && entities.Any(r => r.ID != 0))
                throw new ArgumentException(nameof(entities));

            var idsFilled = entities.Any(r => r.ID != 0);
            if (!idsFilled && predicate == null)
                throw new ArgumentException(nameof(predicate));

            IEnumerable<T> existingEntities;
            if (predicate == null)
            {
                predicate = (r, e) => e.ID == r.ID;
                existingEntities = context.Set<T>().Where(r => entities.Any(e => e.ID == r.ID)).ToList();
            }
            else
            {
                existingEntities = context.Set<T>().ToList().Where(r => entities.Any(e => predicate(r, e))).ToList();
            }

            foreach (var entity in entities)
            {
                var existingEntity = existingEntities.FirstOrDefault(r => predicate(r, entity));

                if (existingEntity == null)
                {
                    context.Add(entity);
                }
                else
                {
                    entity.CopySimplePropertiesTo(existingEntity, false, false);
                }
            }

            if (context.ChangeTracker.Entries().Any(r => r.State != EntityState.Unchanged))
            {
                context.Database.OpenConnection();

                try
                {
                    if (idsFilled)
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [" + typeof(T).Name + "] ON");
                }
                catch (Exception ex)
                {
                    //TODO
                    //var log = LogManager.GetLogger(typeof(EfHelper));
                    //log.Debug("SET IDENTITY_INSERT [" + typeof(T).Name + "] ON is failed:\n" + ex);
                }

                context.SaveChanges();
                context.Database.CloseConnection();
            }
        }
    }
}
