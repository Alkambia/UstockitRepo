using Abp.AspNetCore.Mvc.Views;

namespace Ustockit.Uploader.Web.Views
{
    public abstract class UploaderRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected UploaderRazorPage()
        {
            LocalizationSourceName = UploaderConsts.LocalizationSourceName;
        }
    }
}
