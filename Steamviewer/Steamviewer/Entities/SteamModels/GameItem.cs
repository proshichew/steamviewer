using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Steamviewer.Entities.SteamModels
{
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

        // Это класс, который полностью должен повторять JSON-запрос с стим апи. Тут не должно быть сторонней информации, поэтому
        // я подвязал карточку игры к новому классу, который состоит из результата запроса JSON и нашим писаным бэкенд-классом.
        // завтра (28.05) буду пороться чтобы всё было
    }

}

