using Dataflow.Core.ApplicationExtensions;

using Microsoft.Extensions.DependencyInjection;

namespace Dataflow.Api.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        services.AddDependencies();
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddDataflowCore();
        return services;
    }
}
