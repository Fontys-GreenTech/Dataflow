using Dataflow.ResultStore.ApplicationExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dataflow.Core.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowCore(this IServiceCollection services, IConfiguration configuration)
    {
        // Caching layer for Core -> Formatting agent
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "dataflow:";
        });

        services.AddDependencies(configuration);
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataflowResultStore(configuration);
        return services;
    }
}
