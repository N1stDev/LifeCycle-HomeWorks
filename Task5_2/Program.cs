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
            Console.WriteLine();

            for (int ctr = 0; ctr < mall.Length; ctr++)
                Console.WriteLine("On floor {0} u can buy electronics: {1}",
                                  ctr + 1,
                                  (mall[ctr] & Goods.Electronics) == Goods.Electronics ?
                                     "Yes" : "No");

            Console.WriteLine();

            for (int ctr = 0; ctr < mall.Length; ctr++)
                Console.WriteLine("On floor {0} u can buy Books: {1}",
                                  ctr + 1,
                                  (mall[ctr] & Goods.Books) == Goods.Books ?
                                     "Yes" : "No");

            Console.WriteLine();

            for (int ctr = 0; ctr < mall.Length; ctr++)
                Console.WriteLine("On floor {0} u can buy clothes: {1}",
                                  ctr + 1,
                                  (mall[ctr] & Goods.Clothes) == Goods.Clothes ?
                                     "Yes" : "No");

            Console.WriteLine();

            Enum myFood = Goods.Food;
            Enum myElectronics = Goods.Electronics;
            Enum myBooks = Goods.Books;
            Enum myClothes = Goods.Clothes;

            Console.WriteLine("U can buy {0}, {1}, {2}, {3} in this Mall", myFood.ToString(), myBooks.ToString(),
                myClothes.ToString(), myElectronics.ToString());

            Console.WriteLine();

            Type myGoods = typeof(Goods);
            foreach (string s in Enum.GetNames(myGoods))
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(myGoods, Enum.Parse(myGoods, s), "d"));
            Console.ReadKey();
        }
    }
}
