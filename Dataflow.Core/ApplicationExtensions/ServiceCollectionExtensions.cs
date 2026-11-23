using Dataflow.Caching.ApplicationExtensions;

using Microsoft.Extensions.DependencyInjection;

namespace Dataflow.Core.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowCore(this IServiceCollection services)
    {
        services.AddDependencies();
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddDataflowCaching();
        return services;
    }
}