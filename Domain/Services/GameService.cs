using Domain.Interfaces;

namespace Domain.Services
{
    public class GameService
    {
        private readonly IGameRepository _repository;
        public GameService(IGameRepository repository) => _repository = repository;

        public decimal ConvertGamePrice(int gameId)
        {
            var game = _repository.GetGame(gameId);
            // return game.Price * 100;
            return 0;
        }
        ///
        ///
    }
}