using Steamviewer.Components.Shared.Services.Interfaces;

namespace Steamviewer.Components.Shared.Services;
using System.Net.Http.Json;
using Steamviewer.Entities;
using Microsoft.AspNetCore.Components;

public class GameService : IGameService
{
    private readonly HttpClient _httpClient;

    public GameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Game?> GetGameAsync(int id, CancellationToken ct = default)
    {
        return await _httpClient.GetFromJsonAsync<Game>($"api/Games/{id}", ct);
    }

    public async Task AddGameAsync(Game gameDto, CancellationToken ct = default)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Games", gameDto, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateGameAsync(int id, Game gameDto, CancellationToken ct = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Games/{id}", gameDto, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteGameAsync(int id, CancellationToken ct = default)
    {
        var response = await _httpClient.DeleteAsync($"api/Games/{id}", ct);
        response.EnsureSuccessStatusCode();
    }
}
}
