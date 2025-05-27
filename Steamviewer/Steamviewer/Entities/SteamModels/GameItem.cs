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

        // ===== поля с заглушками =====

        /// <summary>
        /// Теги игры (жанры, категории и т.п.), 
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string> { "Открытый мир", "Автоматизация", "Песочница" };

        /// <summary>
        /// Описание игры 
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = "Описание игры пока отсутствует.";

        /// <summary>
        /// Дата выхода игры — желательно ISO-формат (yyyy-MM-dd).
        /// </summary>
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Разработчик игры 
        /// </summary>
        [JsonPropertyName("developer")]
        public string Developer { get; set; } = "Неизвестный разработчик";

        /// <summary>
        /// Издатель игры 
        /// </summary>
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; } = "Неизвестный издатель";

        /// <summary>
        /// Уникальный идентификатор игры в Steam
        /// </summary>
        public int SteamID { get; set; }

        /// <summary>
        /// Заметка пользователя об игре
        /// </summary>
        public string? UserNote { get; set; } = string.Empty;

        /// <summary>
        /// Скидка, при которой уведомлять (0–100)
        /// </summary>
        public int SaleToNotify { get; set; } = 0;

        /// <summary>
        /// Список вишлистов, к которым принадлежит игра
        /// </summary>
        public List<Wishlist> Wishlists { get; set; } = new();
    }

}

