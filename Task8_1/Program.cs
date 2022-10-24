
using System.Collections;
using System.Reflection.Metadata.Ecma335;

struct Results
{
    double writeTime = 0;
    double readTime = 0;

    public Results(double writeTime, double readTime)
    {
        this.writeTime = writeTime;
        this.readTime = readTime;
    }

    public override string ToString()
    {
        return string.Format("Write time is: ~{0} milliseconds\nRead time is: ~{1} milliseconds", writeTime, readTime);
    }
}

static class Tester
{
    public enum TestType : long
    {
        OneMillion = 1000000L,
        TenMillion = 10000000L,
        HundredMillion = 100000000L
    }
    
    public static Results SpeedTest<T, S>(T container, S s, TestType testType) where T : IList
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        long writeTime = 0L;
        long readTime = 0L;
        var rnd = new Random();

        for (long i = (long)testType; i > 0; i--)
        {
            watch.Restart();
            container.Add(s);
            writeTime += watch.ElapsedMilliseconds;

            int index = rnd.Next(0, container.Count);
            Object temp;

            watch.Restart();
            temp = container[index];
            readTime += watch.ElapsedMilliseconds;
        }

        return new((double)(writeTime / (double)testType), (double)(readTime / (double)testType));
    }
}

class Program
{
    static void Main()
    {
        string probe = "Hello World!";
        Console.WriteLine("Testing strings:");
        var results1 = Tester.SpeedTest(new List<string>(), probe, Tester.TestType.TenMillion);
        var results2 = Tester.SpeedTest(new ArrayList(), probe, Tester.TestType.TenMillion);
        
        Console.WriteLine("For List<T>:");
        Console.WriteLine(results1);
        Console.WriteLine("For ArrayList:");
        Console.WriteLine(results2);

        int probe1 = 12345;
        Console.WriteLine("\nTesting integers:");
        results1 = Tester.SpeedTest(new List<string>(), probe, Tester.TestType.TenMillion);
        results2 = Tester.SpeedTest(new ArrayList(), probe, Tester.TestType.TenMillion);
        
        Console.WriteLine("For List<T>:");
        Console.WriteLine(results1);
        Console.WriteLine("For ArrayList:");
        Console.WriteLine(results2);
    }
}