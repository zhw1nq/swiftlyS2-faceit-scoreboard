using System.Text.Json.Serialization;

namespace swiftlyS2_faceit_scoreboard.Models;

public sealed class FaceitPlayer
{
    [JsonPropertyName("games")]
    public Dictionary<string, GameData>? Games { get; set; }
}

public sealed class GameData
{
    [JsonPropertyName("skill_level")]
    public int SkillLevel { get; set; }
}
