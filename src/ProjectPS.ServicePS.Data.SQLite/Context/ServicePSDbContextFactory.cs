using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectPS.ServicePS.Data.SQLite.Context
{

    public class ServicePSDbContextFactory : IDesignTimeDbContextFactory<ServicePSDbContext>
    {
        public ServicePSDbContext Create(string connectionString = null)
        {
            return CreateDbContext(new string[] { connectionString });
        }

        public ServicePSDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine($"ProjectPS.ServicePS.ServicePSDbContext - With arguments: {JsonConvert.SerializeObject(args)}");

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("dbsettings.json")
            .AddJsonFile($"dbsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
            .AddEnvironmentVariables()
            .Build();

            var builder = new DbContextOptionsBuilder<ServicePSDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (String.IsNullOrWhiteSpace(connectionString) == true)
            {
                throw new InvalidOperationException("Could not find a connection string named 'DefaultConnection'.");
            }

            if (args.Length > 0)
            {
                connectionString = args[0];
            }

            builder.UseSqlite(connectionString);

            return new ServicePSDbContext(builder.Options);
        }
    }
}
