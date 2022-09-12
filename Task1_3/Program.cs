namespace Task1_3
{
    class Program
    {
        private static void Main(string[] args)
        {
            LongNumber a = new LongNumber("99999");
            LongNumber b = new LongNumber("00010000");

            Console.WriteLine(a == b);
            Console.WriteLine((a - b)._value);
        }
    }

}