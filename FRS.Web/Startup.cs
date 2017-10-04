using FRS.Business.Common;
using FRS.Business.Products;
using FRS.Common;
using FRS.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace FRS.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(options => options.AddProvider(new CustomDebugLoggerProvider()));

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            if (MigrationHelper.IsActive)
                MigrationHelper.ConvertToIntegratedSecurity(ref connectionString);

            services.AddDbContext<FRSContext>(options => options
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddKendo();

            services.AddCors();

            services.AddScoped<DbContext, FRSContext>();
            services.AddTransient<ICacheProvider, CacheProvider>();
            services.AddTransient<IProductsService, ProductsService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.UseKendo(env);

            if (MigrationHelper.IsActive)
                MigrationHelper.Init(app, SeedData.Apply);

            AutoMapperHelper.Configure();
        }
    }
}
