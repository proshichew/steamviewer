using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Steamviewer.Entities.SteamModels.TopGame
{
    public class TopGame
    {
        [JsonProperty("appid")]
        public int AppId { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("developer")]
        public required string Dev { get; set; }

        [JsonProperty("publisher")]
        public required string Publisher { get; set; }

        [JsonProperty("score_rank")]
        public string? Score { get; set; }

        [JsonProperty("positive")]
        public required int PositiveReviews{ get; set; }

        [JsonProperty("negative")]
        public required int NegativeReviews{ get; set; }

        [JsonProperty("userscore")]
        public int? UserScore { get; set; }

        [JsonProperty("owners")]
        public string OwnersRange { get; set; }

        [JsonProperty("average_forever")]
        public int AvgForever { get; set; }

        [JsonProperty("average_2weeks")]
        public int AvgTwoWeeks { get; set; }

        [JsonProperty("median_forever")]
        public int MedianForever { get; set; }

        [JsonProperty("median_2weeks")]
        public int MedianTwoWeeks { get; set; }

        [JsonProperty("price")]
        public required string Price { get; set; }

        [JsonProperty("initialprice")]
        public required string InitialPrice { get; set; }

        [JsonProperty("discount")]
        public string? discount { get; set; }

        [JsonProperty("ccu")]
        public int ConcurrentPlayers { get; set; }
    }
}
