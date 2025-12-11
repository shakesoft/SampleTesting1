using SampleTesting1.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SampleTesting1.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class SampleTesting1PublicPageModel : AbpPageModel
{
    protected SampleTesting1PublicPageModel()
    {
        LocalizationResourceType = typeof(SampleTesting1Resource);
    }
}
