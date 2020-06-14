using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Ustockit.Uploader
{
    [DependsOn(
        typeof(UploaderCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class UploaderApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UploaderApplicationModule).GetAssembly());
        }
    }
}