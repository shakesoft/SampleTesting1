using SampleTesting1.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleTesting1.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SampleTesting1Controller : AbpControllerBase
{
    protected SampleTesting1Controller()
    {
        LocalizationResource = typeof(SampleTesting1Resource);
    }
}
