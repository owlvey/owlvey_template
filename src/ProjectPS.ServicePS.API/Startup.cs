using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectPS.ServicePS.API.Extensions;
using ProjectPS.ServicePS.Data.SQLite.Context;
using ProjectPS.ServicePS.IoC;
using ProjectPS.ServicePS.Options;

namespace ProjectPS.ServicePS.API
{
    public class Startup
    {
        public Startup(IConfiguration cnfs, IHostingEnvironment env)
        {
            Configuration = cnfs;
            Environment = env;
        }

        public static IHostingEnvironment Environment { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddApplicationServices(Configuration);
            services.AddRepositories(Configuration);
            services.SetupDataBase(Configuration);
            services.AddCustomSwagger(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IOptions<SwaggerAppOptions> swaggerOptions,
            IConfiguration configuration, ServicePSDbContext dbContext)
        {
            
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = swaggerOptions.Value.Title;
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint($"{swaggerOptions.Value.Endpoint}", swaggerOptions.Value.Title);
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
