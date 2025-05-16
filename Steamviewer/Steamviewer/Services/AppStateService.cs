namespace Steamviewer.Services;
public class AppStateService
{
    public int? SelectedWishlistId { get; private set; }

    public event Action<int?> OnSelectedWishlistChanged;

    public void SetSelectedWishlist(int? wishlistId)
    {
        SelectedWishlistId = wishlistId;
        NotifySelectedWishlistChanged(wishlistId);
    }

    private void NotifySelectedWishlistChanged(int? wishlistId)
        => OnSelectedWishlistChanged?.Invoke(wishlistId);
}