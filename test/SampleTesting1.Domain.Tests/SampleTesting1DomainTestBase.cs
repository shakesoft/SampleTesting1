using Volo.Abp.Modularity;

namespace SampleTesting1;

/* Inherit from this class for your domain layer tests. */
public abstract class SampleTesting1DomainTestBase<TStartupModule> : SampleTesting1TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
