using Steamviewer.Entities.SteamModels;

namespace Steamviewer.Components.Shared.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class SteamService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "942AD2EDE97B8214A902981F56A973DB";
    private const string BaseUrl = "https://store.steampowered.com/api";

    public SteamService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SteamSearchResult> SearchGamesAsync(string searchTerm)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SteamSearchResult>(
                $"{BaseUrl}/storesearch/?term={searchTerm}&cc=us&l=english");

            if (response == null)
                return new SteamSearchResult();

            return response;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.StatusCode} - {ex.Message}");
            return new SteamSearchResult();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Parsing Error: {ex.Message}");
            return new SteamSearchResult();
        }
    }


    public async Task<GameDetails> GetGameDetailsAsync(int appId)
    {
        var response = await _httpClient.GetFromJsonAsync<GameDetails>(
            $"{BaseUrl}/appdetails?appids={appId}");
        
        return response;
    }
}