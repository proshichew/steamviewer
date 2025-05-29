namespace API.DTO
{
    public record InventoryDto(
        int Id,
        string Name,
        string PlayerId,
        string GameName,
        List<ItemDto> Items);
}
