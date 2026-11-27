using System;
using System.Threading.Tasks;
using Dataflow.ResultStore;
using Shouldly;

namespace Dataflow.IntegrationTests.Tests;

internal sealed class WaarnemingIntegrationTests(WaarnemingCache cache) : IntegrationTestBase
{
    [Test]
    public async Task GetWaarnemingReturnsSuccessAndSingleWaarneming()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var waarneming = new Waarneming
        {
            // Internal Fields
            Id = id,
            CreatedAt = DateTimeOffset.UtcNow,

            // Herkomst
            Bron = "GBIF",
            BronId = 6150302819,
            Bronhouder = "Stichting Observation International",

            // Taxonomie
            Soortgroep = "Vaatplanten",
            NaamSoort = "Venijnboom",
            Rijk = "Plantae",
            Stam = "Tracheophyta",
            Klasse = "Pinopsida",
            Orde = "Pinales",
            Familie = "Taxaceae",
            Geslacht = "Taxus",
            Soort = "Taxus baccata",

            // Locatie
            Coordinaten = new Coordinaten(5.039875, 51.571453),
            VervagingMeters = 9,
            Coordinatenstelsel = "WGS84",
            Gemeentegebied = "Tilburg",
            Verblijfplaats = "Wandelbos, Tilburg",
            Biotoop = "Parklandschap",
            Substraat = "Bodem",

            // Waarneming zelf
            ObservatieDatum = new DateOnly(2026, 1, 24),
            Telonderwerp = "Individu",
            Aantal = 1,
            SchaalTelmethode = "Onbekend",
            Protocol = "unknown",
            Waarnemingstype = "Human Observation",

            // Biologische kenmerken
            Stadium = "Vegetatief",
            Sekse = "Onbekend",
            Gedrag = "Onbekend",
            Doodsoorzaak = "Niet van toepassing",
            Oorsprong = "Inheems",
            Beleidsstatus = "LC",

            // Methode & validatie
            Determinatiemethode = "Visueel",
            ZoekOfVangmethode = "Visuele waarneming",
            Apparatuur = "Geen",
            ValidatiestatusDeterminatie = "Approved | Automated",
            LaatstGewijzigd = new DateTimeOffset(
                2026, 1, 24, 13, 20, 0, TimeSpan.Zero)
        };

        await cache.SetAsync(waarneming);

        // Act
        var response = await Client.GetAsync(new Uri($"/Waarneming/{id}", UriKind.Relative));

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        content.ShouldNotBeNullOrEmpty();
    }
}
