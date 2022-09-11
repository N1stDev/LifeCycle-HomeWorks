namespace Task1_3
{
    class Program
    {
        private static void Main(string[] args)
        {
            LongNumber a = new LongNumber("9999");
            LongNumber b = new LongNumber("90023");

            Console.WriteLine(a > b);
            Console.WriteLine((a + b).value);
        }
    }

}