using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic.DataProvider
{
    internal class XmlsEngine : IDataEngine
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> _storesCarts;

        public IDictionary<int, MapItem> MapItems => XmlAccessor.ReadMapItems();

        public IEnumerable<ShoppingCart> ShoppingCarts
        {
            get { return _storesCarts.Select(storeCart => storeCart.Value).ToList()
                                                            .OrderBy(l => l.Total); }
        }

        public XmlsEngine()
        {
            _storesCarts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddItemToShoppingCarts(IDictionary<string, string> itemCodeByChains, double qty)
        {
            Parallel.ForEach(itemCodeByChains, code =>
            {
                var chainDirectory = $@"..\..\..\xmls\{code.Key}";
                AddItemToCartsByChain(chainDirectory, code.Value, qty);
            });
        }

        private void AddItemToCartsByChain(string chainDirectory, string itemCode, double qty)
        {
            var fileEntries = Directory.GetFiles($@"{chainDirectory}\prices");
            Parallel.ForEach(fileEntries, file =>
            {
                var items = XmlAccessor.GetItem(file, itemCode);
                var item = items.ToList()[0];
                item.Qty = qty;
                var shoppingCartId = $"{item.ChainId}{item.SubChainId}{item.StoreId}";
                if (!_storesCarts.ContainsKey(shoppingCartId))
                {
                    var stores = XmlAccessor.GetStoreInfo(chainDirectory, item.StoreId).ToList();
                    var store = stores[0];
                    var cart = new ShoppingCart(shoppingCartId, store.ChainName,
                        store.StoreName, store.Address, store.City);
                    _storesCarts.TryAdd(shoppingCartId, cart);
                }
                _storesCarts[shoppingCartId].AddItem(item);
            });
        }
    }
}