using Domain.Interfaces;

namespace Domain.Services
{
    public class WishlistService
    {
        private readonly IWishlistRepository _repository;
        public WishlistService(IWishlistRepository repository) => _repository = repository;

        ///
        ///
    }
}