using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetGames(CancellationToken cancellationToken);
        Task<Game?> GetSteamGame(int steamId, CancellationToken cancellationToken);
        Task<Game> UpdateGame(Game game, CancellationToken cancellationToken);
    }
}