using Microsoft.AspNetCore.Builder;
using SampleTesting1;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("SampleTesting1.Web.csproj"); 
await builder.RunAbpModuleAsync<SampleTesting1WebTestModule>(applicationName: "SampleTesting1.Web");

public partial class Program
{
}
