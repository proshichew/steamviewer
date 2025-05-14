using DAL.Context;
using DAL.Mapping;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repository
{
    public class GameRepository(AppDbContext context) : IGameRepository
    {
        private readonly AppDbContext _context = context;


        public async Task<IEnumerable<Domain.Entities.Game>> GetAll(CancellationToken cts = default)
        {
            var dbGames = await _context.Games.ToListAsync(cts);
            return dbGames.Select(Mapper.ToDomain).ToList();
        }

        public async Task Add(Domain.Entities.Game game, CancellationToken cancellationToken = default)
        {
            await _context.Games.AddAsync(Mapper.ToDb(game), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (game == null) return;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync(cancellationToken);
        }
        ///
        public async Task<Domain.Entities.Game?> Get(int id, CancellationToken cancellationToken)
        {
            var dbGame = await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            if (dbGame == null) return null;
            return Mapper.ToDomain(dbGame);
        }
        ///
        /// По сути два одинаковых метода разраб даун

        ///
        public async Task<Domain.Entities.Game> UpdateGame(Domain.Entities.Game game, CancellationToken cancellationToken)
        {
            var existingGame = _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id, cancellationToken);
            if (existingGame != null)
            {
                _context.Entry(existingGame).CurrentValues.SetValues(game);
                await _context.SaveChangesAsync(cancellationToken);
                var dbGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id, cancellationToken: cancellationToken);
                return Mapper.ToDomain(dbGame!);
            }
            else
            {
                throw new Exception("Game not found");
            }
        }
    }
}