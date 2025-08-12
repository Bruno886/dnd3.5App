using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class ClassFeature
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("uses")] public int Uses { get; set; } = 0;
    [JsonPropertyName("notes")] public string Notes { get; set; } = string.Empty;
}
