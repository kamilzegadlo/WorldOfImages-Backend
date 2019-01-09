using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorldOfImages_RepositoryProcedures;
using WorldOfImagesAPI;
using WorldOfImagesAPI_Model.Repositories;

namespace WorldOfImages_API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Static Cling - unit testing this because AddMvc is extenstion method (static one) is not a simple task...
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Static Cling - unit testing this because UseMvc is extenstion method (static one) is not a simple task...
            app.UseExceptionHandler(new CustomExceptionHandlerMiddleware().UseExceptionHandler);

            app.UseMvc();
        }
    }
}