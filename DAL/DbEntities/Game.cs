using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbEntities
{
    public class Game
    {
        public int Id { get; set; }
        public int SteamID {  get; set; }
        public string? UserNote { get; set; }
        public int SaleToNotify { get; set; }
        public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    }
}
