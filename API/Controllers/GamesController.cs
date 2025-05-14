using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameRepository repository, IMapper mapper) : BaseController<Domain.Entities.Game, GameDto>(repository, mapper)
    {

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameDto gameDto, CancellationToken cts)
        {
            if (gameDto == null)
                return BadRequest();

            var game = await _repository.Get(id, cts);
            if (game == null)
            {
                return NotFound();
            }
            var newGame = _mapper.Map<Domain.Entities.Game>(gameDto);
            await repository.UpdateGame(newGame, cts);
            return NoContent(); // Ok(newGame); // если надо вернуть обновлённый объект
        }
    }
}