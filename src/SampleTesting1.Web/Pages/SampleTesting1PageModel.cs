using SampleTesting1.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SampleTesting1.Web.Pages;

public abstract class SampleTesting1PageModel : AbpPageModel
{
    protected SampleTesting1PageModel()
    {
        LocalizationResourceType = typeof(SampleTesting1Resource);
    }
}
