using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item (string name, decimal? price, string image, string color)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public decimal? Price { get; set; } = price;
        public string Image { get; set; } = image;
        public string Color { get; set; } = color;
    }
}
