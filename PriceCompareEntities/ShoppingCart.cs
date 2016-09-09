using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace PriceCompareEntities
{
    public class ShoppingCart
    {
        private readonly List<StoreItem> _selectedItems;
        private List<StoreItem> _threeExpensiveItems;
        private List<StoreItem> _threeCheapestItems;
        public string ShoppingCartId { get; set; }
        public string ChainId { get; }
        public string SubChainId { get; }
        public string StoreId { get; }
        public string ChainName { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IEnumerable<StoreItem> Items => _selectedItems;
        public IEnumerable<StoreItem> ThreeMostExpensiveItems => _threeExpensiveItems;
        public IEnumerable<StoreItem> ThreeCheapestItems => _threeCheapestItems;

        public ShoppingCart(string shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
            _selectedItems = new List<StoreItem>();
            _threeCheapestItems = new List<StoreItem>();
            _threeExpensiveItems = new List<StoreItem>();
        }

        public ShoppingCart(string shoppingCartId, string chainId, string subChainId, string storeId)
        {
            ShoppingCartId = shoppingCartId;
            ChainId = chainId;
            SubChainId = subChainId;
            StoreId = storeId;
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