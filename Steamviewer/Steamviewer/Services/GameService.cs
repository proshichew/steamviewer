using Steamviewer.Components.Shared.Services.Interfaces;

namespace Steamviewer.Components.Shared.Services;
using System.Net.Http.Json;
using Steamviewer.Entities;
using Microsoft.AspNetCore.Components;

    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public GameService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<IEnumerable<Game>?> GetAllGamesAsync(CancellationToken cts = default)
        {
            try
            {
                var response = await _httpClient.GetAsync("api/games", cts);
                
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return Enumerable.Empty<Game>();
                    }
                    
                    _navigationManager.NavigateTo("/error");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<Game>>(cancellationToken: cts);
            }
            catch (OperationCanceledException)
            {
                // Task was canceled, just return null
                return null;
            }
            catch (Exception)
            {
                _navigationManager.NavigateTo("/error");
                return null;
            }
        }

        public async Task<Game?> GetGameAsync(int id, CancellationToken cts = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/games/{id}", cts);
                
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    
                    _navigationManager.NavigateTo("/error");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Game>(cancellationToken: cts);
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception)
            {
                _navigationManager.NavigateTo("/error");
                return null;
            }
        }

        public async Task<Game?> CreateGameAsync(Game game, CancellationToken cts = default)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/games", game, cts);
                
                if (!response.IsSuccessStatusCode)
                {
                    _navigationManager.NavigateTo("/error");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Game>(cancellationToken: cts);
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception)
            {
                _navigationManager.NavigateTo("/error");
                return null;
            }
        }

        public async Task<bool> UpdateGameAsync(int id, Game gameDto, CancellationToken cts = default)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/games/{id}", gameDto, cts);
                
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    
                    _navigationManager.NavigateTo("/error");
                    return false;
                }

                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception)
            {
                _navigationManager.NavigateTo("/error");
                return false;
            }
        }

        public async Task<bool> DeleteGameAsync(int id, CancellationToken cts = default)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/games/{id}", cts);
                
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    
                    _navigationManager.NavigateTo("/error");
                    return false;
                }

                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception)
            {
                _navigationManager.NavigateTo("/error");
                return false;
            }
        }
    }
