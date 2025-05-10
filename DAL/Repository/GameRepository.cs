using DAL.Context;
using DAL.Mapping;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GameRepository(AppDbContext context) : IGameRepository
    {
        private readonly AppDbContext _context = context;

        public async Task Add(Domain.Entities.Game game, CancellationToken cancellationToken)
        {
            await _context.Games.AddAsync(Mapper.ToDb(game));
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Domain.Entities.Game?> Get(int id, CancellationToken cancellationToken)
        {
            var dbGame = await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (dbGame == null) return null;
            return Mapper.ToDomain(dbGame);
        }

        public async Task<IEnumerable<Domain.Entities.Game>> GetGames(CancellationToken cancellationToken)
        {
            var dbGames = await _context.Games.AsNoTracking().ToListAsync(cancellationToken);
            return dbGames.Select(game => new Domain.Entities.Game(game.Id, game.SteamID, game.UserNote, game.SaleToNotify));
        }

        public async Task<Domain.Entities.Game?> GetSteamGame(int steamId, CancellationToken cancellationToken)
        {
            var dbGame = await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.SteamID == steamId);
            if (dbGame == null) return null;
            return Mapper.ToDomain(dbGame); 
        }

        public async Task<Domain.Entities.Game> UpdateGame(Domain.Entities.Game game, CancellationToken cancellationToken)
        {
            var existingGame = _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id, cancellationToken);
            if (existingGame != null)
            {
                _context.Entry(existingGame).CurrentValues.SetValues(game);
                await _context.SaveChangesAsync(cancellationToken);
                var dbGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id);
                return Mapper.ToDomain(dbGame!);
            }
            else
            {
                throw new Exception("Game not found");
            }
        }
    }
}