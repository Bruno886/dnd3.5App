using System.Text.Json.Serialization;

namespace dnd3._5App.Models;

public class InventoryItem
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("qty")] public int Qty { get; set; } = 1;
    [JsonPropertyName("weight")] public double Weight { get; set; } = 0;
}
