using SampleTesting1.Samples;
using Xunit;

namespace SampleTesting1.EntityFrameworkCore.Applications;

[Collection(SampleTesting1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SampleTesting1EntityFrameworkCoreTestModule>
{

}
