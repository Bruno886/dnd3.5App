using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Character
{
    [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("race")] public string Race { get; set; } = string.Empty;
    [JsonPropertyName("classLevels")] public List<ClassLevel> ClassLevels { get; set; } = new();
    [JsonPropertyName("alignment")] public string Alignment { get; set; } = string.Empty;
    [JsonPropertyName("size")] public SizeCategory Size { get; set; } = SizeCategory.Medium;
    [JsonPropertyName("deity")] public string? Deity { get; set; } = string.Empty;

    [JsonPropertyName("speedBase")] public int SpeedBase { get; set; } = 30;
    [JsonPropertyName("abilities")] public AbilityScores Abilities { get; set; } = new();
    [JsonPropertyName("abilityTempMods")] public AbilityScores AbilityTempMods { get; set; } = new();
    [JsonPropertyName("hp")] public HpInfo Hp { get; set; } = new();
    [JsonPropertyName("ac")] public AcInfo Ac { get; set; } = new();
    [JsonPropertyName("initiativeMisc")] public int InitiativeMisc { get; set; } = 0;
    [JsonPropertyName("savesMisc")] public SavesMisc SavesMisc { get; set; } = new();
    [JsonPropertyName("attacks")] public List<Attack> Attacks { get; set; } = new();
    [JsonPropertyName("grappleMisc")] public int GrappleMisc { get; set; } = 0;
    [JsonPropertyName("skills")] public List<Skill> Skills { get; set; } = new();
    [JsonPropertyName("feats")] public List<Feat> Feats { get; set; } = new();
    [JsonPropertyName("traits")] public List<string> Traits { get; set; } = new();
    [JsonPropertyName("classFeatures")] public List<ClassFeature> ClassFeatures { get; set; } = new();
    [JsonPropertyName("languages")] public List<string> Languages { get; set; } = new();
    [JsonPropertyName("equipment")] public List<EquipmentItem> Equipment { get; set; } = new();
    [JsonPropertyName("inventory")] public List<InventoryItem> Inventory { get; set; } = new();
    [JsonPropertyName("money")] public Money Money { get; set; } = new();
    [JsonPropertyName("encumbrance")] public Encumbrance Encumbrance { get; set; } = new();
    [JsonPropertyName("spells")] public SpellsInfo Spells { get; set; } = new();
    [JsonPropertyName("notes")] public string Notes { get; set; } = string.Empty;

    [JsonIgnore]
    public int Level => ClassLevels.Sum(c => c.Level);
}
