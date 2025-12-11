using Volo.Abp.Modularity;

namespace SampleTesting1;

[DependsOn(
    typeof(SampleTesting1ApplicationModule),
    typeof(SampleTesting1DomainTestModule)
)]
public class SampleTesting1ApplicationTestModule : AbpModule
{

}
