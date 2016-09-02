using System.Collections.Generic;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic
{
    public interface IPriceCompareManager
    {
        IDictionary<int, MapItem> MapItems { get; }

        IEnumerable<ShoppingCart> ShoppingCarts { get; }

        void AddItemToShoppingCart(MapItem mapItem);
    }
}