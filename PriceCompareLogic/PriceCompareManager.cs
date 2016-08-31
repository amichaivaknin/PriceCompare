using System.Collections.Generic;
using PriceCompareLogic.DataProvider;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic
{
    public class PriceCompareManager
    {
        private readonly IDataEngine _dataEngine = new XmlsEngine();

        public IDictionary<int, MapItem> MapItems => _dataEngine.MapItems;

        public IEnumerable<ShoppingCart> ShoppingCarts => _dataEngine.ShoppingCarts;

        public void AddItemToShoppingCart(MapItem mapItem, double qty)
        {
            _dataEngine.AddItemToShoppingCarts(mapItem.ItemCodeByChains, qty);
        }
    }
}