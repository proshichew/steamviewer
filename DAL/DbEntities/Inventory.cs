using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbEntities
{
    public class Inventory(string name, string playerId, string? gameName)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public string PlayerId { get; set; } = playerId;
        public string? GameName { get; set; } = gameName;
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
