using System.Text.Json.Serialization;

namespace Steamviewer.Entities.SteamModels;

public class GameItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("tiny_image")]
    public string TinyImage { get; set; }

    [JsonPropertyName("metacritic_score")]
    public int? MetacriticScore { get; set; }

    [JsonPropertyName("price")]
    public PriceInfo Price { get; set; }
}