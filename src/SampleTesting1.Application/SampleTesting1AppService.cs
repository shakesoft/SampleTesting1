using SampleTesting1.Localization;
using Volo.Abp.Application.Services;

namespace SampleTesting1;

/* Inherit your application services from this class.
 */
public abstract class SampleTesting1AppService : ApplicationService
{
    protected SampleTesting1AppService()
    {
        LocalizationResource = typeof(SampleTesting1Resource);
    }
}
