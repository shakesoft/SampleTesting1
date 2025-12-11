using Volo.Abp.Modularity;

namespace SampleTesting1;

[DependsOn(
    typeof(SampleTesting1DomainModule),
    typeof(SampleTesting1TestBaseModule)
)]
public class SampleTesting1DomainTestModule : AbpModule
{

}
