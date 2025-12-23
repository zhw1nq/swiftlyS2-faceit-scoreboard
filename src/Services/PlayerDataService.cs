using swiftlyS2_faceit_scoreboard.Models;
using System.Collections.Concurrent;
using System.Text.Json;

namespace swiftlyS2_faceit_scoreboard.Services;

public sealed class PlayerDataService : IDisposable
{
    private readonly string _dataPath;
    private readonly ConcurrentDictionary<ulong, PlayerData> _playerData = new();
    private readonly SemaphoreSlim _fileLock = new(1, 1);
    
    private volatile bool _hasDirtyData;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public PlayerDataService(string dataPath)
    {
        _dataPath = dataPath;
    }

    public PlayerData GetOrCreate(ulong steamId, bool defaultShowStatus)
    {
        return _playerData.GetOrAdd(steamId, _ => new PlayerData
        {
            ShowFaceitLevel = defaultShowStatus,
            FaceitLevel = 0,
            LastFetch = DateTime.MinValue
        });
    }

    public bool TryGetPlayer(ulong steamId, out PlayerData? data)
    {
        return _playerData.TryGetValue(steamId, out data);
    }

    public void MarkDirty()
    {
        _hasDirtyData = true;
    }

    public int Count => _playerData.Count;

    public void SaveIfDirty()
    {
        if (!_hasDirtyData)
            return;

        _hasDirtyData = false;
        _ = SaveAsync();
    }

    public async Task LoadAsync()
    {
        if (!File.Exists(_dataPath))
            return;

        var json = await File.ReadAllTextAsync(_dataPath).ConfigureAwait(false);
        
        if (string.IsNullOrEmpty(json))
            return;

        var data = JsonSerializer.Deserialize<Dictionary<ulong, PlayerData>>(json, JsonOptions);

        if (data == null)
            return;

        foreach (var (steamId, playerData) in data)
        {
            _playerData.TryAdd(steamId, playerData);
        }
    }

    public async Task SaveAsync()
    {
        if (!await _fileLock.WaitAsync(1000).ConfigureAwait(false))
            return;

        try
        {
            var directory = Path.GetDirectoryName(_dataPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var snapshot = _playerData.ToDictionary(
                kvp => kvp.Key, 
                kvp => new PlayerData
                {
                    ShowFaceitLevel = kvp.Value.ShowFaceitLevel,
                    FaceitLevel = kvp.Value.FaceitLevel,
                    LastFetch = kvp.Value.LastFetch
                }
            );

            var json = JsonSerializer.Serialize(snapshot, JsonOptions);
            await File.WriteAllTextAsync(_dataPath, json).ConfigureAwait(false);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public void Dispose()
    {
        _fileLock.Dispose();
    }
}
