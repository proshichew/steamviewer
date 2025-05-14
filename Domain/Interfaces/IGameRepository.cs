using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<Game> UpdateGame(Game game, CancellationToken cancellationToken);
    }
}