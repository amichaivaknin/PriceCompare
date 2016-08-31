using System.Collections.Generic;
using System.Linq;

namespace PriceCompareLogic.Entities
{
    public class ShoppingCart
    {
        private readonly List<StoreItem> _selectedItems;

        public ShoppingCart(string shoppingCartId, string chainName, string storeName, string address, string city)
        {
            ShoppingCartId = shoppingCartId;
            ChainName = chainName;
            StoreName = storeName;
            Address = address;
            City = city;
            _selectedItems = new List<StoreItem>();
        }

        public string ShoppingCartId { get; }
        public string ChainName { get; }
        public string StoreName { get; }
        public string Address { get; }
        public string City { get; }

        public IEnumerable<StoreItem> Items => _selectedItems;

        public double Total => _selectedItems.Sum(chainItem => chainItem.Price*chainItem.Qty);

        public void AddItem(StoreItem storeItem) => _selectedItems.Add(storeItem);
    }
}