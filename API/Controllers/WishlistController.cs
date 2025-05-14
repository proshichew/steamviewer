using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class WishlistController (IWishlistRepository repository, IMapper mapper) : BaseController<Domain.Entities.Wishlist, WishlistDto>(repository, mapper)
    {
        [HttpPost]
        public async Task<IActionResult> InsertGame(int wishlistId, int gameId, CancellationToken cts)
        {
            if (wishlistId <= 0 || gameId <= 0)
                return BadRequest();

            await repository.InsertGame(wishlistId, gameId, cts);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames(int id, CancellationToken cts)
        {
            var games = await repository.GetGames(id, cts);
            if (games == null || !games.Any())
                return NotFound();

            return Ok(games);
        }

        [HttpDelete("{gameId:int}")]
        public virtual async Task<IActionResult> RemoveGame(int wishlistId, int gameId, CancellationToken ct)
        {
            if (wishlistId <= 0 || gameId <= 0)
                return BadRequest();

            await repository.RemoveGame(wishlistId, gameId, ct);
            return NoContent();
        }
    }
}