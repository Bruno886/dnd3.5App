using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class AcInfo
{
    [JsonPropertyName("armorBonus")] public int ArmorBonus { get; set; } = 0;
    [JsonPropertyName("shieldBonus")] public int ShieldBonus { get; set; } = 0;
    [JsonPropertyName("naturalArmor")] public int NaturalArmor { get; set; } = 0;
    [JsonPropertyName("deflection")] public int Deflection { get; set; } = 0;
    [JsonPropertyName("dodge")] public int Dodge { get; set; } = 0;
    [JsonPropertyName("misc")] public int Misc { get; set; } = 0;
    [JsonPropertyName("armorCheckPenalty")] public int ArmorCheckPenalty { get; set; } = 0;
    [JsonPropertyName("maxDex")] public int? MaxDex { get; set; }
}
