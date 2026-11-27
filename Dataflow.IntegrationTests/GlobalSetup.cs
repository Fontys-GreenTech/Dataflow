using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace Dataflow.IntegrationTests;

[SetUpFixture]
internal sealed class GlobalSetup
{
#pragma warning disable CS0649
    private static IContainer? s_redis;
#pragma warning restore CS0649

    public static string? RedisConnectionString => $"localhost:{s_redis!.GetMappedPublicPort(6379)}";

    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        // Place for Testcontainers to be configured and started globally, e.g.:

        s_redis = new ContainerBuilder("redis:8.12.0-alpine3.23")
            .WithPortBinding(6379, true)
            .Build();

        await s_redis.StartAsync();

        await Task.CompletedTask;
    }

    [OneTimeTearDown]
    public async Task RunAfterAnyTests()
    {
        if (s_redis is not null)
        {
            await s_redis.StopAsync();
            await s_redis.DisposeAsync();
        }
    }
}
