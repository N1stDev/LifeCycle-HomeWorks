using System;
using System.IO;
using System.Collections.Generic;

// https://acmp.ru/index.asp?main=source&id=17867826

namespace Task5_3
{
    class Program
    {        
        static void Solution()
        {
            StreamReader sr = new StreamReader("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task5_3\\input.txt");
            StreamWriter sw = new StreamWriter("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task5_3\\output.txt");

            int n = int.Parse(sr.ReadLine());
            long k, p, answer;
            string result;
            string[] tmp = new string[2];

            for (int i = 0; i < n; i++)
            {
                result = "No solution";
                tmp = sr.ReadLine().Split();
                k = long.Parse(tmp[0]);
                p = long.Parse(tmp[1]);
                long len = (long)(Math.Pow(2, p)) - 1;
                if (k >= 1 && k <= len)
                {
                    long j = 1;
                    while (true)
                    {
                        if ((k - (long)Math.Pow(2, j-1)) % (long)Math.Pow(2, j) == 0)
                        {
                            answer = j;
                            break;
                        }
                        j++;
                    }
                    result = Convert.ToString(answer);
                }
                sw.Write(result + "\n");
            }

            sr.Close();
            sw.Close();
        }

        public static int Main()
        {
            Solution();

            return 0;
        }
    }
}