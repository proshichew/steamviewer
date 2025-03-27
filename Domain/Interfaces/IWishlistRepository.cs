using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IWishlistRepository
    {
        void Add(Wishlist game);
        Wishlist GetById(int id);
        ///
        ///
    }
}