using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Spell
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("level")] public int Level { get; set; }
    [JsonPropertyName("school")] public string School { get; set; } = string.Empty;
    [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
    [JsonPropertyName("castingTime")] public string CastingTime { get; set; } = string.Empty;
    [JsonPropertyName("components")] public string Components { get; set; } = string.Empty;
    [JsonPropertyName("range")] public string Range { get; set; } = string.Empty;
    [JsonPropertyName("target")] public string Target { get; set; } = string.Empty;
    [JsonPropertyName("duration")] public string Duration { get; set; } = string.Empty;
    [JsonPropertyName("save")] public string Save { get; set; } = string.Empty;
    [JsonPropertyName("sr")] public string Sr { get; set; } = string.Empty;
    [JsonPropertyName("reference")] public string Reference { get; set; } = string.Empty;
}

public class PreparedSpell
{
    [JsonPropertyName("spellName")] public string SpellName { get; set; } = string.Empty;
    [JsonPropertyName("level")] public int Level { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; } = 0;
}

public class CasterEntry
{
    [JsonPropertyName("className")] public string ClassName { get; set; } = string.Empty;
    [JsonPropertyName("ability")] public Ability Ability { get; set; } = Ability.Int;
    [JsonPropertyName("known")] public List<Spell> Known { get; set; } = new();
    [JsonPropertyName("prepared")] public List<PreparedSpell> Prepared { get; set; } = new();
    [JsonPropertyName("slots")] public Dictionary<int, int> Slots { get; set; } = new();
}

public class SpellsInfo
{
    [JsonPropertyName("casterEntries")] public List<CasterEntry> CasterEntries { get; set; } = new();
}
