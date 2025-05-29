namespace Steamviewer.Services;

public enum SelectionType
{
    None,
    Wishlist,
    Inventory,
    Top100
}

public class AppStateService
{

    public SelectionType CurrentSelection { get; private set; } = SelectionType.None;
    public int? SelectedId { get; private set; }
    public event Action<SelectionType, int?>? OnSelectionChanged;

    public void SelectWishlist(int? wishlistId)
    {
        CurrentSelection = wishlistId.HasValue ? SelectionType.Wishlist : SelectionType.None;
        SelectedId = wishlistId;
        OnSelectionChanged?.Invoke(CurrentSelection, SelectedId);
    }

    public void SelectInventory(int? inventoryId)
    {
        CurrentSelection = inventoryId.HasValue ? SelectionType.Inventory : SelectionType.None;
        SelectedId = inventoryId;
        OnSelectionChanged?.Invoke(CurrentSelection, SelectedId);
    }
    public void SelectTop100()
    {
        CurrentSelection = SelectionType.Top100;
        SelectedId = null;
        OnSelectionChanged?.Invoke(CurrentSelection, SelectedId);
    }
    public void ClearSelection()
    {
        CurrentSelection = SelectionType.None;
        SelectedId = null;
        OnSelectionChanged?.Invoke(CurrentSelection, SelectedId);
    }
    //public int? SelectedWishlistId { get; private set; }

    //public event Action<int?> OnSelectedWishlistChanged;

    //public void SetSelectedWishlist(int? wishlistId)
    //{
    //    SelectedWishlistId = wishlistId;
    //    NotifySelectedWishlistChanged(wishlistId);
    //}

    //private void NotifySelectedWishlistChanged(int? wishlistId)
    //    => OnSelectedWishlistChanged?.Invoke(wishlistId);

    //public int? SelectedInventoryId { get; private set; }

    //public event Action<int?>? OnSelectedInventoryChanged;
    //public void SetSelectedInventory(int? inventoryId)
    //{
    //    SelectedInventoryId = inventoryId;
    //    OnSelectedInventoryChanged.Invoke(inventoryId);
    //}
}