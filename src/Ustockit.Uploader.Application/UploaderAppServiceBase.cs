using Abp.Application.Services;

namespace Ustockit.Uploader
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class UploaderAppServiceBase : ApplicationService
    {
        protected UploaderAppServiceBase()
        {
            LocalizationSourceName = UploaderConsts.LocalizationSourceName;
        }
    }
}