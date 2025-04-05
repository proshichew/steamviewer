using DAL.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GameRepository(GameContext context) : IGameRepository
    {
        private readonly GameContext _context = context;

        public async Task Add(Domain.Entities.Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Game?> Get(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.Game>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Domain.Entities.Game?> GetSteamGame(int steamId)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.SteamID == steamId);
        }

        public async Task<Domain.Entities.Game> UpdateGame(Domain.Entities.Game game)
        {
            var existingGame = _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id);
            if (existingGame != null)
            {
                _context.Entry(existingGame).CurrentValues.SetValues(game);
                await _context.SaveChangesAsync();
                return await _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id);
            }
            else
            {
                throw new Exception("Game not found");
            }
        }
    }
}