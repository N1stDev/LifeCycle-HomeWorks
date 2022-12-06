using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task12_1_LINQ
{
    internal class Program
    {
        struct StrXnY<T1, T2>
        {
            public T1 X;
            public T2 Y;

            public StrXnY(T1 x, T2 y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                var x = this.X.GetType().Equals(typeof(double))
                    ? String.Format("{0:F2}", this.X)
                    : this.X.ToString();
                var y = this.Y.GetType().Equals(typeof(double))
                    ? String.Format("{0:F2}", this.Y)
                    : this.Y.ToString();
                return String.Format("{{X:{0}, Y:{1}}}", x, y);
            }
        }

        static void Main(string[] args)
        {
            int[] ints = new int[] { 45, 165, 78, 37, 18, 20, 64, 941, 3, 58 };
            //a
            
            Console.WriteLine("Max el: " + ints.Max());

            //b
                              
            Console.WriteLine("Ind of max: " + ints.ToList().IndexOf(ints.ToList().Max()));

            //v

            

            Console.ReadKey();
        }
    }
}
