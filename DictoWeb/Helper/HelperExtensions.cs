using DictoServices.Interfaces;
using DictoServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DictoWeb.Helper
{
    public static class HelperExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}