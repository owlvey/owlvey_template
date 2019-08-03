using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectPS.ServicePS.API;
using ProjectPS.ServicePS.Data.SQLite.Context;
using ProjectPS.ServicePS.IoC;
using ProjectPS.ServicePS.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPS.ServicePS.IntegrationTests.Setup
{
    /// <summary>
    /// Integration Test Starup
    /// </summary>
    public class TestStartup : Startup
    {

        /// <summary>
        /// Constructor Test
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="env"></param>
        public TestStartup(IConfiguration conf, IHostingEnvironment env) : base(conf, env)
        {
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <param name="services">Service Collection</param>
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddApplicationServices(Configuration);
            services.AddRepositories(Configuration);

            var connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = ":memory:"
            };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            services
                .AddEntityFrameworkSqlite()
                .AddDbContext<ServicePSDbContext>(options =>
                options.UseSqlite(connection)
            );

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">App</param>
        /// <param name="env">Env</param>
        /// <param name="loggerFactory">Logger</param>
        /// <param name="swaggerOptions">Swagger Option</param>
        /// <param name="configuration">Configuration</param>
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IOptions<SwaggerAppOptions> swaggerOptions, 
            IConfiguration configuration, ServicePSDbContext dbContext)
        {
            app.UseMvc();

            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
        }


    }

}
