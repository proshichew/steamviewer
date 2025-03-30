using API.DTO;
using AutoMapper;
using DAL.DbEntities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _context;
        private readonly IMapper _mapper;
        public GamesController(IGameRepository repository, IMapper mapper)
        {
            _context = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            var games = await _context.GetGames();
            if (games == null)      // возможно потом надо будет изменить
            {
                return NotFound("No games found");
            }
            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await _context.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<GameDto>(game);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameDto gameDto)
        {
            if (gameDto == null)    // if IsValid
            {
                return BadRequest("null");
            }
            var game = await _context.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }
            var newGame = _mapper.Map<Game>(gameDto);
            //await _context.UpdateGame(newGame); // DAL.Game - Domain.Game
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }

            await _context.Delete(id);
            return NoContent();
        }
    }
}