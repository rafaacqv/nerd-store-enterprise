﻿using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Config
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
        }
    }
}
