using DSEU.Application.Common.Enums;
using IdentityModel;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace DSEU.Infrastructure.Identity.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIdentityServer4(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityDbContext>(options => ConfigureApiAuthorization(options, configuration));

            services.AddAuthentication().AddIdentityServerJwt();

            services.Configure<JwtBearerOptions>(IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
                options => ConfigureJwtBearerOptions(options, configuration));
        }

        private static void ConfigureApiAuthorization(ApiAuthorizationOptions options, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            ConfigureClients(options.Clients, configuration);
            ConfigureApiResources(options.ApiResources);

        }

        private static void ConfigureClients(ClientCollection clients, IConfiguration configuration)
        {
            foreach (var client in clients)
            {
                var additionalHosts = configuration.GetSection($"IdentityServer:Clients:{client.ClientName}:AdditionalHosts").Get<Uri[]>();

                if (additionalHosts != null)
                {
                    var mainRedirectUri = client.RedirectUris.First();
                    var mainPostLogoutRedirectUri = client.PostLogoutRedirectUris.First();
                    UriBuilder redirectUriBuilder = new UriBuilder(mainRedirectUri);
                    UriBuilder postLogoutRedirectUriBuilder = new UriBuilder(mainPostLogoutRedirectUri);
                    foreach (var additionalHost in additionalHosts)
                    {
                        redirectUriBuilder.Host = postLogoutRedirectUriBuilder.Host = additionalHost.Host;
                        redirectUriBuilder.Scheme = postLogoutRedirectUriBuilder.Scheme = additionalHost.Scheme;
                        redirectUriBuilder.Port = postLogoutRedirectUriBuilder.Port = additionalHost.Port;

                        client.RedirectUris.Add(redirectUriBuilder.Uri.ToString());
                        client.PostLogoutRedirectUris.Add(postLogoutRedirectUriBuilder.Uri.ToString());
                    }
                }

                client.AllowOfflineAccess = true;
                client.AccessTokenLifetime = (int)TimeSpan.FromHours(8).TotalSeconds;
            }
        }

        private static void ConfigureApiResources(ApiResourceCollection apiResources)
        {
            var apiResource = apiResources.First();
            var claims = new List<string>();
            claims.AddRange(Enum.GetNames<UserClaimTypes>().ToList());
            claims.Add(JwtClaimTypes.Role);
            apiResource.UserClaims = claims;
        }

        private static void ConfigureJwtBearerOptions(JwtBearerOptions options, IConfiguration configuration)
        {
            //var tokenValidIssuers = configuration.GetSection($"IdentityServer:TokenValidationParameters:ValidIssuers").Get<string[]>();

            //options.TokenValidationParameters.ValidIssuers = tokenValidIssuers;
            //var originalOnMessageRecieveEvent = options.Events.OnMessageReceived;
            //options.Events = new JwtBearerEvents
            //{
            //    OnMessageReceived = context =>
            //    {
            //        var accessToken = context.Request.Query["access_token"];
            //        // If the request is for our hub...
            //        var path = context.HttpContext.Request.Path;
            //        if (!string.IsNullOrEmpty(accessToken))
            //        {
            //            // Read the token out of the query string
            //            context.Token = accessToken;
            //        }
            //        originalOnMessageRecieveEvent(context);
            //        return Task.CompletedTask;
            //    }
            //};
        }

    }
}
