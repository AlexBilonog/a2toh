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
        private static string Catalog { get; set; }
        private static string UserId { get; set; }
        private static string Password { get; set; }
        private static DbContext Context { get; set; }

        public static void ReadArguments(ref string[] args)
        {
            if (args == null || args.Length == 0)
                return;

            if (args[0] != "migrate"
                || args.Length == 2 && args[1] != "0" && args[1] != "1"
                || args.Length > 2)
            {
                WriteLine("Possible arguments:");
                WriteLine("\tmigrate - apply migrations");
                WriteLine("\tmigrate 1 - recreate db and apply migrations");
                args = new string[0];
                return;
            }

            IsActive = true;
            IsRecreate = (args.ElementAtOrDefault(1) == "1");

            if (IsRecreate)
                WriteLine("Is Recreate: True", ConsoleColor.Red);

            SetEnvironmentVariable();

            args = new string[0];
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

            WriteLine("Environment: " + Environment.GetEnvironmentVariable(environmentVariable), ConsoleColor.Yellow);
        }

        private static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Init(IApplicationBuilder applicationBuilder, Action<DbContext> seedAction)
        {
            ApplicationBuilder = applicationBuilder;
            SeedAction = seedAction;
        }

        public static void ConvertToIntegratedSecurity(ref string connectionString)
        {
            var parts = connectionString.Split(';').Select(r => r.Trim().ToLower());

            var dataSourcePart = parts.Single(r => r.StartsWith("data source"));
            WriteLine("Data Source: " + dataSourcePart);

            var catalogPart = parts.Single(r => r.StartsWith("initial catalog"));
            WriteLine("Catalog: " + catalogPart);

            Catalog = catalogPart.Split('=').Last();

            UserId = parts.SingleOrDefault(r => r.StartsWith("user id"))?.Split('=')[1];
            WriteLine("User Id: " + UserId);

            Password = parts.SingleOrDefault(r => r.StartsWith("password"))?.Split('=')[1];
            WriteLine("Password: " + Password);

            ConnectionString = dataSourcePart + ";" + catalogPart + ";integrated security=SSPI";
            connectionString = ConnectionString;
        }

        public static void Run()
        {
            if (Environment.UserInteractive)
            {
                WriteLine("Press 'Space' to continue...", ConsoleColor.Yellow);
                if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                    return;
            }

            using (var serviceScope = ApplicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (Context = serviceScope.ServiceProvider.GetService<DbContext>())
            {
                if (IsRecreate)
                {
                    DropDatabase();
                }

                RunMigrate();
                RunSeed();

                if (UserId != null && Password != null)
                {
                    CreateLoginAndUserIfNotExist();
                }
            }
        }

        private static void DropDatabase()
        {
            WriteLine("\nDropping database...");
            Context.Database.EnsureDeleted();
        }

        private static void RunMigrate()
        {
            WriteLine("\nApplying migrations...");
            Context.Database.Migrate();
        }

        private static void RunSeed()
        {
            WriteLine("\nApplying seed...");
            SeedAction(Context);
        }

        private static void CreateLoginAndUserIfNotExist()
        {
            WriteLine("\nCreating login and user (if not exist)...");
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

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = '{UserId}' and type = 'S')
BEGIN
    CREATE USER [{UserId}] FOR LOGIN [{UserId}]
END

ALTER ROLE [db_datareader] ADD MEMBER [{UserId}]
ALTER ROLE [db_datawriter] ADD MEMBER [{UserId}]";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
