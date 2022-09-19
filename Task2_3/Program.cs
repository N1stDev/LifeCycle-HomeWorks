namespace Task2_3
{
    class Program
    {
        public static int Main()
        {
            NodeList nl = new (11);

            nl.AddNode("root");
            nl.AddNode("ch1", "root");
            nl.AddNode("ch2", "root");
            nl.AddNode("ch3", "root");
            //nl.AddNode("ch4", "root");
            nl.AddNode("ch1.1", "ch1");
            nl.AddNode("ch1.2", "ch1");
            nl.AddNode("ch2.1", "ch2");
            nl.AddNode("ch3.1", "ch3");
            nl.AddNode("ch3.2", "ch3");
            nl.AddNode("ch3.2.1", "ch3.2");

            nl.Print();



            return 0;
        }
    }
}