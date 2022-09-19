namespace Task2_3
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

            Console.WriteLine(nl);

            // Создаем пустую ноду
            Node n;

            // запускаем поиск (success будет true, если нода найдена)
            bool success = nl.GetNodeFromArg("ch2.1", out n);

            Console.WriteLine(success);
            Console.WriteLine(n);

            success = nl.GetNodeFromArg("asdasd", out n);

            Console.WriteLine(success);
            Console.WriteLine(n);

            return 0;
        }
    }
}