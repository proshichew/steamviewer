using Steamviewer.Entities.SteamModels;
using Steamviewer.Entities.SteamModels.AppDetails;
using Steamviewer.Entities.SteamModels.TopGame;


namespace Steamviewer.Components.Shared.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SteamService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "nvm";
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
    }


    public async Task<GameDetails> GetGameDetailsAsync(int appId)
    {
        var response = await _httpClient.GetFromJsonAsync<GameDetails>(
            $"{BaseUrl}/appdetails?appids={appId}");
        
        return response;
    }

    public async Task<AppDetails> GetAppDataAsync(int appId, int maxRetries = 3)
    {
        int retryCount = 0;
        while (true)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{BaseUrl}/appdetails?appids={appId}&cc=ru&l=ru");
                var result = JsonConvert.DeserializeObject<Dictionary<string, AppDetails>>(response).Values.FirstOrDefault();
                return result;
            }
            catch (Newtonsoft.Json.JsonSerializationException ex) when (retryCount < maxRetries - 1)
            {
                retryCount++;
                Console.WriteLine($"Ошибка десериализации (попытка {retryCount} из {maxRetries}). Ошибка: {ex.Message}");

                Task.Delay(1000 * retryCount).Wait();
            }
        }
    }

    public async Task<IEnumerable<TopGame>> GetTop100Games()
    {
        var response = await _httpClient.GetStringAsync($"https://steamspy.com/api.php?request=top100in2weeks");

        var result = JsonConvert.DeserializeObject<Dictionary<string, TopGame>>(response);

        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);
        Console.WriteLine(result.Values.First().Name);









        return result.Values.ToList(); 
    }
}