using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<Game?> GetSteamGame(int steamId, CancellationToken cancellationToken);
        Task<Game> UpdateGame(Game game, CancellationToken cancellationToken);
    }
}