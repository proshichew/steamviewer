using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameRepository repository, IMapper mapper) : ControllerBase
    {
        private readonly IGameRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames(CancellationToken cts)
        {
            try
            {
                var games = await _repository.GetGames(cts);
                if (games == null || !games.Any())
                {
                    return NotFound("No games found");
                }
                return Ok(games);
            }
            catch
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameDto>> GetGame(int id, CancellationToken cts)
        {
            try
            {
                var game = await _repository.Get(id, cts);
                if (game == null)
                {
                    return NotFound("Игра не найдена");
                }
                var dto = _mapper.Map<GameDto>(game);
                return Ok(dto);
            }
            catch
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateGame(GameDto gameDto, CancellationToken cts)
        {
            if (gameDto == null)
            {
                return BadRequest("null");
            }
            try
            {
                var game = _mapper.Map<Domain.Entities.Game>(gameDto);
                await _repository.Add(game, cts);
                return CreatedAtAction(nameof(GetGame), new { id = game.Id }, gameDto); 
            }
            catch
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameDto gameDto, CancellationToken cts)
        {
            if (gameDto == null)
            {
                return BadRequest("null");
            }
            try
            {
                var game = await _repository.Get(id, cts);
                if (game == null)
                {
                    return NotFound();
                }
                var newGame = _mapper.Map<Domain.Entities.Game>(gameDto);
                await _repository.UpdateGame(newGame, cts);
                return NoContent(); // Ok(newGame); // если надо вернуть обновлённый объект
            }
            catch
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id, CancellationToken cts)
        {
            try
            {
                var game = await _repository.Get(id, cts);
                if (game == null)
                {
                    return NotFound();
                }
                await _repository.Delete(id, cts);
                return NoContent();
            }
            catch
            {
                return StatusCode(504, "Превышено вермя ожидания");
            } 
        }
    }
}