using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/games")]
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
        public ActionResult<GameDto> GetGame()
        {
            var games = _context.GetById(1); // replace with GetAll()
            if (games == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(int id)
        {
            var game = _context.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<GameDto>(game);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateGame(/*Game 123*/)
        {
            ///
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGame(/*123123*/)
        {
            ///
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var success = _context.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}