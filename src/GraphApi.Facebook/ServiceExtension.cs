using Microsoft.Extensions.DependencyInjection;
using System;
using GraphApi.Facebook.Client.Config;
using GraphApi.Facebook.Client.GraphApi.DebugToken;
using GraphApi.Facebook.Client.GraphApi.AccessToken;
using GraphApi.Facebook.Client.GraphApi.User;
using GraphApi.Facebook.GraphApi.TestUser;

namespace GraphApi.Facebook.Client
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddFacebookClient(this IServiceCollection services, Action<ApplicationCredentials> facebookAppCreds)
        {
            services.AddHttpClient(Facebook.Constants.Facebook.FacebookClientName, c =>
            {
                c.BaseAddress = new Uri("https://graph.facebook.com/");
            });

            services.AddSingleton<IFacebookClient, FacebookClient>();
            services.AddSingleton<IDebugTokenFbService, DebugTokenFbService>();
            services.AddSingleton<IAccessTokenFbService, AccessTokenFbService>();
            services.AddSingleton<IUserFbService, UserFbService>();
            services.AddSingleton<ITestUserFbService, TestUserFbService>();
            services.AddOptions<ApplicationCredentials>().Configure(facebookAppCreds);
            return services;
        }
    }
}
