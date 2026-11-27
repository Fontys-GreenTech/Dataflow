using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Dataflow.ResultStore;

[Description("Een soortwaarneming uit NDFF/GBIF.")]
public sealed record Waarneming
{
    // ── Herkomst ────────────────────────────────────────────────

    [JsonPropertyName("Bron")]
    [Description("Databron van de waarneming: NDFF of GBIF. Bijv. 'GBIF'.")]
    public required string Bron { get; init; }

    [JsonPropertyName("ID")]
    [Description("ID van de waarneming in de bron. Bijv. 6150302819.")]
    public required long Id { get; init; }

    [JsonPropertyName("Bronhouder")]
    [Description("Herkomst van de data binnen de originele bron. Bijv. 'Stichting Observation International'.")]
    public string? Bronhouder { get; init; }

    // ── Taxonomie ───────────────────────────────────────────────

    [JsonPropertyName("Soortgroep")]
    [Description("Nederlandse naam van de soortgroep. Bijv. 'Vaatplanten'.")]
    public string? Soortgroep { get; init; }

    [JsonPropertyName("Naam soort")]
    [Description("Nederlandse naam van de soort. Bijv. 'Venijnboom'.")]
    public string? NaamSoort { get; init; }

    [JsonPropertyName("Rijk")]
    [Description("Latijnse naam van het rijk (kingdom). Bijv. 'Plantae'.")]
    public string? Rijk { get; init; }

    [JsonPropertyName("Stam")]
    [Description("Latijnse naam van de stam (phylum). Bijv. 'Tracheophyta'.")]
    public string? Stam { get; init; }

    [JsonPropertyName("Klasse")]
    [Description("Latijnse naam van de klasse (class). Bijv. 'Pinopsida'.")]
    public string? Klasse { get; init; }

    [JsonPropertyName("Orde")]
    [Description("Latijnse naam van de orde (order). Bijv. 'Pinales'.")]
    public string? Orde { get; init; }

    [JsonPropertyName("Familie")]
    [Description("Latijnse naam van de familie (family). Bijv. 'Taxaceae'.")]
    public string? Familie { get; init; }

    [JsonPropertyName("Geslacht")]
    [Description("Latijnse naam van het geslacht (genus). Bijv. 'Taxus'.")]
    public string? Geslacht { get; init; }

    [JsonPropertyName("Soort")]
    [Description("Latijnse (wetenschappelijke) naam van de soort (species). Bijv. 'Taxus baccata'.")]
    public string? Soort { get; init; }

    // ── Locatie ─────────────────────────────────────────────────

    [JsonPropertyName("Coördinaten")]
    [Description("Positie van de waarneming in WGS84. Let op: eerst lengtegraad, dan breedtegraad.")]
    public required Coordinaten Coordinaten { get; init; }

    [JsonPropertyName("Vervaging")]
    [Description("Potentiële afwijking van de locatie, in meters. Bijv. 9.")]
    public int? VervagingMeters { get; init; }

    [JsonPropertyName("Coördinatenstelsel")]
    [Description("Manier waarop de coördinaten zijn gedocumenteerd. Bijv. 'WGS84'.")]
    public string? Coordinatenstelsel { get; init; }

    [JsonPropertyName("Gemeentegebied")]
    [Description("Gemeente waarin het organisme is waargenomen. Bijv. 'Tilburg'.")]
    public string? Gemeentegebied { get; init; }

    [JsonPropertyName("Verblijfplaats")]
    [Description("Specifieke plaats of structuur waarin of waarop het organisme zich bevindt. Bijv. 'Wandelbos, Tilburg'.")]
    public string? Verblijfplaats { get; init; }

    [JsonPropertyName("Biotoop")]
    [Description("Type leefomgeving waarin het organisme is waargenomen. Kan 'unknown' zijn.")]
    public string? Biotoop { get; init; }

    [JsonPropertyName("Substraat")]
    [Description("Materiaal of oppervlak waarop het organisme is aangetroffen. Kan 'Onbekend' zijn.")]
    public string? Substraat { get; init; }

    // ── Waarneming zelf ─────────────────────────────────────────

    [JsonPropertyName("ObservatieDatum")]
    [Description("Datum van de waarneming (formaat d-M-yyyy in de bron). Bijv. 24-1-2026.")]
    public required DateOnly ObservatieDatum { get; init; }

    [JsonPropertyName("Telonderwerp")]
    [Description("Wat er tijdens de waarneming wordt geteld. Bijv. 'Individu'.")]
    public string? Telonderwerp { get; init; }

    [JsonPropertyName("Aantal")]
    [Description("Aantal geobserveerde exemplaren van de soort. Bijv. 1.")]
    public int? Aantal { get; init; }

    [JsonPropertyName("Schaal (telmethode)")]
    [Description("Telmethode. Kan 'Onbekend' zijn.")]
    public string? SchaalTelmethode { get; init; }

    [JsonPropertyName("Protocol")]
    [Description("Manier waarop de telling is uitgevoerd. Kan 'unknown' zijn.")]
    public string? Protocol { get; init; }

    [JsonPropertyName("Waarnemingstype")]
    [Description("Hoe de soort is waargenomen. Bijv. 'Human Observation'.")]
    public string? Waarnemingstype { get; init; }

    // ── Biologische kenmerken ───────────────────────────────────

    [JsonPropertyName("Stadium")]
    [Description("Levensfase of ontwikkelingsfase van het waargenomen organisme. Bijv. 'Vegetatief'.")]
    public string? Stadium { get; init; }

    [JsonPropertyName("Sekse")]
    [Description("Geslacht van het individu. Kan 'Onbekend' zijn.")]
    public string? Sekse { get; init; }

    [JsonPropertyName("Gedrag")]
    [Description("Gedrag dat het organisme tijdens de waarneming vertoont. Kan 'Onbekend' zijn.")]
    public string? Gedrag { get; init; }

    [JsonPropertyName("Doodsoorzaak")]
    [Description("Oorzaak van dood. Bijv. 'Niet van toepassing'.")]
    public string? Doodsoorzaak { get; init; }

    [JsonPropertyName("Oorsprong")]
    [Description("Oorspronkelijke herkomst van de soort (bijv. inheems of exoot). Kan 'Onbekend' zijn.")]
    public string? Oorsprong { get; init; }

    [JsonPropertyName("Beleidsstatus")]
    [Description("Speciaal beleid dat van toepassing is op de soort, hier een IUCN-code. Bijv. 'LC' (Least Concern).")]
    public string? Beleidsstatus { get; init; }

    // ── Methode & validatie ─────────────────────────────────────

    [JsonPropertyName("Determinatiemethode")]
    [Description("Methode waarmee het organisme op soortniveau is geïdentificeerd. Kan 'Onbekend' zijn.")]
    public string? Determinatiemethode { get; init; }

    [JsonPropertyName("Zoek- of vangmethode")]
    [Description("Methode toegepast om het dier te vinden. Kan 'Onbekend' zijn.")]
    public string? ZoekOfVangmethode { get; init; }

    [JsonPropertyName("Apparatuur")]
    [Description("Apparatuur toegepast tijdens het vangen. Kan 'Onbekend' zijn.")]
    public string? Apparatuur { get; init; }

    [JsonPropertyName("Validatiestatus determinatie")]
    [Description("Of de determinatie is goedgekeurd. Bijv. 'Approved | Automated'.")]
    public string? ValidatiestatusDeterminatie { get; init; }

    [JsonPropertyName("Laatst gewijzigd")]
    [Description("Laatste moment waarop de data is aangepast, in UTC. Bijv. 24-01-2026 13:20 UTC.")]
    public DateTimeOffset? LaatstGewijzigd { get; init; }
}

[Description("Positie in WGS84. Volgorde: lengtegraad eerst, dan breedtegraad.")]
public readonly record struct Coordinaten(
    [property: Description("Longitude (lengtegraad), bijv. 5.039875")] double Lengtegraad,
    [property: Description("Latitude (breedtegraad), bijv. 51.571453")] double Breedtegraad)
{
    /// <summary>Parset "5.039875, 51.571453" (lengte, breedte).</summary>
    public static Coordinaten Parse(string s)
    {
        var parts = s.Split(',', StringSplitOptions.TrimEntries);
        return new Coordinaten(
            double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture),
            double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture));
    }
}
