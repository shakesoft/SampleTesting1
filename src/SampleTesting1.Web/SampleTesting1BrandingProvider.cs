using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using SampleTesting1.Localization;

namespace SampleTesting1.Web;

[Dependency(ReplaceServices = true)]
public class SampleTesting1BrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SampleTesting1Resource> _localizer;

    public SampleTesting1BrandingProvider(IStringLocalizer<SampleTesting1Resource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
