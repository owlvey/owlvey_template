﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectPS.ServicePS.Component.Interfaces;
using ProjectPS.ServicePS.Component.Services;
using ProjectPS.ServicePS.Identity;

namespace ProjectPS.ServicePS.IoC
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddTransient<IAppSettingQueryService, AppSettingQueryService>();
            services.AddTransient<IAppSettingService, AppSettingService>();
            
            // Infra
            services.AddAspNetCoreIndentityService();
        }
    }
}
