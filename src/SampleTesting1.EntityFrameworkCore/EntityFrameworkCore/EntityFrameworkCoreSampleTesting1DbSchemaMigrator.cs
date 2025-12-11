using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleTesting1.Data;
using Volo.Abp.DependencyInjection;

namespace SampleTesting1.EntityFrameworkCore;

public class EntityFrameworkCoreSampleTesting1DbSchemaMigrator
    : ISampleTesting1DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSampleTesting1DbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SampleTesting1DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SampleTesting1DbContext>()
            .Database
            .MigrateAsync();
    }
}
