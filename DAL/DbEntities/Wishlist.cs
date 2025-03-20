using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbEntities
{
    public class Wishlist
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? UserDescription { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
