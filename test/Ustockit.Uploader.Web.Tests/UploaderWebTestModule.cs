using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ustockit.Uploader.Web.Startup;
namespace Ustockit.Uploader.Web.Tests
{
    [DependsOn(
        typeof(UploaderWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class UploaderWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UploaderWebTestModule).GetAssembly());
        }
    }
}