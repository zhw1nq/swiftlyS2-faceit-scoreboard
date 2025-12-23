namespace swiftlyS2_faceit_scoreboard;

public static class Constants
{
    public const string Version = "1.0.0";
    public const string FaceitApiBaseUrl = "https://open.faceit.com/data/v4";
    
    public static readonly IReadOnlyDictionary<int, int> FaceitLevelCoins = new Dictionary<int, int>
    {
        { 1, 1088 },
        { 2, 1087 },
        { 3, 1032 },
        { 4, 1055 },
        { 5, 1041 },
        { 6, 1074 },
        { 7, 1039 },
        { 8, 1067 },
        { 9, 1061 },
        { 10, 1017 }
    }.AsReadOnly();
}
