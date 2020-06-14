using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Ustockit.Uploader.EntityFrameworkCore
{
    [DependsOn(
        typeof(UploaderCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class UploaderEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UploaderEntityFrameworkCoreModule).GetAssembly());
        }
    }
}