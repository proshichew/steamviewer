namespace Steamviewer.Entities.SteamModels;

// SteamModels.cs
public class SteamSearchResult
{
    public int Total { get; set; }
    public List<GameItem> Items { get; set; } = new();
}




