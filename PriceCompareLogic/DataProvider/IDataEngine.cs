using System.Collections.Generic;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic.DataProvider
{
    internal interface IDataEngine
    {
        IDictionary<int, MapItem> MapItems { get; }

        IEnumerable<ShoppingCart> ShoppingCarts { get; }

        void AddItemToShoppingCarts(IDictionary<string, string> itemCodeByChains, double qty);
    }
}