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
        private readonly string _username;
        private readonly IPriceCompareManager _priceCompare;
        private Dictionary<int, MapItem> _menuItems;
        private Dictionary<int, ShoppingCart> _selectedStores;
        private Dictionary<int, ShoppingCart> _displayStores;
        private List<MapItem> _selectedItems;
        private readonly LogInForm _logInForm;

        public ItemsSelectionFrom(LogInForm logInForm, string username)
        {
            _logInForm = logInForm;
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
            exelButton.Text = Strings.ExelButton;
            saveShoppingListButton.Text = Strings.SaveShoppingListButton;
            if (_username== "Unregistered User")
            {
                PreviousButton.Visible = false;
            }
            else
            {
                PreviousButton.Text = Strings.PreviousButton;
            }
            
            //storesGB.Visible = false;
        }

        private void selectItems_Click(object sender, EventArgs e)
        {
            var id = 0;
            try
            {
                selectItemsButton.Visible = false;
                storesGB.Visible = false;
                priceImage.Visible = true;
                saveShoppingListButton.Visible = true;
                ChainCB.Items.Clear();
                citiesCB.Items.Clear();
                var selectedItems = new List<MapItem>();
                foreach (var selectRow in from DataGridViewRow selectRow in itemsGrid.Rows
                                          let checkCell = (DataGridViewCheckBoxCell)selectRow.Cells["selectItem"]
                                          where checkCell.Value as bool? ?? false select selectRow)
                {
                    id = int.Parse(selectRow.Cells["No"].Value.ToString());
                    if (_menuItems[id].BisWeighted)
                    {
                        _menuItems[id].Qty = double.Parse(selectRow.Cells["qty"].Value.ToString());
                    }
                    else
                    {
                        _menuItems[id].Qty = int.Parse(selectRow.Cells["qty"].Value.ToString());
                    }
                    if (Math.Abs(_menuItems[id].Qty) <= 0)
                    {
                        throw new Exception("zero");
                    }
                    selectedItems.Add(_menuItems[id]);
                }
                AddItemsWorker.RunWorkerAsync(selectedItems);
                _selectedItems = selectedItems;
            }
            catch (Exception)
            {
                MessageBox.Show($"{Strings.InvalidQty} {id}");
                selectItemsButton.Visible = true;
            }
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var city = (string)citiesCB.SelectedItem;
            var chain = (string)ChainCB.SelectedItem;
            var update = new[] { city, chain };
            UpdateWorker.RunWorkerAsync(update);
        }

        private void exelButton_Click(object sender, EventArgs e)
        {
            exelButton.Visible = false;
            ExelWorker.RunWorkerAsync(_displayStores.Values.ToList());
        }

        private void saveShoppingListButton_Click(object sender, EventArgs e)
        {
            saveShoppingListButton.Visible = false;
            SaveShoppingWorker.RunWorkerAsync();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            WatchPreviusWorker.RunWorkerAsync();
        }

        private void StoresGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 || e.RowIndex < 0)
            {
                return;
            }
            var storeForm = new StoreForm(_displayStores[e.RowIndex]);
            storeForm.Show();
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
            var mapItems = e.Argument as List<MapItem>;
            _displayStores = _selectedStores = _priceCompare.GetShoppingCarts(mapItems).ToDictionary(x => x.Key, x => x.Value);
            var cities = new List<string> {"הכל"};
            var chains = new List<string> {"הכל"};
            foreach (var store in _selectedStores.Values)
            {
                if (!cities.Contains(store.City))
                {
                    cities.Add(store.City);
                }
                if (!chains.Contains(store.ChainName))
                {
                    chains.Add(store.ChainName);
                }
            }

            e.Result =new List<string[]>
            {
                chains.ToArray(),
                cities.ToArray()
            };
            
        }

        private void AddItemsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var con = (List <string[]>) e.Result;
            storesGrid.Rows.Clear();
            storesGrid.Refresh();
            foreach (var store in _selectedStores.Values)
            {
                storesGrid.Rows.Add($"{store.ChainName} {store.StoreName}", store.Total, "Store info");
            }
            var chains = con[0];
            var cities = con[1];
            ChainCB.Items.AddRange(chains);
            citiesCB.Items.AddRange(cities);
            storesGB.Visible = true;
            priceImage.Visible = false;
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
                e.Result = _selectedStores;
            }
            var sd = _selectedStores.Values.Where(store => city == null || city == "הכל" || store.City == city)
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
   
            _displayStores = (Dictionary<int, ShoppingCart>) e.Result;

            storesGrid.Rows.Clear();
            storesGrid.Refresh();
            foreach (var store in _displayStores.Values)
            {
                storesGrid.Rows.Add($"{store.ChainName} {store.StoreName}", store.Total, "Store info");
            }
        }

        private void ExelWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            var storesList = (List<ShoppingCart>)e.Argument;
            e.Result=_priceCompare.ToExelFile(storesList);
        }

        private void ExelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exelButton.Visible = true;
            var fl = (bool) e.Result;
            MessageBox.Show(fl ? @"Exel file added successfully" : @"File Export Failed");
        }

        private void SaveShoppingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_username== "Unregistered User")
            {
                return;
            }
            _priceCompare.AddUserShoppingList(_username, _selectedItems);
        }

        private void SaveShoppingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(_username == "Unregistered User"
                ? Strings.SaveShoppingErrorMessage
                : Strings.SaveShoppingListMessage);
        }

        private void WatchPreviusWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var lists = _priceCompare.GetAllShoppingList(_username).ToList();
            var listsString = "";
            var i = 1;
            foreach (var list in lists.Where(list => list == null || list.Any()))
            {
                listsString = $"{listsString} Shopping list no {i}\n";
                listsString = list.Aggregate(listsString, (current, item) => $"{current} {item.ItemName} {item.UnitQty} {item.Qty}\n");
                i++;
            }
            e.Result=listsString;
        }

        private void WatchPreviusWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           var listsString = (string) e.Result;
            MessageBox.Show(listsString);
        }

        private void signOut_Click(object sender, EventArgs e)
        {
           _logInForm.Show();
            Dispose();
        }
    }
}