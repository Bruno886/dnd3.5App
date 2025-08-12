using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class SaveProgressionSet
{
    [JsonPropertyName("fort")] public SaveProgression Fort { get; set; } = SaveProgression.Poor;
    [JsonPropertyName("ref")] public SaveProgression Ref { get; set; } = SaveProgression.Poor;
    [JsonPropertyName("will")] public SaveProgression Will { get; set; } = SaveProgression.Poor;
}

public class ClassLevel
{
    [JsonPropertyName("className")] public string ClassName { get; set; } = string.Empty;
    [JsonPropertyName("level")] public int Level { get; set; } = 1;
    [JsonPropertyName("babProgression")] public BabProgression BabProgression { get; set; } = BabProgression.Full;
    [JsonPropertyName("saveProgression")] public SaveProgressionSet SaveProgression { get; set; } = new();
    [JsonPropertyName("hitDie")] public HitDie HitDie { get; set; } = HitDie.D8;
    [JsonPropertyName("classSkills")] public List<string> ClassSkills { get; set; } = new();
    [JsonPropertyName("simpleWeapons")] public bool SimpleWeapons { get; set; } = false;
    [JsonPropertyName("martialWeapons")] public bool MartialWeapons { get; set; } = false;
    [JsonPropertyName("weaponProficiencies")] public string? WeaponProficiencies { get; set; } = string.Empty;
    [JsonPropertyName("lightArmor")] public bool LightArmor { get; set; } = false;
    [JsonPropertyName("mediumArmor")] public bool MediumArmor { get; set; } = false;
    [JsonPropertyName("heavyArmor")] public bool HeavyArmor { get; set; } = false;
    [JsonPropertyName("armorProficiencies")] public string? ArmorProficiencies { get; set; } = string.Empty;
    [JsonPropertyName("shields")] public bool Shields { get; set; } = false;
    [JsonPropertyName("towerShields")] public bool TowerShields { get; set; } = false;
}
