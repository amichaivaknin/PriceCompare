using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using PriceCompareControl.DataProvider;
using PriceCompareEntities;

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

        public IDictionary<string, StoreItem> GetItemByStores(MapItem mapItem)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            return dataEngine.GetItemByStores(mapItem);
        }

        public Store GetStoreInfo(string chainId, string storeid)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            return dataEngine.GetStoreInfo(chainId, storeid);
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

        public IEnumerable<IEnumerable<ShoppingListItem>> GetAllShoppingList(string userName)
        {
            IDataEngine dataEngine = new XmlsDataEngine();
            return dataEngine.GetAllShoppingList(userName);
        }
    }
}
