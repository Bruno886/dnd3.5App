using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Money
{
    [JsonPropertyName("cp")] public int Cp { get; set; } = 0;
    [JsonPropertyName("sp")] public int Sp { get; set; } = 0;
    [JsonPropertyName("gp")] public int Gp { get; set; } = 0;
    [JsonPropertyName("pp")] public int Pp { get; set; } = 0;
}
