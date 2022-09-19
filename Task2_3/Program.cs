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

            Console.WriteLine("Стандартный способ получения информации через return:");
            Console.WriteLine(nl.GetNode("ch2.1"));

            // Создаем пустую ноду
            Node n;

            // запускаем поиск (success будет true, если нода найдена)
            bool success = nl.GetNodeOut("ch2.1", out n);

            Console.WriteLine("Получилось ли получить информацию через out:");
            Console.WriteLine(success);
            Console.WriteLine("Получение информации через out:");
            Console.WriteLine(n);

            success = nl.GetNodeOut("asdasd", out n);

            Console.WriteLine("Получилось ли получить информацию через out:");
            Console.WriteLine(success);
            Console.WriteLine("Получение информации через out:");
            Console.WriteLine(n);

            nl.GetNodeRefBool("ch2.1", out n, ref success);

            Console.WriteLine("Здесь переменная success передеается в функцию по ссылке:");
            Console.WriteLine(success);
            Console.WriteLine("Получение информации через out:");
            Console.WriteLine(n);

            Console.WriteLine("Преобразование строки в ноду:");
            Console.WriteLine("тестовая нода".ToNode());

            return 0;
        }
    }
}