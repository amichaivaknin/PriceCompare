using System.Collections.Generic;
using System.Linq;
using PriceCompareEntities;


namespace PriceCompareLogic.DataProvider
{
    internal interface IDataEngine
    {
        IDictionary<int, MapItem> MapItems { get; }

        IEnumerable<ShoppingCart> ShoppingCarts { get; }

        IDictionary<string, StoreItem> GetItemByStores(MapItem item);

        void AddItem(MapItem item);

        bool SaveUserShoppingList(string username,IEnumerable<MapItem> shoppingList);
    }
}