using FRS.Common;
using FRS.Common.Contracts;
using FRS.Common.Test;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FRS.DataModel
{
    public class FRSContext : DbContext
    {
        public FRSContext(DbContextOptions<FRSContext> options)
            : base(options)
        {
            if (!TestEnvironment.IsSet)
                Database.SetCommandTimeout(600); //TODO move to connections string?
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(r => r.IsClass && typeof(IEntity).IsAssignableFrom(r));
            foreach (var entityType in entityTypes)
            {
                var entity = (IEntity)Activator.CreateInstance(entityType);
                entity.Configure(modelBuilder);
            }
        }

        public override int SaveChanges()
        {
            try
            {
                EFHelper.ApplyAuditRules(this);
                var saved = base.SaveChanges();
                return saved;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            EFHelper.ApplyAuditRules(this);
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
