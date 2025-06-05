using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbEntities
{
    public class Item(string name, decimal? price, string image, string color, string link)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public decimal? Price { get; set; } = price;
        public string Image { get; set; } = image;
        public string Color { get; set; } = color;
        public string Link { get; set; } = link;
    }
}
