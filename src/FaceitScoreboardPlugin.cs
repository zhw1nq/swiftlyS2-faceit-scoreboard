using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Commands;
using SwiftlyS2.Shared.GameEventDefinitions;
using SwiftlyS2.Shared.GameEvents;
using SwiftlyS2.Shared.Misc;
using SwiftlyS2.Shared.Players;
using SwiftlyS2.Shared.Plugins;
using SwiftlyS2.Shared.SchemaDefinitions;
using swiftlyS2_faceit_scoreboard.Models;
using swiftlyS2_faceit_scoreboard.Services;
using System.Collections.Concurrent;

namespace swiftlyS2_faceit_scoreboard;

[PluginMetadata(
    Id = "swiftlyS2_faceit_scoreboard",
    Version = Constants.Version,
    Name = "SwiftlyS2 FaceIT Scoreboard",
    Author = "zhw1nq",
    Description = "Displays FaceIT levels on the scoreboard – know who's carrying in a blink. [For SwiftlyS2]"
)]
public sealed partial class FaceitScoreboardPlugin : BasePlugin
{
    private FaceitConfig _config = new();
    private FaceitApiService? _apiService;
    private PlayerDataService? _dataService;
    private readonly ConcurrentDictionary<ulong, byte> _processingPlayers = new();
    private CancellationTokenSource? _saveTimerToken;

    public FaceitScoreboardPlugin(ISwiftlyCore core) : base(core) { }

    public override void ConfigureSharedInterface(IInterfaceManager interfaceManager) { }

    public override void UseSharedInterface(IInterfaceManager interfaceManager) { }

    public override void Load(bool hotReload)
    {
        LoadConfiguration();
        InitializeServices();
        RegisterEvents();
        
        Core.Logger.LogInformation("[FaceIT] v{Version} loaded successfully", Constants.Version);
    }

    public override void Unload()
    {
        UnregisterEvents();
        _saveTimerToken?.Cancel();
        _saveTimerToken = null;
        _dataService?.SaveIfDirty();
        _apiService?.Dispose();
        _dataService?.Dispose();
    }

    private void LoadConfiguration()
    {
        Core.Configuration
            .InitializeWithTemplate("config.jsonc", "config.template.jsonc")
            .Configure(builder =>
            {
                builder.AddJsonFile("config.jsonc", optional: false, reloadOnChange: true);
            });

        var services = new ServiceCollection();
        services.AddSwiftly(Core)
            .AddOptionsWithValidateOnStart<FaceitConfig>()
            .BindConfiguration("FaceIT");

        using var provider = services.BuildServiceProvider();
        _config = provider.GetRequiredService<IOptionsMonitor<FaceitConfig>>().CurrentValue;

        if (string.IsNullOrEmpty(_config.ApiKey))
        {
            Core.Logger.LogWarning("[FaceIT] API key is not configured! Plugin will not fetch levels.");
        }
    }

    private void InitializeServices()
    {
        _apiService = new FaceitApiService(
            _config.ApiKey,
            _config.MaxConcurrentRequests,
            _config.RequestTimeoutSeconds,
            _config.UseCSGO
        );

        var dataPath = Path.Combine(Core.PluginDataDirectory, "faceit_cache.json");
        _dataService = new PlayerDataService(dataPath);
        
        _ = LoadCachedDataAsync();

        if (_config.AutoSaveIntervalSeconds > 0)
        {
            _saveTimerToken = Core.Scheduler.RepeatBySeconds(
                _config.AutoSaveIntervalSeconds, 
                () => _dataService?.SaveIfDirty()
            );
        }
    }

    private async Task LoadCachedDataAsync()
    {
        try
        {
            await _dataService!.LoadAsync().ConfigureAwait(false);
            Core.Logger.LogInformation("[FaceIT] Loaded {Count} cached player records", _dataService.Count);
        }
        catch (Exception ex)
        {
            Core.Logger.LogWarning("[FaceIT] Error loading cache: {Error}", ex.Message);
        }
    }

    private void RegisterEvents() => Core.Event.OnTick += OnTick;

    private void UnregisterEvents() => Core.Event.OnTick -= OnTick;

    [GameEventHandler(HookMode.Post)]
    public HookResult OnPlayerConnectFull(EventPlayerConnectFull @event)
    {
        var player = @event.Accessor.GetPlayer("userid");
        if (player == null || player.IsFakeClient)
            return HookResult.Continue;

        var steamId = player.SteamID;
        var playerData = _dataService!.GetOrCreate(steamId, _config.DefaultStatus);

        if (ShouldFetchLevel(playerData))
        {
            _ = FetchPlayerLevelAsync(steamId);
        }

        return HookResult.Continue;
    }

    [GameEventHandler(HookMode.Post)]
    public HookResult OnPlayerDisconnect(EventPlayerDisconnect @event)
    {
        var player = @event.Accessor.GetPlayer("userid");
        if (player != null && !player.IsFakeClient)
        {
            _dataService?.MarkDirty();
            _processingPlayers.TryRemove(player.SteamID, out _);
        }

        return HookResult.Continue;
    }

    private void OnTick()
    {
        foreach (var player in Core.PlayerManager.GetAllPlayers())
        {
            if (!player.IsValid || player.IsFakeClient)
                continue;

            if (_dataService!.TryGetPlayer(player.SteamID, out var data) && 
                data != null &&
                data.ShowFaceitLevel && 
                data.FaceitLevel > 0)
            {
                ApplyPlayerCoin(player, data.FaceitLevel);
            }
        }
    }

    [Command("faceit")]
    [CommandAlias("fl")]
    public void OnFaceitCommand(ICommandContext context)
    {
        if (!context.IsSentByPlayer || context.Sender == null)
            return;

        var player = context.Sender;

        if (!_config.EnableToggleCommand)
        {
            player.SendChat($"{Core.Localizer["prefix"]}{Core.Localizer["command_disabled"]}");
            return;
        }

        HandleFaceitToggle(player);
    }

    private void HandleFaceitToggle(IPlayer player)
    {
        var steamId = player.SteamID;
        var playerData = _dataService!.GetOrCreate(steamId, _config.DefaultStatus);

        playerData.ShowFaceitLevel = !playerData.ShowFaceitLevel;
        _dataService.MarkDirty();

        if (playerData.ShowFaceitLevel)
        {
            player.SendChat($"{Core.Localizer["prefix"]}{Core.Localizer["level_enabled"]}");
            
            if (playerData.FaceitLevel > 0)
            {
                ApplyPlayerCoin(player, playerData.FaceitLevel);
                player.SendChat($"{Core.Localizer["prefix"]}{Core.Localizer["level_info", playerData.FaceitLevel]}");
            }
            else if (ShouldFetchLevel(playerData))
            {
                player.SendChat($"{Core.Localizer["prefix"]}{Core.Localizer["fetching"]}");
                _ = FetchPlayerLevelAsync(steamId);
            }
        }
        else
        {
            player.SendChat($"{Core.Localizer["prefix"]}{Core.Localizer["level_disabled"]}");
            RemovePlayerCoin(player);
        }
    }

    private bool ShouldFetchLevel(PlayerData playerData)
    {
        if (string.IsNullOrEmpty(_config.ApiKey))
            return false;
            
        return playerData.FaceitLevel == 0 ||
               DateTime.UtcNow - playerData.LastFetch > TimeSpan.FromHours(_config.CacheExpiryHours);
    }

    private async Task FetchPlayerLevelAsync(ulong steamId)
    {
        if (!_processingPlayers.TryAdd(steamId, 0))
            return;

        try
        {
            if (!_dataService!.TryGetPlayer(steamId, out var playerData) || playerData == null)
                return;

            var level = await _apiService!.GetPlayerLevelAsync(steamId).ConfigureAwait(false);

            playerData.FaceitLevel = level;
            playerData.LastFetch = DateTime.UtcNow;
            _dataService.MarkDirty();
        }
        catch (Exception ex)
        {
            Core.Logger.LogDebug("[FaceIT] Error fetching level for {SteamId}: {Error}", steamId, ex.Message);
        }
        finally
        {
            _processingPlayers.TryRemove(steamId, out _);
        }
    }

    private void ApplyPlayerCoin(IPlayer player, int faceitLevel)
    {
        try
        {
            var controller = player.Controller;
            var inventoryServices = controller?.InventoryServices;
            
            if (inventoryServices == null)
                return;

            if (!Constants.FaceitLevelCoins.TryGetValue(faceitLevel, out var coinId) || coinId == 0)
                return;

            for (var i = 0; i < 6; i++)
            {
                inventoryServices.Rank[i] = (MedalRank_t)0;
            }

            inventoryServices.Rank[5] = (MedalRank_t)coinId;
            controller!.InventoryServicesUpdated();
        }
        catch (Exception ex)
        {
            Core.Logger.LogDebug("[FaceIT] Error applying coin: {Error}", ex.Message);
        }
    }

    private void RemovePlayerCoin(IPlayer player)
    {
        try
        {
            var controller = player.Controller;
            var inventoryServices = controller?.InventoryServices;
            
            if (inventoryServices == null)
                return;

            inventoryServices.Rank[5] = (MedalRank_t)0;
            controller!.InventoryServicesUpdated();
        }
        catch (Exception ex)
        {
            Core.Logger.LogDebug("[FaceIT] Error removing coin: {Error}", ex.Message);
        }
    }
}
