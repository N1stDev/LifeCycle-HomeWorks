using System.Diagnostics;

namespace Task14_1
{
    class Program
    {
        static void Foo(List<int> l)
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + $"\\files\\Group{Task.CurrentId}.txt";
            try
            {
                using (var tw = new StreamWriter(path))
                {
                    foreach (var el in l)
                    {
                        tw.WriteLine(el);
                    }
                }
            }
            catch
            {

            }
            
            Thread.Sleep(15000);
        }

        public static void Main()
        {
            Random r = new();
            List<List<int>> groups = new();
            

            for (int i = 0; i < 10; i++)
            {
                List<int> group = new();

                for (int j = 0; j < 100; j++)
                {
                    group.Add(r.Next());
                }

                groups.Add(group);
            }

            ParallelLoopResult result = Parallel.ForEach<List<int>>(groups, Foo);
        }
    }
}

