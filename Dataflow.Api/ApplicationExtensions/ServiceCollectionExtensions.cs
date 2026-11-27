using Dataflow.Core.ApplicationExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dataflow.Api.ApplicationExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataflowApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();

        services.AddDependencies(configuration);
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataflowCore(configuration);
        return services;
    }
}
