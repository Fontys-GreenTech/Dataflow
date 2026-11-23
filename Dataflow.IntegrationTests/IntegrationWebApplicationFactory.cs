using System.Collections.Generic;

using Dataflow.Api.ApplicationExtensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Dataflow.IntegrationTests;

internal sealed class IntegrationWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        builder.ConfigureAppConfiguration((context, config) =>
        {
            var testConfig = new Dictionary<string, string?>
            {
                // Add test-specific configuration overrides here or use Testcontainers connection strings
            };
            config.AddInMemoryCollection(testConfig);
        });

        builder.ConfigureServices(services =>
        {
            // Add required services (like the ones in Dataflow.Api/ApplicationExtensions/ServiceCollectionExtensions.cs)
            services.AddDataflowApi();
        });
    }
}
