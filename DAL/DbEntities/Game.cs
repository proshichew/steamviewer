using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbEntities
{
    public class Game(int id, int steamID, string? userNote, int saleToNotify)
    {
        public int Id { get; set; } = id;
        public int SteamID {  get; set; } = steamID;
        public string? UserNote { get; set; } = userNote;
        public int SaleToNotify { get; set; } = saleToNotify;
        public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    }
}
