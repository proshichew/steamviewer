using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbEntities
{
    public class Wishlist (int id, string name, string? UserDescription)
    {
        public int Id {  get; set; } = id;
        public string Name { get; set; } = name;
        public string? UserDescription { get; set; } = UserDescription;
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
