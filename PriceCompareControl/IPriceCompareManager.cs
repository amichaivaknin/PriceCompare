using System.Collections.Generic;
using PriceCompareEntities;

namespace PriceCompareControl
{
    public interface IPriceCompareManager
    {
        IDictionary<int, MapItem> MapItems { get; }

        IDictionary<string, StoreItem> GetItemByStores(MapItem mapItem);

        Store GetStoreInfo(string chainId, string storeid);

        bool ToExelFile(List<ShoppingCart> storesList);

        void AddUserShoppingList(string userName, List<MapItem> itemsList);

        IEnumerable<IEnumerable<ShoppingListItem>> GetAllShoppingList(string userName);
    }
}