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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace DictoWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


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
            services.AddDbContext<DictoContext>();
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
                .AddJsonOptions(o => o.SerializerSettings.ContractResolver = new LowerCaseContractResolver());

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
