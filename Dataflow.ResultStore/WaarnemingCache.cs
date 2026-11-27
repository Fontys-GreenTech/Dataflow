using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Dataflow.ResultStore;

public class WaarnemingCache
{
    private static DistributedCacheEntryOptions _entryOptions = null!;
    private static DistributedCacheEntryOptions EntryOptions => _entryOptions;

    private IDistributedCache _cache;

    public WaarnemingCache(IDistributedCache cache, IOptions<WaarnemingCacheOptions> options)
    {
        var expirationTime = options.Value.ExpirationTimeInHours;
        _entryOptions = new()
        {
            SlidingExpiration = TimeSpan.FromHours(expirationTime) // Expires after not being used for N hours
        };
        _cache = cache;
    }

    private static string Key(Guid id) => $"entity:{id}";

    public Task SetAsync(Waarneming waarneming, CancellationToken ct = default) =>
        _cache.SetAsync(Key(waarneming.Id), JsonSerializer.SerializeToUtf8Bytes(waarneming), EntryOptions, ct);

    public async Task<Waarneming?> GetAsync(Guid id, CancellationToken ct = default)
    {
        var bytes = await _cache.GetAsync(Key(id), ct);
        return bytes is null ? null : JsonSerializer.Deserialize<Waarneming>(bytes);
    }

    public Task RemoveAsync(Guid id, CancellationToken ct = default) =>
        _cache.RemoveAsync(Key(id), ct);
}
