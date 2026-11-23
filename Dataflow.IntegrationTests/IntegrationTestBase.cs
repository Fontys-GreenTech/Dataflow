using System.Net.Http;

namespace Dataflow.IntegrationTests;

internal abstract class IntegrationTestBase
{
    protected IntegrationWebApplicationFactory<Program> Factory { get; private set; } = null!;
    protected HttpClient Client { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        Factory = new IntegrationWebApplicationFactory<Program>();
        Client = Factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        Client.Dispose();
        Factory.Dispose();
    }
}
