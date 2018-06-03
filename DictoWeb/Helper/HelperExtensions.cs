using System;
using System.Security.Claims;
using DictoData.Interfaces;
using DictoData.UnitOfWork;
using DictoServices.Interfaces;
using DictoServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DictoWeb.Helper
{
    public static class HelperExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IFirstLevelService, Level1Service>();
            services.AddScoped<ISecondLevelService, Level2Service>();
        }

       
    }
}