using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareEntities;

namespace PriceCompareControl.DataProvider
{
    internal interface IDataEngine
    {
        IDictionary<int, MapItem> MapItems { get; }
        IDictionary<string, StoreItem> GetItemByStores(MapItem mapItem);
        Store GetStoreInfo(string chainId, string storeid);
    }
}
