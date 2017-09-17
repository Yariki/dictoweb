using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.AspNetCore.Authentication
{
    public static class AzureAdServiceCollectionExtensions
    {
        public static AuthenticationBuilder AddAzureAdB2CBearer(this AuthenticationBuilder builder)
            => builder.AddAzureAdB2CBearer(_ => { });

        public static AuthenticationBuilder AddAzureAdB2CBearer(this AuthenticationBuilder builder, Action<AzureAdB2COptions> configureOptions)
        {
            builder.Services.Configure(configureOptions);
            builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureAzureOptions>();
            builder.AddJwtBearer();
            return builder;
        }

        private class ConfigureAzureOptions: IConfigureNamedOptions<JwtBearerOptions>
        {
            private readonly AzureAdB2COptions _azureOptions;

            public ConfigureAzureOptions(IOptions<AzureAdB2COptions> azureOptions)
            {
                _azureOptions = azureOptions.Value;
            }

            public void Configure(string name, JwtBearerOptions options)
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = _azureOptions.ClientId,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_azureOptions.SecretKey))
                };
                options.Audience = _azureOptions.ClientId;
                options.RequireHttpsMetadata = false;
            }

            public void Configure(JwtBearerOptions options)
            {
                Configure(Options.DefaultName, options);
            }
        }
    }
}
