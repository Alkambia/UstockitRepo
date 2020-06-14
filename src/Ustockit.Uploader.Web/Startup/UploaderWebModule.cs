using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ustockit.Uploader.Configuration;
using Ustockit.Uploader.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Abp.Hangfire.Configuration;

namespace Ustockit.Uploader.Web.Startup
{
    [DependsOn(
        typeof(UploaderApplicationModule), 
        typeof(UploaderEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class UploaderWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public UploaderWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.UseHangfire();

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(UploaderConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<UploaderNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(UploaderApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UploaderWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(UploaderWebModule).Assembly);
        }
    }
}