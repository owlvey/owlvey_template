using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjectPS.ServicePS.Components.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPS.ServicePS.Identity
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddAspNetCoreIndentityService(this IServiceCollection services)
        {
            services.TryAddTransient<IUserIdentityService, AspNetCoreIdentityService>();

            return services;
        }
    }
}
