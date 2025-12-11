using SampleTesting1.Samples;
using Xunit;

namespace SampleTesting1.EntityFrameworkCore.Domains;

[Collection(SampleTesting1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SampleTesting1EntityFrameworkCoreTestModule>
{

}
