namespace API.DTO
{
    public record ItemDto(
        int Id,
        string Name,
        decimal Price,
        string Image,
        string Color,
        string Link);
}
