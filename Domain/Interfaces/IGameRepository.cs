using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGameRepository
    {
        void Add(Game game);
        Game GetById(int id);
        Game GetBySteamId(int id);
        bool Delete(int id);
        ///
        ///
    }
}