using System.Collections.Generic;
using System.Linq;

namespace PriceCompareEntities
{
    public class ShoppingCart
    {
        private readonly List<StoreItem> _selectedItems;
        private List<StoreItem> _threeExpensiveItems;
        private List<StoreItem> _threeCheapestItems;
        public string ShoppingCartId { get; }
        public string ChainName { get; }
        public string StoreName { get; }
        public string Address { get; }
        public string City { get; }
        public IEnumerable<StoreItem> Items => _selectedItems;
        public IEnumerable<StoreItem> ThreeMostExpensiveItems => _threeExpensiveItems;
        public IEnumerable<StoreItem> ThreeCheapestItems => _threeCheapestItems;

        public ShoppingCart(string shoppingCartId, string chainName, string storeName, string address, string city)
        {
            ShoppingCartId = shoppingCartId;
            ChainName = chainName;
            StoreName = storeName;
            Address = address;
            City = city;
            _selectedItems = new List<StoreItem>();
            _threeCheapestItems = new List<StoreItem>();
            _threeExpensiveItems = new List<StoreItem>();
        }      

        public double Total => _selectedItems.Sum(chainItem => chainItem.TotalPrice);

        public void AddItem(StoreItem storeItem)
        {
            _selectedItems.Add(storeItem);
            if (Items.Count()<4)
            {
                _threeCheapestItems.Add(storeItem);
                _threeCheapestItems = _threeCheapestItems.OrderBy(item => item.Price).ToList();
                _threeExpensiveItems.Add(storeItem);
                _threeExpensiveItems = _threeExpensiveItems.OrderByDescending(item => item.Price).ToList();
            }
            else
            {
                CheckMaxAndMin(storeItem);
            }
        }

        private void CheckMaxAndMin(StoreItem storeItem)
        {
            if (storeItem.Price<_threeCheapestItems[2].Price)
            {
                _threeCheapestItems[2] = storeItem;
                _threeCheapestItems = _threeCheapestItems.OrderBy(item => item.Price).ToList();
            }

            if (storeItem.Price>_threeExpensiveItems[2].Price)
            {
                _threeExpensiveItems[2] = storeItem;
                _threeExpensiveItems = _threeExpensiveItems.OrderByDescending(item => item.Price).ToList();
            }
        }
    }
}