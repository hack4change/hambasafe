using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Hambasafe.Api.Models.v1;

namespace Hambasafe.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<Hambasafe.DataLayer.Entities.HambasafeDataContext>(options =>
                                 options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddMvc();
            services.AddSwaggerGen();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DataLayer.DataAccessModule>();
            containerBuilder.RegisterModule<Services.ServicesModule>();
            var config = new MapperConfiguration(i => i.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            containerBuilder.RegisterInstance(mapper).As<IMapper>();
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();
            app.UseMvc();
            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
