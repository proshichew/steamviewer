namespace Steamviewer.Entities.DTOs
{
    public record InventoryDto(
        int Id,
        string Name,
        string PlayerId,
        string GameName,
        List<int> ItemIds);
}
