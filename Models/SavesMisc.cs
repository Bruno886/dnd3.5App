using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class SavesMisc
{
    [JsonPropertyName("fort")] public int Fort { get; set; } = 0;
    [JsonPropertyName("ref")] public int Ref { get; set; } = 0;
    [JsonPropertyName("will")] public int Will { get; set; } = 0;
}
