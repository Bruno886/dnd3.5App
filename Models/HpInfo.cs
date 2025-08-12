using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class HpInfo
{
    [JsonPropertyName("rolled")] public List<int> Rolled { get; set; } = new();
    [JsonPropertyName("bonusPerLevel")] public int BonusPerLevel { get; set; } = 0;
    [JsonPropertyName("misc")] public int Misc { get; set; } = 0;
    [JsonPropertyName("current")] public int Current { get; set; } = 0;
    [JsonPropertyName("nonlethal")] public int Nonlethal { get; set; } = 0;
}
