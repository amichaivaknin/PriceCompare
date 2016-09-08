using System.ComponentModel;
using System.Windows.Forms;
using PriceCompareControl;
using PriceCompareControl.Stirngs;

namespace PriceCompareWinFormApp
{
    public sealed partial class ItemsSelectionFrom : Form
    {
        private readonly IPriceCompareManager _priceCompare;
        private readonly string _username;

        public ItemsSelectionFrom(string username)
        {
            _username = username;
            _priceCompare = new PriceCompareManager();
            //MenuItemsWorker.RunWorkerAsync();
            InitializeComponent();
            Text = Strings.ItemSelectionWindowName;
            UserNameLabel.Text = $"{Strings.UserNameLabel}{_username}";
        }

        private void MenuItemsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = _priceCompare.MapItems;
        }

        private void ShoppingCartsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void SaveShoppingListByUser_DoWork(object sender, DoWorkEventArgs e)
        {
        }
    }
}