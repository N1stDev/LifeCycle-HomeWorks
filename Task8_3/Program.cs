using System;
using System.IO;

namespace Task8_3
{
    class TwoParams<A,B> where B : class
    {
        A obj1;
        B obj2;

        public TwoParams(A o1, B o2)
        {
            obj1 = o1;
            obj2 = o2;
        }

        public void showTypes()
        {
            Console.WriteLine("К типу A относится " + typeof(A));
            Console.WriteLine("К типу B относится " + typeof(B));
        }
        public A getObj1()
        {
            return obj1;
        }

        public B getObj2()
        {
            return obj2;
        }
    }

    class Program
    {
        static int Main()
        {
            TwoParams<int,string> example_1 = new TwoParams<int,string>(173, "Рост Стэтхема");

            example_1.showTypes();

            int height = example_1.getObj1();
            Console.WriteLine("Значение: " + height);

            string value = example_1.getObj2();
            Console.WriteLine("Значение: " + value);

            return 0;
        }
    }
}



