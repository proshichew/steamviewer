namespace Steamviewer.Components.Shared.Services.Interfaces;
using Steamviewer.Entities;

public interface IGameService
{
    Task<IEnumerable<Game>?> GetAllGamesAsync(CancellationToken cts = default);
    Task<Game?> GetGameAsync(int id, CancellationToken cts = default);
    Task<Game?> CreateGameAsync(Game game, CancellationToken cts = default);
    Task<bool> UpdateGameAsync(int id, Game gameDto, CancellationToken cts = default);
    Task<bool> DeleteGameAsync(int id, CancellationToken cts = default);
}