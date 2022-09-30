using System.ComponentModel.DataAnnotations;

namespace Task4_3
{
    class Program
    {
        static int GetSum(params int[] nums)
        {
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            return sum;

        }
        static int Main()
        {
            int sum = GetSum(1, 2, 3, 4, 5, 6, 7, 8);

            Console.WriteLine(sum);

            return 0;
        }
    }
}