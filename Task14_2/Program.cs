using System.Diagnostics;

namespace Task14_3
{
    class Program
    {
        static object l = new();
        static double pi = 0;
        static long threadNum = 0;

        static void Foo(object obj)
        {
            var start = ((int[])obj)[0];
            var end = ((int[])obj)[1];

            double add = 0;

            for (int i = start; i < end; i++)
            {
                double dx = 1.0 / (2 * i + 1);

                if (i % 2 == 0)
                    add += dx;
                else
                    add -= dx;
            }

            lock (l)
            {
                pi += add;
            }

            Interlocked.Increment(ref threadNum);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                threadNum = 0;

                Console.Write("Threads: ");
                int tn = int.Parse(Console.ReadLine());

                Console.Write("Iterations: ");
                int itn = int.Parse(Console.ReadLine());

                double part = (double)itn / tn;

                Stopwatch timer = new Stopwatch();
                timer.Start();

                for (var i = 0; i < tn; i++)
                {
                    int start = (int)(part * i);
                    int end = (int)(part * (i + 1));
                    ThreadPool.QueueUserWorkItem(Foo, new int[] { start, end });
                }

                while (Interlocked.Read(ref threadNum) < tn)
                {
                    Thread.Sleep(10);
                }

                timer.Stop();
              
                Console.WriteLine("\n\nResult:");
                Console.WriteLine($"Pi: {pi * 4}");
                Console.WriteLine($"Threads: {tn}");
                Console.WriteLine($"Iterations: {itn}");
                Console.WriteLine($"Time: {timer.ElapsedMilliseconds}");

                break;
            }
        }
    }
}

