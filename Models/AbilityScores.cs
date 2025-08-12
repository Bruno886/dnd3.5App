using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class AbilityScores
{
    [JsonPropertyName("str")] public int Str { get; set; } = 10;
    [JsonPropertyName("dex")] public int Dex { get; set; } = 10;
    [JsonPropertyName("con")] public int Con { get; set; } = 10;
    [JsonPropertyName("int")] public int Int { get; set; } = 10;
    [JsonPropertyName("wis")] public int Wis { get; set; } = 10;
    [JsonPropertyName("cha")] public int Cha { get; set; } = 10;

    public int this[Ability ability]
    {
        get => ability switch
        {
            Ability.Str => Str,
            Ability.Dex => Dex,
            Ability.Con => Con,
            Ability.Int => Int,
            Ability.Wis => Wis,
            Ability.Cha => Cha,
            _ => 0
        };
        set
        {
            switch (ability)
            {
                case Ability.Str: Str = value; break;
                case Ability.Dex: Dex = value; break;
                case Ability.Con: Con = value; break;
                case Ability.Int: Int = value; break;
                case Ability.Wis: Wis = value; break;
                case Ability.Cha: Cha = value; break;
            }
        }
    }
}
