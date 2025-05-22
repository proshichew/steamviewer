using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class WishlistController (IWishlistRepository repository, IMapper mapper) : BaseController<Domain.Entities.Wishlist, WishlistDto>(repository, mapper)
    {
        //[HttpPost("{wishlistId:int}/games/{gameId:int}")]
        //public async Task<IActionResult> InsertGame(int wishlistId, GameDto gameDto, CancellationToken cts)
        //{
        //    if (wishlistId <= 0 || gameDto.Id <= 0)
        //        return BadRequest();

        //    var game = _mapper.Map<Domain.Entities.Game>(gameDto);

        //    await repository.InsertGame(wishlistId, game, cts);
        //    return NoContent();
        //}

        [HttpPost("{wishlistId:int}/games")]
        public async Task<IActionResult> AddGameToWishlist(int wishlistId, [FromBody] GameDto gameDto, CancellationToken ct)
        {
            if (wishlistId <= 0 || gameDto?.Id <= 0)
                return BadRequest("Invalid wishlist ID or game data");

            var game = _mapper.Map<Domain.Entities.Game>(gameDto);
            await repository.InsertGame(wishlistId, game, ct);
            return NoContent();
        }


        [HttpGet("{id}/games")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames(int id, CancellationToken cts)
        {
            var games = await repository.GetGames(id, cts);
            if (games == null || !games.Any())
                return NotFound();

            return Ok(games);
        }

        [HttpDelete("{wishlistId:int}/games/{gameId:int}")]
        public virtual async Task<IActionResult> RemoveGame(int wishlistId, int gameId, CancellationToken ct)
        {
            await repository.RemoveGame(wishlistId, gameId, ct);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistDto>>> GetAll(CancellationToken cts)
        {
            IEnumerable<Domain.Entities.Wishlist> wishlists = await repository.GetAll(cts);
            //if (wishlists == null || !wishlists.Any())
            //    return NotFound();

            var wishlistDtos = mapper.Map<IEnumerable<WishlistDto>>(wishlists);
            return Ok(wishlistDtos);
        }

    }
}