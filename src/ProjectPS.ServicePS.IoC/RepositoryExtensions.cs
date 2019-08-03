using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectPS.ServicePS.Core.Repositories;
using ProjectPS.ServicePS.Data.SQLite.Repositories;
using ProjectPS.ServicePS.Data.SQLite.Context;
using Microsoft.Extensions.HealthChecks;

namespace ProjectPS.ServicePS.IoC
{
    public static class RepositoryExtensions
    {
        public static void SetupDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddScoped(x => new ServicePSDbContextFactory().Create(connectionString));
            services.AddDbContext<ServicePSDbContext>(options =>
                options.UseSqlite(connectionString)
            );
            
        }
        
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //// Infra - Data
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
        }
    }
}
