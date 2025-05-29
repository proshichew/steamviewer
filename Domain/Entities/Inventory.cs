using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventory (string name, string playerId, string? gameName)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public string PlayerId { get; set; } = playerId;
        public string? GameName { get; set; } = gameName;
        public List<Item> Items { get; set; } = [];
    }
}
