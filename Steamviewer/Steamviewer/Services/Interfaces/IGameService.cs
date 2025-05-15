namespace Steamviewer.Components.Shared.Services.Interfaces;
using Steamviewer.Entities;

public interface IGameService
{
    Task<Game?> GetGameAsync(int id, CancellationToken ct = default);
    Task AddGameAsync(Game gameDto, CancellationToken ct = default);
    Task UpdateGameAsync(int id, Game gameDto, CancellationToken ct = default);
    Task DeleteGameAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct = default);
}