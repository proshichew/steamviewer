using System.Text.Json.Serialization;

namespace Steamviewer.Entities.SteamModels;

public class PriceInfo
{
    [JsonPropertyName("final")]
    public double Final { get; set; }

    [JsonPropertyName("initial")]
    public double? Initial { get; set; }

    [JsonPropertyName("discount_percent")]
    public int DiscountPercent { get; set; }

    // Добавленные свойства для форматированного вывода
    public string FinalFormatted => Final == 0 ? "Бесплатно" : $"${Final:0.00}";
    public string InitialFormatted => Initial.HasValue ? $"${Initial.Value:0.00}" : "";
}
