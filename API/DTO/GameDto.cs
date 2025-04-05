using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public record GameDto(
        [Required] int Id, 
        [Required] [Range(1, int.MaxValue)] int SteamId, 
        [StringLength(300, MinimumLength = 5/*хз 78*/)] string? UserNote, 
        int SaleToNotify);
}