using System;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
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
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

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
                    .AddDbContext<HambasafeDataContext>(options =>
                                 options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddEntityFramework()
                  .AddSqlServer()
                  .AddDbContext<ApplicationDbContext>(options =>
                               options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddMvc();
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

            app.UseIISPlatformHandler();
            app.UseIdentity();
            app.UseFacebookAuthentication(o =>
            {
                o.AppId = "216973471993488";
                o.AppSecret = "ad89d09791b171b006f831095fb1f274";
            });

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

            app.UseJwtBearerAuthentication(options =>
            {
                // Basic settings - signing key to validate with, audience and issuer.
                options.TokenValidationParameters.IssuerSigningKey = _key;
                options.TokenValidationParameters.ValidAudience = _tokenOptions.Audience;
                options.TokenValidationParameters.ValidIssuer = _tokenOptions.Issuer;

                // When receiving a token, check that we've signed it.
                options.TokenValidationParameters.ValidateSignature = true;

                // When receiving a token, check that it is still valid.
                options.TokenValidationParameters.ValidateLifetime = true;

                // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time 
                // when validating the lifetime. As we're creating the tokens locally and validating them on the same 
                // machines which should have synchronised time, this can be set to zero. Where external tokens are
                // used, some leeway here could be useful.
                options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(0);
            });

            app.UseMvc();
            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
