using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Context;
using DictoServices.Interfaces;
using DictoServices.Services;
using DictoWeb.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DictoWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            CurrentEnvironment = environment;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration["ConnectionString"];

            if (CurrentEnvironment.IsProduction())
            {
                var server = Configuration["DatabaseServer"];
                var database = Configuration["DatabaseName"];
                var user = Configuration["DatabaseUser"];
                var password = Configuration["DatabaseNamePassword"];
                connectionString =
                    $"Server={server};Database={database};User Id={user};Password={password};MultipleActiveResultSets=true";
            }

            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdB2CBearer(options => Configuration.Bind("AzureAdB2C", options));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Administrator"));
                options.AddPolicy("User", policy => policy.RequireClaim("User"));
            });

            System.Diagnostics.Debug.WriteLine($"Connection String: {connectionString}");

            services.AddDbContext<DictoContext>(opt => opt.UseSqlServer(connectionString));
            services.AddLogging();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper();
            services.AddCors(options =>
            {
                options.AddPolicy("ChromeExtensions",builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowCredentials());
            });
            services
                .AddMvc()
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.ContractResolver = new LowerCaseContractResolver();
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use( async (context, func) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                await func();
            });
            
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/{Date}.log");
            app.UseAuthentication();
            app.UseCors("ChromeExtensions");
            app.UseMvc();
        }
    }
}
