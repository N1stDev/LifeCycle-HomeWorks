namespace Task1_3
{
    class Program
    {
        private static void Main(string[] args)
        {
            //TODO тестирование
            LongNumber a = new LongNumber("123");
            LongNumber b = new LongNumber("12");
            LongNumber c;

            Console.WriteLine(a == b);
            Console.WriteLine((a - b).value);
            Console.WriteLine((int)a);
            Console.WriteLine((long)a);
            Console.WriteLine((short)a);
            Console.WriteLine((bool)a);
            Console.WriteLine(LongNumber.TryParse("", out c));
            Console.WriteLine("123".ToLongNumber().value);

            LongNumber d = new LongNumber("123456789");
            LongNumber e = new LongNumber("77777");
            Console.WriteLine((d * e).value);
        }
    }

}