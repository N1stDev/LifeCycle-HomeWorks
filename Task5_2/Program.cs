using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_2
{
    internal class Program
    {
        [Flags]
        enum Shops
        {
            Food = 1,
            Electronics = 2,
            Clothes = 4,
            Books = 8,
            Other = 16,
        }

        static void Main(string[] args)
        {
            var floor1 = Shops.Food|Shops.Electronics;
            var floor2 = Shops.Books|Shops.Clothes|Shops.Electronics;
            var floor3 = Shops.Other|Shops.Books;

            Shops[] mall = { floor1, floor2, floor3 };

        }
    }
}
