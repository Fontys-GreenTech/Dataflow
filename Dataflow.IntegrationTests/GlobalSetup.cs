using System.Threading.Tasks;

using DotNet.Testcontainers.Containers;

namespace Dataflow.IntegrationTests;

[SetUpFixture]
internal sealed class GlobalSetup
{
#pragma warning disable CS0649
    private static IContainer? s_container;
#pragma warning restore CS0649

    public static string? ContainerConnectionString => s_container?.GetConnectionString();

    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        // Place for Testcontainers to be configured and started globally, e.g.:
        /*
        s_container = new ContainerBuilder()
            .WithImage("alpine:latest")
            .WithCommand("sleep", "3600")
            .Build();

        await s_container.StartAsync();
        */
        await Task.CompletedTask;
    }

    [OneTimeTearDown]
    public async Task RunAfterAnyTests()
    {
        if (s_container is not null)
        {
            await s_container.StopAsync();
            await s_container.DisposeAsync();
        }
    }
}
