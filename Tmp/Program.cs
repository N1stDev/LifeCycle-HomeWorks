namespace Task2_3_test
{
    class Program
    {
        public static int Main()
        {
            NodeList nl = new();

            nl.Append("root");
            nl.Append("ch1", "root");
            nl.Append("ch2", "root");
            nl.Append("ch3", "root");
            nl.Append("ch4", "root");
            nl.Append("ch1.1", "ch1");
            nl.Append("ch1.2", "ch1");
            nl.Append("ch2.1", "ch2");
            nl.Append("ch3.1", "ch3");
            nl.Append("ch3.2", "ch3");
            nl.Append("ch3.2.1", "ch3.2");

            nl.Print();



            return 0;
        }
    }
}