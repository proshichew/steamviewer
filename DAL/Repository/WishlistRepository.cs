using DAL.Context;
using DAL.Mapping;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class WishlistRepository(AppDbContext context) : IWishlistRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Wishlist>> GetAll(CancellationToken cts = default)
        {
            var dbWishlists = await _context.Wishlists.ToListAsync(cts);
            return dbWishlists.Select(Mapper.ToDomain).ToList();
        }

        public async Task Add(Domain.Entities.Wishlist item, CancellationToken cancellationToken = default)
        {
            await _context.Wishlists.AddAsync(Mapper.ToDb(item), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var wishlist = await _context.Wishlists.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (wishlist == null) return;

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Domain.Entities.Wishlist?> Get(int id, CancellationToken cancellationToken)
        {
            var wishlist = await _context.Wishlists.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (wishlist == null) return null;
            return Mapper.ToDomain(wishlist);
        }

        public async Task<IEnumerable<Domain.Entities.Game>?> GetGames(int wishlistId, CancellationToken cancellationToken = default)
        {
            var wishlistWithGames = await _context.Wishlists.Where(w => w.Id == wishlistId).Include(w => w.Games).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            return wishlistWithGames?.Games.Select(Mapper.ToDomain);
        }

        public async Task InsertGame(int wishlistId, int gameId, CancellationToken cancellationToken = default)
        {
            var wishlistDb = await _context.Wishlists.Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.Id == wishlistId, cancellationToken) ?? throw new Exception("Wishlist not found");

            var game = await _context.Games.FindAsync([gameId], cancellationToken: cancellationToken) ?? throw new Exception("Game not found"); 
            // FindAsync - если gameId - это бдшный ключ /// если ключ не составной и не было AsNoTracking, то можно еще где нибудь заменить на FindAsync вместо FirstOrDefaultAsync
            //var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId); // иначе

            if (!wishlistDb.Games.Any(g => g.Id == gameId))
            {
                wishlistDb.Games.Add(game);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        
        public async Task InsertGame(int wishlistId, Game game, CancellationToken cancellationToken = default)
        {
            var wishlistDb = await _context.Wishlists.Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.Id == wishlistId, cancellationToken) ?? throw new Exception("Wishlist not found");
            
            // FindAsync - если gameId - это бдшный ключ /// если ключ не составной и не было AsNoTracking, то можно еще где нибудь заменить на FindAsync вместо FirstOrDefaultAsync
            //var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId); // иначе

            if (!wishlistDb.Games.Any(g => g.Id == game.Id))
            {
                wishlistDb.Games.Add(Mapper.ToDb(game));
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        

        public async Task RemoveGame(int wishlistId, int gameId, CancellationToken cancellationToken)
        {
            var wishlistDb = await _context.Wishlists.Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.Id == wishlistId, cancellationToken)?? throw new Exception("Wishlist not found");
            
            var game = wishlistDb.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                wishlistDb.Games.Remove(game);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}