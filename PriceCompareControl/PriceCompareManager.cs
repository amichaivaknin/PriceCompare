using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using PriceCompareControl.DataProvider;
using PriceCompareEntities;
using static System.GC;

namespace PriceCompareControl
{
    public class PriceCompareManager:IPriceCompareManager
    {
        public IDictionary<int, MapItem> MapItems
        {
            get
            {
                IDataEngine dataEngine = new XmlsDataEngine();
                return dataEngine.MapItems;
            }
        }

        public IDictionary<int, ShoppingCart> GetShoppingCarts(IEnumerable<MapItem> items)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            var storesCarts = new Dictionary<string, ShoppingCart>();
            var mapItems=items.ToList();
            foreach (var itemByStore in mapItems.Select(item => dataEngine.GetItemByStores(item))
                    .SelectMany(itemByStores => itemByStores))
            {
                if (!storesCarts.ContainsKey(itemByStore.Key))
                {
                    storesCarts.Add(itemByStore.Key,
                        new ShoppingCart(itemByStore.Key, itemByStore.Value.ChainId, 
                            itemByStore.Value.SubChainId, itemByStore.Value.StoreId));
                }
                storesCarts[itemByStore.Key].AddItem(itemByStore.Value);
            }

            var i = 0;
            var sc =
                storesCarts.Where(store => store.Value.Items.Count() == mapItems.Count)
                    .ToDictionary(store => i++, store => store.Value);

            foreach (var storeCart in sc)
            {
                var store = dataEngine.GetStoreInfo(storeCart.Value.ChainId, storeCart.Value.StoreId);
                storeCart.Value.Address = store.Address;
                storeCart.Value.ChainName = store.ChainName;
                storeCart.Value.StoreName = store.StoreName;
                storeCart.Value.City = store.City;
            }
            return sc;
        }

        public IEnumerable<IEnumerable<ShoppingListItem>> GetAllShoppingList(string userName)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            return dataEngine.GetAllShoppingList(userName);
        } 

        public bool ToExelFile(List<ShoppingCart> storesList)
        {
            try 
            {
                object misValue = System.Reflection.Missing.Value;
                var xlApp = new Application();
                var xlWorkBook = xlApp.Workbooks.Add(misValue);
                var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Item[1];

                xlWorkSheet.Cells[1, 1] = "Price Compare";

                var i = 2;

                foreach (var store in storesList)
                {
                    var j = 2;
                    xlWorkSheet.Cells[j++, i] = store.ChainName;
                    xlWorkSheet.Cells[j++, i] = store.StoreName;
                    xlWorkSheet.Cells[j, i] = store.Total;
                    i++;
                }

                var xlCharts = (ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                var myChart = xlCharts.Add(10, 80, 300, 250);
                var chartPage = myChart.Chart;
                var ch = (char)('A' + i - 2);
                var chartRange = xlWorkSheet.Range["B4", $"{ch}4"];
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = XlChartType.xlColumnClustered;
                xlWorkBook.SaveAs($@"{Environment.CurrentDirectory}\..\..\..\PriceCompare.xls", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
                return true;
            }
            catch (Exception)
            {

                return false;
            }     
        }

        public void AddUserShoppingList(string userName, List<MapItem> itemsList)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            dataEngine.AddUserShoppingList(userName,itemsList);
        }
 
        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                Collect();
            }
        }
    }
}
