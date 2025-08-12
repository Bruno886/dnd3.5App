using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Skill
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("ability")] public Ability Ability { get; set; } = Ability.Int;
    [JsonPropertyName("ranks")] public double Ranks { get; set; } = 0;
    [JsonPropertyName("misc")] public int Misc { get; set; } = 0;
    [JsonPropertyName("armorCheckApplies")] public bool ArmorCheckApplies { get; set; } = false;
    [JsonPropertyName("isClassSkill")] public bool IsClassSkill { get; set; } = true;
}
