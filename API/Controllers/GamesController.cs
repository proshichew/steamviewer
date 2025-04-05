using API.DTO;
using AutoMapper;
using DAL.DbEntities;
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
        private static async Task<bool> CheckTimeout(Task contextOperation, int timeMs = 10000) // Оставить в этом файле?
        {
            var timeoutTask = Task.Delay(timeMs);
            var runningTask = await Task.WhenAny(contextOperation, timeoutTask);
            return runningTask == timeoutTask;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            if (await CheckTimeout(_repository.GetGames()))
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }

            var games = await _repository.GetGames();
            if (games == null || !games.Any())
            {
                return NotFound("No games found");
            }
            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            if (await CheckTimeout(_repository.Get(id)))
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }

            var game = await _repository.Get(id);
            if (game == null)
            {
                return NotFound("Игра не найдена");
            }
            var dto = _mapper.Map<GameDto>(game);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateGame(GameDto gameDto)
        {
            if (gameDto == null)    // if IsValid
            {
                return BadRequest("null");
            }

            if (await CheckTimeout(_repository.GetGames()))
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }

            var game = _mapper.Map<Game>(gameDto);
            // await _context.Add(game); // DAL.Game - Domain.Game
            // + timeout check
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, gameDto); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameDto gameDto)
        {
            if (gameDto == null)    // if IsValid
            {
                return BadRequest("null");
            }

            if(await CheckTimeout(_repository.Get(id)))
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }

            var game = await _repository.Get(id);
            if (game == null)
            {
                return NotFound();
            }
            var newGame = _mapper.Map<Game>(gameDto);
            //await _context.UpdateGame(newGame); // DAL.Game - Domain.Game
            // + timeout check
            return NoContent(); // Ok(newGame); // если надо вернуть обновлённый объект
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if(await CheckTimeout(_repository.Get(id)))
            {
                return StatusCode(504, "Превышено вермя ожидания");
            }

            var game = await _repository.Get(id);
            if (game == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
    }
}