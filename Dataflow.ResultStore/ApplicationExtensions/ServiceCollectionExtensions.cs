using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeoSmart.Caching.Sqlite;

namespace Dataflow.ResultStore.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowResultStore(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheFilePath = Path.Join(Path.GetTempPath(), "dataflow", "cache.db");
        var cleanupInterval = int.Parse(configuration["ResultStore:CleanupIntervalInHours"]!);

        services.AddSqliteCache(options =>
            {
                options.CleanupInterval = TimeSpan.FromHours(cleanupInterval);
                options.CachePath = cacheFilePath;
            }
        );

        return services;
    }
}
