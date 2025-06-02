using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DTO
{
    public record ItemDto(
        int Id,
        string Name,
        decimal Price,
        string Image,
        string Color,
        string Link);
}
