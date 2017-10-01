using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FRS.Common
{
    public static class MigrationHelper
    {
        public static bool IsActive { get; set; }
        private static bool IsRecreate { get; set; }
        private static IApplicationBuilder ApplicationBuilder { get; set; }
        private static Action<DbContext> SeedAction { get; set; }

        private static string ConnectionString { get; set; }
        private static string ConnectionStringWithoutCatalog { get; set; }
        private static string DataSourcePart { get; set; }
        private static string CatalogPart { get; set; }
        private static string Catalog { get; set; }
        private static string UserId { get; set; }
        private static string Password { get; set; }

        public static void ReadArguments(ref string[] args)
        {
            if (args == null || args.Length == 0)
                return;

            if (args[0] != "migrate" || args.Length == 2 && args[1] != "1" || args.Length > 2)
            {
                Console.WriteLine("Possible arguments:");
                Console.WriteLine("\tmigrate - apply migrations");
                Console.WriteLine("\tmigrate 1 - recreate db and apply migrations");
                args = new string[0];
                return;
            }

            IsActive = true;
            IsRecreate = (args.ElementAtOrDefault(1) == "1");
            args = new string[0];

            if (IsActive)
                SetEnvironmentVariable();
        }

        private static void SetEnvironmentVariable()
        {
            var environmentVariable = "ASPNETCORE_ENVIRONMENT";

            if (File.Exists("web.config"))
            {
                var webConfig = XDocument.Load("web.config");
                var environments = webConfig
                    .Descendants("configuration")
                    .Descendants("system.webServer")
                    .Descendants("aspNetCore")
                    .Descendants("environmentVariables")
                    .Descendants("environmentVariable")
                    .Where(r => r.Attribute("name")?.Value == environmentVariable);

                if (environments.Any())
                {
                    var environment = environments.First().Attribute("value")?.Value;
                    Environment.SetEnvironmentVariable(environmentVariable, environment);
                }
            }

            Console.WriteLine("Environment: " + Environment.GetEnvironmentVariable(environmentVariable));
        }

        public static void Init(IApplicationBuilder applicationBuilder, Action<DbContext> seedAction)
        {
            ApplicationBuilder = applicationBuilder;
            SeedAction = seedAction;
        }

        public static void ConvertToIntegratedSecurity(ref string connectionString)
        {
            var parts = connectionString.Split(';');

            DataSourcePart = parts.Single(r => r.ToLower().StartsWith("data source"));
            Console.WriteLine(nameof(DataSourcePart) + ": " + DataSourcePart);

            CatalogPart = parts.Single(r => r.ToLower().StartsWith("initial catalog"));
            Console.WriteLine(nameof(CatalogPart) + ": " + CatalogPart);

            Catalog = CatalogPart.Split('=').Last();

            UserId = parts.SingleOrDefault(r => r.ToLower().StartsWith("user id"))?.Split('=')[1];
            Console.WriteLine(nameof(UserId) + ": " + UserId);

            Password = parts.SingleOrDefault(r => r.ToLower().StartsWith("password"))?.Split('=')[1];
            Console.WriteLine(nameof(Password) + ": " + Password);

            ConnectionStringWithoutCatalog = DataSourcePart + ";integrated security=SSPI";

            ConnectionString = DataSourcePart + ";" + CatalogPart + ";integrated security=SSPI";
            connectionString = ConnectionString;
        }

        public static void Run()
        {
            if (Environment.UserInteractive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press 'Enter' to continue...");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    return;
            }

            var exists = CheckIfDatabaseExists();

            if (IsRecreate)
            {
                if (Environment.UserInteractive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to recreate the database? (y/n)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (Console.ReadKey().Key != ConsoleKey.Y)
                        return;
                }
                DropDatabase();
            }

            RunMigrate();
            RunSeed();

            if ((!exists || IsRecreate) && UserId != null && Password != null)
            {
                CreateLoginAndUser();
            }
        }

        private static void RunMigrate()
        {
            Console.WriteLine("\nApplying migrations...");
            using (var serviceScope = ApplicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<DbContext>())
            {
                context.Database.Migrate();
            }
        }

        private static void RunSeed()
        {
            Console.WriteLine("\nApplying seed...");
            using (var serviceScope = ApplicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<DbContext>())
            {
                SeedAction(context);
            }
        }

        private static bool CheckIfDatabaseExists()
        {
            Console.WriteLine("\nChecking if database exists...");
            using (var con = new SqlConnection(ConnectionStringWithoutCatalog))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"SELECT count(*) FROM sys.databases WHERE name='{Catalog}'";
                    var count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private static void DropDatabase()
        {
            Console.WriteLine("\nDropping database...");
            using (var con = new SqlConnection(ConnectionStringWithoutCatalog))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $@"
IF EXISTS (select * from sys.databases where name='{Catalog}')
BEGIN
    ALTER DATABASE [{Catalog}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE

    DROP DATABASE [{Catalog}]
END";
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void CreateLoginAndUser()
        {
            Console.WriteLine("\nCreating login (if needed) and user...");
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $@"
IF NOT EXISTS (SELECT * FROM msdb.sys.syslogins WHERE name = '{UserId}')
BEGIN
    CREATE LOGIN [{UserId}] WITH PASSWORD=N'{Password}', DEFAULT_DATABASE=[{Catalog}], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END

CREATE USER [frs_admin] FOR LOGIN [{UserId}]

ALTER ROLE [db_owner] ADD MEMBER [frs_admin]";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
