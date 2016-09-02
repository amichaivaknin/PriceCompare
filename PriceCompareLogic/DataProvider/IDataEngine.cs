using System.Collections.Generic;
using System.Linq;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic.DataProvider
{
    internal interface IDataEngine
    {
        IDictionary<int, MapItem> MapItems { get; }

        IEnumerable<ShoppingCart> ShoppingCarts { get; }

        void AddItem(MapItem item);
    }
}