using FRS.Common;
using FRS.Common.Contracts;
using FRS.DataModel.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FRS.DataModel
{
    public class FRSDbContext : DbContext
    {
        public FRSDbContext()
        {
            if (!TestEnvironment.IsSet)
                Database.SetCommandTimeout(600);
        }

        public FRSDbContext(DbContextOptions<FRSDbContext> options)
            : base(options)
        {
            if (!TestEnvironment.IsSet)
                Database.SetCommandTimeout(600);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(r => r.IsClass && typeof(IEntity).IsAssignableFrom(r));
            foreach (var entityType in entityTypes)
            {
                var entity = (IEntity)Activator.CreateInstance(entityType);
                entity.Configure(modelBuilder);
            }

            entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(r => r.IsClass && typeof(IEntityEx).IsAssignableFrom(r));
            foreach (var entityType in entityTypes)
            {
                var entity = (IEntityEx)Activator.CreateInstance(entityType);
                entity.ConfigureEx(modelBuilder);
            }

#if DEBUG
            this.GetService<ILoggerFactory>().AddProvider(new DebugLoggerProvider());
            //this.GetService<ILoggerFactory>().AddDebug(LogLevel.Debug);
#endif
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (TestEnvironment.IsSet)
                return;

            optionsBuilder.UseSqlServer(EfHelper.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(); // suggestion in exceptions to show more info (parameters, etc for at development)
        }

        public override int SaveChanges()
        {
            try
            {
                EfHelper.ApplyAuditRules(this);
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
            EfHelper.ApplyAuditRules(this);
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
