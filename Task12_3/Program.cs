using System;
using System.Security.Cryptography;

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
            .Select(x => new { name = x.Key, sum = workers.Where(w => w.Name == x.Key).Sum(w => w.Salary) });

        foreach (var w in workersTable)
        {
            Console.WriteLine(w);
        }

        List<string> fruits = new()
        {
            "grapes",
            "apple",
            "apple",
            "pear",
            "apple",
            "pear",
            "grapes",
            "grapes"
        };

        var fruitsTable = fruits
            .GroupBy(g => g)
            .Select(g => new {name = g.Key, count = fruits.Count(x => x == g.Key)})
            .Where(g => g.count == 3);

        Console.WriteLine();

        foreach (var f in fruitsTable)
        {
            Console.WriteLine(f);
        }

        var firstWorkerTable = workers
            .Select(g => new { name = g.Name, salary = g.Salary })
            .Where(g => g.name == workers[0].Name)
            .OrderBy(g => g.salary);

        Console.WriteLine();

        foreach (var w in firstWorkerTable)
        {
            Console.WriteLine(w);
        }

        var secondWorkerTable = workers
            .Select(g => new { name = g.Name, salary = g.Salary })
            .Where(g => g.name == workers[1].Name)
            .OrderByDescending(g => g.salary);

        Console.WriteLine();

        foreach (var w in secondWorkerTable)
        {
            Console.WriteLine(w);
        }

        var ints1 = new int[] { 1, 2, 3, 4, 5 };

        var combinations =
            from x in ints1
            from y in ints1
            from z in ints1
            where x != y && x != z && y != z
            select new { x, y, z };

        foreach (var c in combinations)
        {
            Console.WriteLine(c);
        }

        string combinationsString = 
            string.Join
            (", ",
            combinations.
            Select(s => $"({s.x}, {s.y}, {s.z})").
            ToArray()
            );

        Console.WriteLine(combinationsString);
    }
}