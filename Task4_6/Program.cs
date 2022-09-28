using System.IO;

//https://acmp.ru/index.asp?main=source&id=17708579

namespace Task4_6
{
    class Program
    {
        static int FindNeighbours(int x, int y, int[] field)
        {
            int neighbours = 0;
            if ((y - 1 >= 0) && (field[(y - 1) * 8 + x] == 1))
            {
                neighbours += 1;
            }
            if ((y + 1 <= 7) && (field[(y + 1) * 8 + x] == 1))
            {
                neighbours += 1;
            }
            if ((x - 1 >= 0) && (field[y * 8 + x - 1] == 1))
            {
                neighbours += 1;
            }
            if ((x + 1 <= 7) && (field[y * 8 + x + 1] == 1))
            {
                neighbours += 1;
            }
            return neighbours;
        }
        static void Solution()
        {
            StreamReader sr = new StreamReader("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task4_6\\input.txt");

            int n = int.Parse(sr.ReadLine());

            int[] field = new int[64];

            int perimeter = 0;

            string[] tmp = new string[2];

            int x, y;

            for (int i = 0; i < n; i++)
            {
                tmp = sr.ReadLine().Split();
                x = int.Parse(tmp[0]) - 1;
                y = int.Parse(tmp[1]) - 1;
                field[y * 8 + x] = 1;
                perimeter += 4 - FindNeighbours(x, y, field)*2;
            }

            sr.Close();

            StreamWriter sw = new StreamWriter("D:\\Documents\\GitHub\\LifeCycle-HomeWorks\\Task4_6\\output.txt");
            sw.Write(perimeter);
            sw.Close();
        }

        public static int Main()
        {

            Solution();
            
            return 0;
        }
    }
}
