using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareControl.DataProvider;
using PriceCompareEntities;

namespace PriceCompareControl
{
    public class PriceCompareManager:IPriceCompareManager
    {
        public IDictionary<int, MapItem> MapItems
        {
            get
            {
                IDataEngine dataEngine = new XmlsDataEngine();
                return dataEngine.MapItems;
            }
        }

        public IDictionary<string, StoreItem> GetItemByStores(MapItem mapItem)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            return dataEngine.GetItemByStores(mapItem);
        }

        public Store GetStoreInfo(string chainId, string storeid)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            return dataEngine.GetStoreInfo(chainId, storeid);
        }
    }
}
