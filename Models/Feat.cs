using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Feat
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("notes")] public string Notes { get; set; } = string.Empty;
}
