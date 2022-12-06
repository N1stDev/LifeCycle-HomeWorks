

static class Sorter
{
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
        Console.WriteLine("Для нечетных сумма: " + multiplesDict["нечетные"][0]);

        var even = ints.ToList().Where(x => x % 2 == 0);
        var even_tuple = (even, even.Sum());

        var odd = ints.ToList().Where(x => x % 2 != 0);
        var odd_tuple = (odd, odd.Sum());

        Console.WriteLine("Для четных сумма: " + even_tuple.Item2);
        Console.WriteLine("Для нечетных сумма: " + odd_tuple.Item2);
    }
}