using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SampleTesting1.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SampleTesting1DbContextFactory : IDesignTimeDbContextFactory<SampleTesting1DbContext>
{
    public SampleTesting1DbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        SampleTesting1EfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<SampleTesting1DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new SampleTesting1DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SampleTesting1.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
