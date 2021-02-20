using System.Collections.Generic;

public class PagnationHelper<T>
{
    private readonly IList<T> Collection;
    // TODO: Complete this class

    private readonly int ItemsPerPage;

    /// <summary>
    ///     Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
        Collection = collection;
        ItemsPerPage = itemsPerPage;
    }

    /// <summary>
    ///     The number of items within the collection
    /// </summary>
    public int ItemCount => Collection.Count;

    /// <summary>
    ///     The number of pages
    /// </summary>
    public int PageCount
    {
        get
        {
            int FullPagesCount = ItemCount / ItemsPerPage;
            return FullPagesCount + (ItemCount - FullPagesCount != 0 ? 1 : 0);
        }
    }

    /// <summary>
    ///     Returns the number of items in the page at the given page index
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex >= PageCount) return -1;
        int ItemsCount = ItemCount - pageIndex * ItemsPerPage;
        return ItemsCount > ItemsPerPage ? ItemsPerPage : ItemsCount;
    }

    /// <summary>
    ///     Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>
    ///     The zero-based page index of the page containing the item at the given item index or -1 if the item index is
    ///     out of range
    /// </returns>
    public int PageIndex(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= ItemCount) return -1;
        return itemIndex / ItemsPerPage;
    }
}