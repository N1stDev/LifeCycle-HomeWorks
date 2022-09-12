namespace Task1_3
{
    class Program
    {
        private static void Main(string[] args)
        {
            LongNumber a = new LongNumber("100");
            LongNumber b = new LongNumber("12");

            Console.WriteLine(a > b);
            Console.WriteLine((a - b).value);
        }
    }

}