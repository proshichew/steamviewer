using DAL.Context;
using Domain.Interfaces;

namespace DAL.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;
        public GameRepository(GameContext context) => _context = context;

        public Task Add(Domain.Entities.Game game)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Game> GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Game>> GetGames()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Game> GetSteamGame(int steamId)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Game> UpdateGame(Domain.Entities.Game game)
        {
            throw new NotImplementedException();
        }
    }
}