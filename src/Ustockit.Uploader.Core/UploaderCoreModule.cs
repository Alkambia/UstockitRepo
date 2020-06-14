using Abp.Modules;
using Abp.Reflection.Extensions;
using Ustockit.Uploader.Localization;

namespace Ustockit.Uploader
{
    public class UploaderCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            UploaderLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UploaderCoreModule).GetAssembly());
        }
    }
}