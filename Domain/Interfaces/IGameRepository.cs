using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game?> GetSteamGame(int steamId);
        Task<Game> UpdateGame(Game game);
    }
}