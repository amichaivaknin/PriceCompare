using System;
using System.Windows.Forms;
using PriceCompareControl.Strings;
using PriceCompareEntities;

namespace PriceCompareWinFormApp
{
    public partial class StoreForm : Form
    {
        private readonly ShoppingCart _shoppingCart;

        public StoreForm(ShoppingCart shoppingCart)
        {
            InitializeComponent();
            _shoppingCart = shoppingCart;
        }

        protected override void OnLoad(EventArgs e)
        {
            chainLabel.Text = $"{Strings.ChainNameLabel} {_shoppingCart.ChainName}";
            storeLabel.Text = $"{Strings.StoreNameLabel} {_shoppingCart.StoreName}";
            addressLabel.Text = $"{Strings.AddressLabel} {_shoppingCart.Address}";
            cityLabel.Text = $"{Strings.CityLabel} {_shoppingCart.City}";
            minLabel.Text = Strings.MinLabel;
            maxLabel.Text = Strings.MaxLabel;
            itemsLabel.Text = Strings.AllItems;

            foreach (var item in _shoppingCart.ThreeCheapestItems)
            {
                min3Box.Items.Add($"{item.ItemName} {item.Price}");
            }

            foreach (var item in _shoppingCart.ThreeMostExpensiveItems)
            {
                max3box.Items.Add($"{item.ItemName} {item.Price}");
            }

            foreach (var item in _shoppingCart.Items)
            {
                itemsBox.Items.Add($"{item.ItemName}  price:{item.Price}  Qty:{item.Qty}  total price:{item.TotalPrice}");
            }
        }
    }
}