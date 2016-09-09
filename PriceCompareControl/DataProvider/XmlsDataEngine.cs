using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareEntities;

namespace PriceCompareControl.DataProvider
{
    internal class XmlsDataEngine:IDataEngine
    {
        public IDictionary<int, MapItem> MapItems => XmlsDataAccessor.ReadMapItems();

        public IDictionary<string, StoreItem> GetItemByStores(MapItem mapItem)
        {
            var itemByStores=new ConcurrentDictionary<string, StoreItem>();
            if (Math.Abs(mapItem.Qty) <= 0)
            {
                return null;
            }

            if (mapItem.IsGlobalCode)
            {
                var directoriesEntries = Directory.GetDirectories(@"..\..\..\xmls").AsParallel();
                foreach (var store in directoriesEntries.SelectMany(directory => 
                                      GetItemByChain(directory, mapItem.GlobalItemCode, mapItem.Qty).AsParallel()))
                {
                    itemByStores.TryAdd(store.Key, store.Value);
                }
            }
            else
            {
                var chainsCodes = mapItem.ItemCodeByChains.AsParallel();
                foreach (var store in from chainCode in chainsCodes let chainDirectory = $@"..\..\..\xmls\{chainCode.Key}"
                                      select GetItemByChain(chainDirectory, chainCode.Value, mapItem.Qty).AsParallel() 
                                      into chainStores from store in chainStores select store)
                {
                    itemByStores.TryAdd(store.Key,store.Value);
                }
            }

            return itemByStores;
        }

        public Store GetStoreInfo(string chainId, string storeid)
        {
            var chainDirectory = $@"..\..\..\xmls\{chainId}";
            return XmlsDataAccessor.GetStoreInfo(chainDirectory, storeid).ToList()[0];
        }

        private static ConcurrentDictionary<string, StoreItem> GetItemByChain(string directory, string globalItemCode, double qty)
        {
            var fileEntries = Directory.GetFiles($@"{directory}\prices").AsParallel();
            var itemByStores = new ConcurrentDictionary<string, StoreItem>();

            fileEntries.ForAll(store =>
            {
                var items = XmlsDataAccessor.GetItem(store, globalItemCode);
                var storeItems = items as IList<StoreItem> ?? items.ToList();
                if (!storeItems.Any()) return;
                var item = storeItems[0];
                item.Qty = qty;
                var storeId = $"{item.ChainId}{item.SubChainId}{item.StoreId}";
                itemByStores.TryAdd(storeId, item);
            }
            );
           return itemByStores;
        }



    }
}
