using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceCompareLogic;
using PriceCompareLogic.Strings;


namespace PriceCompareWinFormApp
{
    public partial class ItemsSeletcionForm : Form
    {
        private readonly IPriceCompareManager _infoManager = new PriceCompareManager();

        public ItemsSeletcionForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Text = Strings.ItemSelectionWindowName;
            var itemsMap = _infoManager.MapItems;


        }
    }
}
