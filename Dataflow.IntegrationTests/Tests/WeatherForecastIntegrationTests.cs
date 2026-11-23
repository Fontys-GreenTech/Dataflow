using System;
using System.Threading.Tasks;
using Shouldly;

namespace Dataflow.IntegrationTests.Tests;

internal sealed class WeatherForecastIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task GetWeatherForecastReturnsSuccessAndForecasts()
    {
        // Act
        var response = await Client.GetAsync(new Uri("/WeatherForecast", UriKind.Relative));

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        content.ShouldNotBeNullOrEmpty();
    }
}
