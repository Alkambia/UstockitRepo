using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Ustockit.Uploader.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Ustockit.Uploader.Web.Infrastructure.Ext;
using Hangfire;

namespace Ustockit.Uploader.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;
        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            services.AddAbpDbContext<UploaderDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddNewtonsoftJson();

            if (bool.Parse(_appConfiguration["Abp:Hangfire:IsServerEnabled"]))
            {
                //Hangfire (Enable to use Hangfire instead of default job manager)
                services.AddHangfire(config =>
                {
                    var connectionStringName = "Default";
                    try
                    {
                        connectionStringName = _appConfiguration["Abp:Hangfire:ConnectionString"];
                        if (String.IsNullOrEmpty(connectionStringName))
                        {
                            connectionStringName = "Default";
                        }
                    }
                    catch (Exception)
                    {
                        //supress & fall-back on "Default"
                        //TODO : log exception to logger
                        connectionStringName = "Default";
                    }

                    config.UseSqlServerStorage(_appConfiguration.GetConnectionString(connectionStringName));
                });
            }

            //Configure Abp and Dependency Injection
            return services.AddAbp<UploaderWebModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); //Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            //Hangfire dashboard & server (Enable to use Hangfire instead of default job manager)
            if (bool.Parse(_appConfiguration["Abp:Hangfire:IsDashboardEnabled"]))
            {
                //todo: Authorization Filter will be added later
                app.UseHangfireDashboard();
            }

            if (bool.Parse(_appConfiguration["Abp:Hangfire:IsServerEnabled"]))
            {
                //todo: Implement Queue priority when more than one job
                //todo: Domain Service can also be implemented if highest priority wont work.
                app.UseHangfireServer();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
