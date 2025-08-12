using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class EquipmentItem
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("qty")] public int Qty { get; set; } = 1;
    [JsonPropertyName("weight")] public double Weight { get; set; } = 0;
    [JsonPropertyName("slot")] public string Slot { get; set; } = string.Empty;
    [JsonPropertyName("acBonus")] public int AcBonus { get; set; } = 0;
    [JsonPropertyName("armorCheckPenalty")] public int ArmorCheckPenalty { get; set; } = 0;
    [JsonPropertyName("maxDex")] public int? MaxDex { get; set; }
}
