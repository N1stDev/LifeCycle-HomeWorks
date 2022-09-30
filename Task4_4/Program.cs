namespace Task4_4
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;

        }
        static int Main()
        {
            int a = 100;
            int b = -100;

            Swap(ref a, ref b);

            Console.WriteLine(a);
            Console.WriteLine(b);

            return 0;
        }
    }
}