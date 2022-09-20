namespace Task2_3
{
    class Program
    {
        public static int Main()
        {
            NodeList nl = new();

            nl.Append("root");
            nl.AppendPath("a", "/");
            nl.AppendPath("b", "/a");
            nl.AppendPath("c", "/a/b");
            nl.AppendPath("d", "/a/b");
            nl.AppendPath("e", "/");
            nl.AppendPath("f", "/e");
            nl.AppendPath("f", "/");

            Console.WriteLine(nl);

            Console.WriteLine("Стандартный способ получения информации через return:");
            Console.WriteLine(nl.GetNode("e"));

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

            nl.AppendPath("b", "aaa/bbb");

            return 0;
        }
    }
}