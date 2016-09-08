using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PriceCompareControl;


namespace PriceCompareConsole
{
    internal class Program
    {
        private static void Main()
        {
            var x = new PriceCompareManager();
            var y = x.MapItems;

            foreach (var i in y)
            {
                Console.WriteLine(i.Key);
                Console.WriteLine(i.Value);  
            }

            y[1].Qty = 2;
            var z=x.GetItemByStores(y[1]);
            //x.AddItemToShoppingCart(y[1]);
            //y[2].Qty = 5;
            //x.AddItemToShoppingCart(y[2]);
            //y[8].Qty = 5;
            //x.AddItemToShoppingCart(y[8]);

            //var z=x.ShoppingCarts;
            //var orderedEnumerable = z.OrderBy(zi => zi.Total);

           

            var q = new UsersManager();
            var t=q.CheckUserNameAndPassword("1", "1234");
            t = q.CheckUserNameAndPassword("4", "1234");
            t = q.AddNewUser("1", "1234");
            t = q.AddNewUser("4", "1234");

        }
    }
}
