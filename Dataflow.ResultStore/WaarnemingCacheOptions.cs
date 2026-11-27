namespace Dataflow.ResultStore;

public record WaarnemingCacheOptions
{
    public required int CleanupIntervalInHours { get; set; }
    public required int ExpirationTimeInHours  { get; set; }
    public string? CacheDirectory { get; set; }
}
