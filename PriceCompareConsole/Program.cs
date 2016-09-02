using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PriceCompareLogic;
using PriceCompareLogic.Entities;

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
            x.AddItemToShoppingCart(y[1]);
            y[2].Qty = 5;
            x.AddItemToShoppingCart(y[2]);
            y[8].Qty = 5;
            x.AddItemToShoppingCart(y[8]);

            var z=x.ShoppingCarts;
            var orderedEnumerable = z.OrderBy(zi => zi.Total);

            Console.ReadLine();

        }
    }
}
