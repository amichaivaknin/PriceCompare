using System;
using System.Collections.Generic;
using PriceCompareLogic.DataProvider;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic
{
    public class PriceCompareManager : IPriceCompareManager
    {
        private readonly IDataEngine _dataEngine = new XmlsEngine();

        public IDictionary<int, MapItem> MapItems => _dataEngine.MapItems;

        public IEnumerable<ShoppingCart> ShoppingCarts => _dataEngine.ShoppingCarts;

        public void AddItemToShoppingCart(MapItem mapItem)
        {
            _dataEngine.AddItem(mapItem);
        }

        public void AddItemsToShoppingCarts(IEnumerable<MapItem> items, IDictionary<Constrians, List<string>> constrians)
        {
            throw new NotImplementedException();
        }
    }
}