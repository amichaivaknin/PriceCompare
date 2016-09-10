using System.Collections.Generic;
using PriceCompareEntities;

namespace PriceCompareControl
{
    public interface IPriceCompareManager
    {
        IDictionary<int, MapItem> MapItems { get; }

        IDictionary<int, ShoppingCart> GetShoppingCarts(IEnumerable<MapItem> items);

        bool ToExelFile(List<ShoppingCart> storesList);

        void AddUserShoppingList(string userName, List<MapItem> itemsList);

        IEnumerable<IEnumerable<ShoppingListItem>> GetAllShoppingList(string userName);
    }
}