using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            int[] ints = new int[] { 45, 165, 78, 37, 18, 20, 64, 941, 3, 58 };
            StructXnY[] structXnY = {
                new StructXnY (15,598),
                 new StructXnY (785,16),
                 new StructXnY (184,47),
                 new StructXnY (90,1),
                 new StructXnY (72,31),
                 new StructXnY (4,11)

            };

            StrXnY4G[] structXnY4G = {
                new StrXnY4G (15, 598.05),
                 new StrXnY4G (785,16.7),
                 new StrXnY4G (184,47.24),
                 new StrXnY4G (90,1.79),
                 new StrXnY4G (72,31.33),
                 new StrXnY4G (4,11.05)

            };

            // а                      
            Console.WriteLine($"Max element: {foo.FindMax(ints)}\n");

            // б)
            Console.WriteLine($"Max el's index: {foo.FindMaxIndex(ints)}\n");

            // в)

            Console.WriteLine($"Max by Y: {foo.FindMaxByY(structXnY)}\n");

            // г)

            var structXnY4G2 = foo.SortByYnTransform(structXnY4G);
            Console.WriteLine("Sorted by Y n tronsformed");
            foreach (var v in structXnY4G2)
            {
                Console.WriteLine(v);
            }
            Console.ReadKey();
        }
    }
}
