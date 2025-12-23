using System.Text.Json.Serialization;

namespace swiftlyS2_faceit_scoreboard.Models;

public sealed class PlayerData
{
    [JsonPropertyName("show")]
    public bool ShowFaceitLevel { get; set; }
    
    [JsonPropertyName("level")]
    public int FaceitLevel { get; set; }
    
    [JsonPropertyName("lastFetch")]
    public DateTime LastFetch { get; set; }
}
