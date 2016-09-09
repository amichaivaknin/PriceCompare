using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PriceCompareControl;
using PriceCompareControl.Strings;
using PriceCompareEntities;

namespace PriceCompareWinFormApp
{
    public sealed partial class ItemsSelectionFrom : Form
    {
        private readonly IPriceCompareManager _priceCompare;
        private readonly Dictionary<string, ShoppingCart> _storesCarts = new Dictionary<string, ShoppingCart>();
        private readonly string _username;
        private Dictionary<int, MapItem> _menuItems;
        private Dictionary<int, ShoppingCart> _selectedStore;

        public ItemsSelectionFrom(string username)
        {
            _username = username;
            _priceCompare = new PriceCompareManager();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MenuItemsWorker.RunWorkerAsync();
            Text = Strings.ItemSelectionWindowName;
            UserNameLabel.Text = $"{Strings.UserNameLabel}{_username}";
            selectItemsButton.Text = Strings.SelectButton;
            priceImage.Image = Image.FromFile(@"..\..\..\priceImage.png");
            updateButton.Text = Strings.UpdateButton;
            storesGrid.Visible = false;
            ChainCB.Visible = false;
            citiesCB.Visible = false;
            updateButton.Visible = false;
        }

        private void selectItems_Click(object sender, EventArgs e)
        {
            selectItemsButton.Visible = false;
            storesGrid.Visible = false;
            ChainCB.Items.Clear();
            citiesCB.Items.Clear();
            var selectedItems = new List<MapItem>();
            foreach (DataGridViewRow selectRow in itemsGrid.Rows)
            {
                var checkCell = (DataGridViewCheckBoxCell) selectRow.Cells["selectItem"];
                if (!(checkCell.Value as bool? ?? false)) continue;
                var id = int.Parse(selectRow.Cells["No"].Value.ToString());
                _menuItems[id].Qty = double.Parse(selectRow.Cells["qty"].Value.ToString());
                selectedItems.Add(_menuItems[id]);
            }
            AddItemsWorker.RunWorkerAsync(selectedItems);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var city = (string)citiesCB.SelectedItem;
            var chain = (string)ChainCB.SelectedItem;
            var update = new[] { city, chain };
            UpdateWorker.RunWorkerAsync(update);
        }

        private void StoresGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 || e.RowIndex < 0)
            {
                return;
            }
            var storeForm = new StoreForm(_selectedStore[e.RowIndex]);
            storeForm.Show();
        }

        private void SetShoppingCartsInfo()
        {
            foreach (var storeCart in _storesCarts)
            {
                var store = _priceCompare.GetStoreInfo(storeCart.Value.ChainId, storeCart.Value.StoreId);
                storeCart.Value.Address = store.Address;
                storeCart.Value.ChainName = store.ChainName;
                storeCart.Value.StoreName = store.StoreName;
                storeCart.Value.City = store.City;
            }
        }

        private void AddItemToShoppingCarts(IDictionary<string, StoreItem> itemByStore)
        {
            if (itemByStore == null) return;
            foreach (var item in itemByStore)
            {
                if (!_storesCarts.ContainsKey(item.Key))
                {
                    _storesCarts.Add(item.Key,
                        new ShoppingCart(item.Key, item.Value.ChainId, item.Value.SubChainId, item.Value.StoreId));
                }
                _storesCarts[item.Key].AddItem(item.Value);
            }
        }

        private void MenuItemsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = _priceCompare.MapItems;
        }

        private void MenuItemsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _menuItems = (Dictionary<int, MapItem>) e.Result;
            foreach (var item in _menuItems.Values)
            {
                itemsGrid.Rows.Add(item.Id, item.ItemName, item.UnitQty, 0, 0);
            }
            selectItemsButton.Visible = true;
        }

        private void AddItemsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var items = e.Argument as List<MapItem>;
            if (items == null) return;
            foreach (var itemByStore in items.Select(item => _priceCompare.GetItemByStores(item)))
            {
                AddItemToShoppingCarts(itemByStore);
            }
            SetShoppingCartsInfo();
            var sc =
                _storesCarts.Where(store => store.Value.Items.Count() == items.Count)
                    .ToDictionary(store => store.Key, store => store.Value);
            _storesCarts.Clear();
            foreach (var store in sc)
            {
                _storesCarts.Add(store.Key, store.Value);
            }
            e.Result = null;
        }

        private void AddItemsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var i = 0;
            _selectedStore = new Dictionary<int, ShoppingCart>();
            var cities = new List<string> {"הכל"};
            var chains = new List<string> {"הכל"};
            storesGrid.Rows.Clear();
            storesGrid.Refresh();
            foreach (var store in _storesCarts.Values)
            {
                if (!cities.Contains(store.City))
                {
                    cities.Add(store.City);
                }
                if (!chains.Contains(store.ChainName))
                {
                    chains.Add(store.ChainName);
                }
                _selectedStore.Add(i++, store);
                storesGrid.Rows.Add($"{store.ChainName} {store.StoreName}", store.Total, "Store info");
            }
            ChainCB.Items.AddRange(chains.ToArray());
            citiesCB.Items.AddRange(cities.ToArray());
            storesGrid.Visible = true;
            ChainCB.Visible = true;
            citiesCB.Visible = true;
            updateButton.Visible = true;

            priceImage.Visible = false;
            _storesCarts.Clear();
            selectItemsButton.Visible = true;
        }

        private void UpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var i = 0;
            var update = (string[]) e.Argument;
            var city = update[0];
            var chain = update[1];
            if (city == null && chain == null)
            {
                e.Result = null;
                return;
            }

            if (city == "הכל" && chain == "הכל")
            {
                e.Result = _selectedStore;
            }
            var sd = _selectedStore.Values.Where(store => city == null || city == "הכל" || store.City == city)
                .Where(store => chain == null || chain == "הכל" || store.ChainName == chain)
                .ToDictionary(store => i++);
            e.Result = sd;
        }

        private void UpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                return;
            }

            var sd = (Dictionary<int, ShoppingCart>) e.Result;

            storesGrid.Rows.Clear();
            storesGrid.Refresh();
            foreach (var store in sd.Values)
            {
                storesGrid.Rows.Add($"{store.ChainName} {store.StoreName}", store.Total, "Store info");
            }
        }
    }
}