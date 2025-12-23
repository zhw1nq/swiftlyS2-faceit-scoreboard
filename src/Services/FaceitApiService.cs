using swiftlyS2_faceit_scoreboard.Models;
using System.Text.Json;

namespace swiftlyS2_faceit_scoreboard.Services;

public sealed class FaceitApiService : IDisposable
{
    private static HttpClient? _sharedHttpClient;
    private static readonly object _httpClientLock = new();
    
    private readonly SemaphoreSlim _rateLimiter;
    private readonly bool _useCSGO;
    
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public FaceitApiService(string apiKey, int maxConcurrentRequests, int timeoutSeconds, bool useCSGO)
    {
        _rateLimiter = new SemaphoreSlim(maxConcurrentRequests, maxConcurrentRequests);
        _useCSGO = useCSGO;
        
        InitializeHttpClient(apiKey, timeoutSeconds);
    }

    private static void InitializeHttpClient(string apiKey, int timeoutSeconds)
    {
        lock (_httpClientLock)
        {
            if (_sharedHttpClient != null)
            {
                _sharedHttpClient.DefaultRequestHeaders.Clear();
            }
            else
            {
                _sharedHttpClient = new HttpClient(new SocketsHttpHandler
                {
                    PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                    PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                    MaxConnectionsPerServer = 10
                })
                {
                    Timeout = TimeSpan.FromSeconds(timeoutSeconds)
                };
            }
            
            _sharedHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {apiKey}");
            _sharedHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
        }
    }

    public async Task<int> GetPlayerLevelAsync(ulong steamId)
    {
        if (!await _rateLimiter.WaitAsync(100).ConfigureAwait(false))
            return 0;

        try
        {
            var level = await FetchLevelAsync(steamId, "cs2").ConfigureAwait(false);

            if (level == 0 && _useCSGO)
            {
                level = await FetchLevelAsync(steamId, "csgo").ConfigureAwait(false);
            }

            return level;
        }
        finally
        {
            _rateLimiter.Release();
        }
    }

    private static async Task<int> FetchLevelAsync(ulong steamId, string game)
    {
        if (_sharedHttpClient == null)
            return 0;

        try
        {
            var url = $"{Constants.FaceitApiBaseUrl}/players?game={game}&game_player_id={steamId}";
            
            using var response = await _sharedHttpClient.GetAsync(url).ConfigureAwait(false);
            
            if (!response.IsSuccessStatusCode)
                return 0;

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            if (string.IsNullOrEmpty(json))
                return 0;

            var player = JsonSerializer.Deserialize<FaceitPlayer>(json, JsonOptions);
            
            return player?.Games?.TryGetValue(game, out var gameData) == true 
                ? gameData.SkillLevel 
                : 0;
        }
        catch
        {
            return 0;
        }
    }

    public void Dispose()
    {
        _rateLimiter.Dispose();
    }
}
