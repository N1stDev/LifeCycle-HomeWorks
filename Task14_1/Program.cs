using System.Diagnostics;

namespace Task14_1
{
    class Program
    {
        public static void Foo(object obj)
        {
            int a = 9;
            for (int i = 0; i < 99999999; i++)
            {
                a += 11;
            }
            ((CountdownEvent)obj).Signal();
        }

        public static void Main()
        {
            for (int n = 1; n <= 10; n++)
            {
                CountdownEvent ce = new CountdownEvent(n);
                Stopwatch timer = new Stopwatch();

                timer.Start();
                for (int i = 0; i < n; i++)
                {
                    var t = new Thread(Foo);
                    t.Start(ce);
                }

                ce.Wait();
                timer.Stop();

                Console.WriteLine($"Thread: {timer.ElapsedMilliseconds} ms");

                ce = new CountdownEvent(n);

                timer.Restart();
                for (int i = 0; i < n; i++)
                {
                    ThreadPool.QueueUserWorkItem(Foo, ce);
                }

                ce.Wait();
                timer.Stop();

                Console.WriteLine($"ThreadPool: {timer.ElapsedMilliseconds} ms\n\n");
            }
        }
    }
}
