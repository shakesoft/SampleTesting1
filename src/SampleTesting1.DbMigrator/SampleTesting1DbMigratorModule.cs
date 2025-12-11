using SampleTesting1.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SampleTesting1.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SampleTesting1EntityFrameworkCoreModule),
    typeof(SampleTesting1ApplicationContractsModule)
)]
public class SampleTesting1DbMigratorModule : AbpModule
{
}
