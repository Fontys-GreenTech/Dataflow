using Microsoft.Extensions.DependencyInjection;

namespace Dataflow.Caching.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowCaching(this IServiceCollection services)
    {
        services.AddDependencies();
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        return services;
    }
}
