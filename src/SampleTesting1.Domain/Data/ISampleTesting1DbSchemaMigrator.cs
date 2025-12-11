using System.Threading.Tasks;

namespace SampleTesting1.Data;

public interface ISampleTesting1DbSchemaMigrator
{
    Task MigrateAsync();
}
