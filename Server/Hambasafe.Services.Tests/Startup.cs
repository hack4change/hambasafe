using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hambasafe.DataLayer;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Hambasafe.Services.Tests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                    .AddInMemoryDatabase()
                    .AddDbContext<DataLayer.Entities.HambasafeDataContext>();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DataAccessModule>();
            containerBuilder.RegisterModule<ServicesModule>();
       
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();
             container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
