using Steamviewer.Entities.SteamModels.AppDetails;
using Steamviewer.Entities.DTOs;
namespace Steamviewer.Entities.ComponentModels
{
    public class GameCardInfo
    {
        public GameCardInfo(AppDetails details, GameDTO dto)
        {
            if (details.success == true)
            {
                Name = details.data.name;
                HeaderImage = details.data.header_image;
                Screenshots = details.data.screenshots?
                    .Select(s => new GameScreenshot(s.path_thumbnail, s.path_full))
                    .ToList() ?? new List<GameScreenshot>();
                Description = details.data.short_description;
                FinalPriceFormatted = details.data.price_overview?.final_formatted ?? (details.data.is_free ? "Бесплатно" : "Н/Д в Вашем регионе");
                MetacriticScore = details.data.metacritic?.score;
                ReleaseDate = details.data.release_date.date;
                IsFree = details.data.is_free;
                Tags = details.data.genres?.Select(g => g.description).ToList() ?? new List<string>();
                Developers = details.data.developers ?? new List<string>();
                Publishers = details.data.publishers ?? new List<string>();
                Sale = details.data.price_overview?.discount_percent ?? 0;
                UserNote = dto.UserNote;
                SaleToNotify = dto.SaleToNotify;
                DbId = dto.Id;
                SteamId = details.data.steam_appid;
            }
            else
            {
                throw new ArgumentException("Такой игры в Steam не существует!");
            }
        }
        public int SteamId;

        public int DbId;
        public int? Sale { get; }
        public List<string> Tags { get; }          
        public List<string> Developers { get; }    
        public List<string> Publishers { get; }     
        public string Name { get; }
        public string HeaderImage { get; }  
        public List<GameScreenshot> Screenshots { get; }  
        public string Description { get; }
        public string FinalPriceFormatted { get; }
        public string InitialPriceFormatted { get; }
        public float FinalPrice { get; }
        public float InitialPrice { get; }
        public int? MetacriticScore { get; }
        public string ReleaseDate { get; }
        public bool IsFree { get; }
        public string? UserNote { get; }
        public int? SaleToNotify { get; }
    }
}