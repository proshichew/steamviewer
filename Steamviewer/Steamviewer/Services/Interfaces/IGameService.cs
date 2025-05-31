using Steamviewer.Entities.DTOs;

namespace Steamviewer.Services.Interfaces
{
    public interface IGameService : IService<GameDTO>
    {
        Task<GameDTO?> GetGameAsync(int id, CancellationToken ct = default);
        Task AddGameAsync(GameDTO gameDto, CancellationToken ct = default);
        Task UpdateGameAsync(int id, GameDTO gameDto, CancellationToken ct = default);
        Task DeleteGameAsync(int id, CancellationToken ct = default);
    }
}
