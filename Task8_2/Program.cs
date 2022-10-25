using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    internal class Program
    {
       public static class Swap_num
        {
           public static void Swap<T>(ref T left, ref T right)
            {
                T temp;
                temp = left;
                left = right;
                right = temp;
            }
            public static void MirrorSwapf4<T>(ref T far_left, ref T left, ref T right, ref T far_right)
            {
                T temp;
                temp = left;
                left = right;
                right = temp;
                temp = far_left;
                far_left = far_right;
                far_right = temp;
            }

        }

        static void Main(string[] args)
        {
            int a = 156;
            int b = 21651;
            int c = 26;
            int d = 891;


            Swap_num.Swap<int>(ref a, ref b);
            Console.WriteLine(a + " " + b);

            Swap_num.MirrorSwapf4(ref a, ref b, ref c, ref d);
            Console.WriteLine("{0} {1} <-> {2} {3}", a,b,c,d, "d");

            Console.ReadKey();
        }
    }
}
