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
}
