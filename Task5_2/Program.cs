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
        enum Goods
        {
            Food = 1,
            Electronics = 2,
            Clothes = 4,
            Books = 8,
            Other = 16,
        }

        static void Main(string[] args)
        {
            var floor1 = Goods.Food|Goods.Electronics;
            var floor2 = Goods.Books|Goods.Clothes|Goods.Electronics;
            var floor3 = Goods.Other|Goods.Books;

            Goods[] mall = { floor1, floor2, floor3 };

            for (int ctr = 0; ctr <mall.Length; ctr++)
                Console.WriteLine("On floor {0} u can buy food: {1}",
                                  ctr + 1,
                                  (mall[ctr] & Goods.Food) == Goods.Food ?
                                     "Yes" : "No");
        }
    }
}
