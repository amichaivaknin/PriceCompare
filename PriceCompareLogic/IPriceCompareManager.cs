using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PriceCompareEntities;


namespace PriceCompareLogic
{
    public interface IPriceCompareManager
    {
        IDictionary<int, MapItem> MapItems { get; }

        IEnumerable<ShoppingCart> ShoppingCarts { get; }

        void AddItemToShoppingCart(MapItem mapItem);

        void AddItemsToShoppingCarts(IEnumerable<MapItem> items, IDictionary<Constrians, List<string>> constrians);

        
    }
}