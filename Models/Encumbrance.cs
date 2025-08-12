using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class Encumbrance
{
    [JsonPropertyName("carryCapacityOverride")] public double? CarryCapacityOverride { get; set; }
}
