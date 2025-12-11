using Xunit;

namespace SampleTesting1.EntityFrameworkCore;

[CollectionDefinition(SampleTesting1TestConsts.CollectionDefinitionName)]
public class SampleTesting1EntityFrameworkCoreCollection : ICollectionFixture<SampleTesting1EntityFrameworkCoreFixture>
{

}
