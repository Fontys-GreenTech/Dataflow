using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeoSmart.Caching.Sqlite;

namespace Dataflow.ResultStore.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowResultStore(this IServiceCollection services, IConfiguration configuration)
    {
        var dirPath = configuration["ResultStore:CacheDirectory"] ?? Path.Join(Path.GetTempPath(), "dataflow");
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
        var cacheFilePath = Path.Join(dirPath, "cache.db");
        var cleanupInterval = int.Parse(configuration["ResultStore:CleanupIntervalInHours"]!);

        services.AddSqliteCache(options =>
            {
                options.CleanupInterval = TimeSpan.FromHours(cleanupInterval);
                options.CachePath = cacheFilePath;
            }
        );

        services.Configure<WaarnemingCacheOptions>(configuration.GetSection("ResultStore"));
        services.AddSingleton<WaarnemingCache>();

        return services;
    }
}
