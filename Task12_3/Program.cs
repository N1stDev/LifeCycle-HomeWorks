class Worker
{
    public string Name;
    public int Salary;

    public Worker(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }
}

class Program
{
    static void Main()
    {
        int[] ints = new int[10];
        for (int i = 1; i <= ints.Length; i++)
        {
            ints[i - 1] = i;
        }

        var multiplesDict = new Dictionary<string, List<int>>();
        multiplesDict.Add("четные", new() { 0, });
        multiplesDict.Add("нечетные", new() { 0, });

        for (int i = 0; i < ints.Length; i++)
        {
            if (ints[i] % 2 == 0)
            {
                multiplesDict["четные"].Add(ints[i]);
                multiplesDict["четные"][0] += ints[i];
            }
            else
            {
                multiplesDict["нечетные"].Add(ints[i]);
                multiplesDict["нечетные"][0] += ints[i];
            }
        }
        
        Console.WriteLine("Для четных сумма: " + multiplesDict["четные"][0]);
        Console.WriteLine("Для нечетных сумма: " + multiplesDict["нечетные"][0] + "\n");

        var even = ints.Where(x => x % 2 == 0);
        var evenTuple = (even, even.Sum());

        var odd = ints.Where(x => x % 2 != 0);
        var oddTuple = (odd, odd.Sum());

        Console.WriteLine("Для четных сумма: " + evenTuple.Item2);
        Console.WriteLine("Для нечетных сумма: " + oddTuple.Item2 + "\n");

        Random rand = new(123);
        string[] names = { "Петров", "Сидоров", "Иванов", "Смирнов", "Котов" };

        List<Worker> workers = new();

        for (int i = 0; i < 100; i++)
        {
            workers.Add(
                new(
                    names[rand.Next(0, names.Length)], 
                    rand.Next(100, 400)
                    )
                );
        }

        var workersTable = workers
            .GroupBy(x => x.Name)
            .Select(g => new { name = g.Key, sum = workers.Where(w => w.Name == g.Key).Sum(w1 => w1.Salary) });

        foreach (var w in workersTable)
        {
            Console.WriteLine(w);
        }
    }
}