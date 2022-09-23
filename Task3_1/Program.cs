using System.IO;

// https://acmp.ru/index.asp?main=status&id_t=24&id_mem=414246
namespace Task3_1
{
    class Program
    {
        public static int Main()
        {
            int n, m;

            StreamReader sr = new StreamReader("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task3_1\\input.txt");
            string[] line = sr.ReadLine().Split();
            sr.Close();

            n = int.Parse(line[0]);
            m = int.Parse(line[1]);

            int res = FindSolution(n, m);

            StreamWriter sw = new StreamWriter("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task3_1\\output.txt");
            sw.Write(res);
            sw.Close();

            return 0;
        }

        public static int FindSolution(int n, int m)
        {
            if (m > n)  return 0;
            if (m == 0) return 1;
            if (m == 1) return n;

            int maxInterval = (n - m) / (m - 1);

            //for (int i = 0; i <= maxInterval; i++)
            //{
            // res += n - m * (i + 1) + i + 1; = n - mi - m + i + 1
            //}

            // i = 0 -> res += n - m + 1
            // i = 1 -> res += n - m + 1 + (1 - m)
            // i = 2 -> res += n - m + 1 + 2(1 - m)
            // значит это арифметическая прогрессия с шагом 1 - m
            // тогда лучше вычислим res по сумме арифметической прогрессии
            // первый член n - m + 1, последний член n - m + 1 + maxInterval(1-m), кол-во: maxInterval+1

            int res = ((n - m + 1) + (n - m + 1 + maxInterval * (1 - m))) * (maxInterval+1) / 2;

            return res;
        }
    }
}