using DAL.Context;
using DAL.Mapping;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GameRepository(GameContext context) : IGameRepository
    {
        private readonly GameContext _context = context;

        public async Task Add(Domain.Entities.Game game)
        {
            await _context.Games.AddAsync(Mapper.ConvertToDb(game));
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
            var dbGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (dbGame == null) return null;
            return Mapper.ConvertToDomain(dbGame);
        }

        public async Task<IEnumerable<Domain.Entities.Game>> GetGames()
        {
            var dbGames = await _context.Games.ToListAsync();
            return dbGames.Select(game => new Domain.Entities.Game(game.Id, game.SteamID, game.UserNote, game.SaleToNotify));
        }

        public async Task<Domain.Entities.Game?> GetSteamGame(int steamId)
        {
            var dbGame = await _context.Games.FirstOrDefaultAsync(g => g.SteamID == steamId);
            if (dbGame == null) return null;
            return Mapper.ConvertToDomain(dbGame); 
        }

        public async Task<Domain.Entities.Game> UpdateGame(Domain.Entities.Game game)
        {
            var existingGame = _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id);
            if (existingGame != null)
            {
                _context.Entry(existingGame).CurrentValues.SetValues(game);
                await _context.SaveChangesAsync();
                var dbGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id);
                return Mapper.ConvertToDomain(dbGame!);
            }
            else
            {
                throw new Exception("Game not found");
            }
        }
    }
}