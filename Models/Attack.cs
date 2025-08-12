using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Attack
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("weapon")] public string Weapon { get; set; } = string.Empty;
    [JsonPropertyName("enhancement")] public int Enhancement { get; set; } = 0;
    [JsonPropertyName("damage")] public string Damage { get; set; } = string.Empty;
    [JsonPropertyName("crit")] public string Crit { get; set; } = string.Empty;
    [JsonPropertyName("rangeIncrement")] public int? RangeIncrement { get; set; }
}
