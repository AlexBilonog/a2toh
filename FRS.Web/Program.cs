using FRS.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FRS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MigrationHelper.ReadArguments(ref args);

            var webHost = BuildWebHost(args);

            if (MigrationHelper.IsActive)
            {
                MigrationHelper.Run();
                return;
            }

            webHost.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
