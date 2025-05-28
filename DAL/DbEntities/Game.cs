using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.DbEntities
{
    public class Game(int steamID, string? userNote, int saleToNotify)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SteamID {  get; set; } = steamID;
        public string? UserNote { get; set; } = userNote;
        public int SaleToNotify { get; set; } = saleToNotify;
        public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    }
}
