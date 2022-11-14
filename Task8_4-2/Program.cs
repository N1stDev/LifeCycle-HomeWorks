using System.Reflection.PortableExecutable;

namespace Task8_4_2
{
    class Program
    {
        public static int Main()
        {
            int counter, n, pairs;
 
            using (StreamReader sr = new StreamReader("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task8_4-2\\input.txt"))
            {
                counter = 0;
                string line = sr.ReadLine();

                string[] entries = line.Split();

                n = Convert.ToInt32(entries[0]);
                pairs = Convert.ToInt32(entries[1]);

                for (int i = 0; i < pairs; i++)
                {
                    entries = line.Split();

                    int index1 = Convert.ToInt32(entries[0]);
                    int index2 = Convert.ToInt32(entries[1]);
                }
            }


            return 0;
        }
    }
}