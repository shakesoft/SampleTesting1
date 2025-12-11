using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SampleTesting1.Pages;

[Collection(SampleTesting1TestConsts.CollectionDefinitionName)]
public class Index_Tests : SampleTesting1WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
