using Dataflow.Caching.ApplicationExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dataflow.Core.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDependencies(configuration);
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataflowCaching(configuration);
        return services;
    }
}
