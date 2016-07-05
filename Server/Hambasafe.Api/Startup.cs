using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;

namespace Hambasafe.Api
{
    public class Startup
    {
        const string TokenAudience = "ExampleAudience";
        const string TokenIssuer = "ExampleIssuer";
        private RsaSecurityKey _key;
        private TokenAuthOptions _tokenOptions;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var inMemory = bool.Parse(Configuration["Data:InMemory"]);
            if (!inMemory)
            {
                services.AddDbContext<HambasafeDataContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
                services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();
            }
            else
            {
                services.AddDbContext<HambasafeDataContext>(options => options.UseInMemoryDatabase());
            } 
           

            services.AddCors(options => options.AddPolicy("AllowAllOrigins",
               builder =>
               {
                   builder
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
               }));
            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigins"));
            });
            services.AddSwaggerGen();
            var containerBuilder = new ContainerBuilder();
            RSAParameters keyParams = RSAKeyUtils.GetRandomKey();

            // Create the key, and a set of token options to record signing credentials 
            // using that key, along with the other parameters we will need in the 
            // token controlller.



            _key = new RsaSecurityKey(keyParams);
            _tokenOptions = new TokenAuthOptions()
            {
                Audience = TokenAudience,
                Issuer = TokenIssuer,
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256Signature)
            };
            containerBuilder.RegisterInstance(_tokenOptions).As<TokenAuthOptions>();
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
            app.UseDeveloperExceptionPage();
            var inMemory = bool.Parse(Configuration["Data:InMemory"]);
            if (!inMemory)
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<HambasafeDataContext>().Database.Migrate();
                    //serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                }
                app.UseIdentity();
                app.UseFacebookAuthentication(new FacebookOptions
                {
                    AppId = "216973471993488",
                    AppSecret = "ad89d09791b171b006f831095fb1f274",
                });
            }
            
           

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    // This should be much more intelligent - at the moment only expired 
                    // security tokens are caught - might be worth checking other possible 
                    // exceptions such as an invalid signature.
                    if (error?.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        // What you choose to return here is up to you, in this case a simple 
                        // bit of JSON to say you're no longer authenticated.
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(
                                new { authenticated = false, tokenExpired = true }));
                    }
                    else if (error?.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        // TODO: Shouldn't pass the exception message straight out, change this.
                        await context.Response.WriteAsync(
                                JsonConvert.SerializeObject
                                    (new { success = false, error = error.Error.Message }));
                    }
                    // We're not trying to handle anything else so just let the default 
                    // handler handle.
                    else
                    {
                        await next();
                    }
                });
            });

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                // Basic settings - signing key to validate with, audience and issuer.
              TokenValidationParameters = new TokenValidationParameters
              {
                  IssuerSigningKey = _key,
                  ValidAudience = _tokenOptions.Audience,
                  ValidIssuer = _tokenOptions.Issuer,
                  // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time 
                  // when validating the lifetime. As we're creating the tokens locally and validating them on the same 
                  // machines which should have synchronised time, this can be set to zero. Where external tokens are
                  // used, some leeway here could be useful.
                  ClockSkew = TimeSpan.FromMinutes(0),
                  ValidateLifetime = true
              },
               
            });

            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
        }
    }
}
