using Steamviewer.Components.Shared.Services.Interfaces;

namespace Steamviewer.Components.Shared.Services;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Steamviewer.Entities.DTOs;

public class GameService : IGameService
{
    private readonly HttpClient _httpClient;

    public GameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GameDTO?> GetGameAsync(int id, CancellationToken ct = default)
    {
        return await _httpClient.GetFromJsonAsync<GameDTO>($"api/Games/{id}", ct);
    }

    public async Task AddGameAsync(GameDTO gameDto, CancellationToken ct = default)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Games", gameDto, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateGameAsync(int id, GameDTO gameDto, CancellationToken ct = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Games/{id}", gameDto, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteGameAsync(int id, CancellationToken ct = default)
    {
        var response = await _httpClient.DeleteAsync($"api/games/{id}", ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<GameDTO>> GetAllAsync(CancellationToken cts = default)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<GameDTO>>("api/games", cts);
    }

}