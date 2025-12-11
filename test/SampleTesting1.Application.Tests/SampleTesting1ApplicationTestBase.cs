using Volo.Abp.Modularity;

namespace SampleTesting1;

public abstract class SampleTesting1ApplicationTestBase<TStartupModule> : SampleTesting1TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
