using System.Text.Json.Serialization;

namespace swiftlyS2_faceit_scoreboard.Models;

public sealed class FaceitConfig
{
    [JsonPropertyName("ApiKey")]
    public string ApiKey { get; set; } = "";

    [JsonPropertyName("UseCSGO")]
    public bool UseCSGO { get; set; } = false;

    [JsonPropertyName("DefaultStatus")]
    public bool DefaultStatus { get; set; } = true;

    [JsonPropertyName("EnableToggleCommand")]
    public bool EnableToggleCommand { get; set; } = true;

    [JsonPropertyName("CacheExpiryHours")]
    public int CacheExpiryHours { get; set; } = 24;

    [JsonPropertyName("MaxConcurrentRequests")]
    public int MaxConcurrentRequests { get; set; } = 3;

    [JsonPropertyName("RequestTimeoutSeconds")]
    public int RequestTimeoutSeconds { get; set; } = 8;

    [JsonPropertyName("AutoSaveIntervalSeconds")]
    public int AutoSaveIntervalSeconds { get; set; } = 120;
}
