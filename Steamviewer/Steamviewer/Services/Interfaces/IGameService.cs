namespace Steamviewer.Components.Shared.Services.Interfaces;
using Steamviewer.Entities.DTOs;

public interface IGameService
{
    Task<GameDTO?> GetGameAsync(int id, CancellationToken ct = default);
    Task AddGameAsync(GameDTO gameDto, CancellationToken ct = default);
    Task UpdateGameAsync(int id, GameDTO gameDto, CancellationToken ct = default);
    Task DeleteGameAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<GameDTO>> GetAllAsync(CancellationToken ct = default);
}