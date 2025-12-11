using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SampleTesting1.Data;

/* This is used if database provider does't define
 * ISampleTesting1DbSchemaMigrator implementation.
 */
public class NullSampleTesting1DbSchemaMigrator : ISampleTesting1DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
