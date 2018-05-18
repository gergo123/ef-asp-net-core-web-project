using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using AutoMapper;
using Db3.RLS;
using Db3.Model;
using Db3.Repositories.RLS;
using Db3.Utils;
using Db3.Repositories;
using Db3.SecureRepository.PlaceHolder;

namespace Web1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddAutoMapper();
            services.AddMvc();

            services.AddScoped(_ => new ConnectionStringProvider(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<CurrentUserProvider>();
            services.AddScoped<DbContext, CoreContext>();
            services.AddScoped<IUserSecurityObjectsHandler, UserSecurityObjectsHandler>();

            // Security stuff
            services.AddScoped<SecurityIdentityRepository, SecurityIdentityRepository>();
            services.AddScoped<SecurityGroupRepository>();
            services.AddScoped<PermissionService>();

            services.AddScoped<ISimplePlaceholderRepository, SimplePlaceholderRepository>();
            services.AddScoped<IPlaceholderSecureRepository, PlaceholderSecureRepository>();

            services.AddScoped<IPlaceholderACLRepository, PlaceholderACLRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseMiddleware<SecurityMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
