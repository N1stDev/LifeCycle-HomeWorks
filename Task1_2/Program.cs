using System.Runtime.InteropServices;

namespace Task1_2
{
    class StringList
    {
        // Тимофей, здесь можно сделать геттеры и сеттеры
        string[] strList;
        int curCount;
        int maxCount;

        public StringList(int listSize = 100)
        {
            if (listSize <= 0)
            {
                Console.WriteLine("Incorrect size! Array len is set to default=100");
                listSize = 100;
            }
            strList = new string[listSize];
            curCount = 0;
            maxCount = listSize;
        }

        public void Insert(string str)
        {
            if (curCount == maxCount)
            {
                Console.WriteLine("Error! Max len has been reached");
            }
            else
            {
                strList[curCount] = str;
                curCount++;
            }
        }

        public void Delete(int pos)
        {
            if (pos < curCount && pos >= 0)
            {
                for (int i = 0; i < curCount; i++)
                {
                    if (i == curCount - 1)
                    {
                        strList[pos] = null;
                    }
                    else if (i >= pos)
                    {
                        strList[pos] = strList[pos + 1];
                    }
                }
                curCount--;
            }
            else
            {
                Console.WriteLine("Incorrect index!");
            }
        }

        public int Search(string str)
        {
            int pos = -1;
            for (int i = 0; i < curCount; i++)
            {
                if (strList[i] == str)
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1)
            {
                Console.WriteLine("String has not been found! -1 returned");
            }
            return pos;
        }

        public void Update(int pos, string newstr)
        {
            if (pos < curCount && pos >= 0)
            {
                for (int i = 0; i < curCount; i++)
                {
                    if (i == pos)
                    {
                        strList[i] = newstr;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect index!");
            }
        }

        public string GetAt(int pos)
        {
            if (pos < curCount && pos >= 0)
            {
                return strList[pos];
            }
            else
            {
                Console.WriteLine("Incorrect index! Empty string returned");
                return "";
            }
        }

        public void Print()
        {
            for (int i = 0; i < curCount; i++)
            {
                Console.WriteLine(strList[i]);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            StringList stringList = new StringList();
            int inputPos;
            string inputStr;

            while (true)
            {
                int choice = Menu();
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter a string: ");
                            stringList.Insert(Console.ReadLine());
                            break;
                        case 2:
                            Console.Write("Enter a number: ");
                            stringList.Delete(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 3:
                            Console.Write("Enter a string: ");
                            int pos = stringList.Search(Console.ReadLine());
                            Console.WriteLine($"Found! Position is {pos}");
                            break;
                        case 4:
                            Console.Write("Enter a string: ");
                            inputStr = Console.ReadLine();
                            Console.Write("Enter a number: ");
                            inputPos = Convert.ToInt32(Console.ReadLine());
                            stringList.Update(inputPos, inputStr);
                            break;
                        case 5:
                            Console.Write("Enter a number: ");
                            inputPos = Convert.ToInt32(Console.ReadLine());
                            string str = stringList.GetAt(inputPos);
                            Console.WriteLine($"Found! String is {str}");
                            break;
                        case 6:
                            stringList.Print();
                            break;
                        case 7:
                            Console.WriteLine("Program is finished!");
                            return;

                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect input!");
                }

            }
        }

        static int Menu()
        {
            Console.WriteLine("Choose action number: ");
            Console.WriteLine("1. Insert string");
            Console.WriteLine("2. Delete string");
            Console.WriteLine("3. Search string");
            Console.WriteLine("4. Update string");
            Console.WriteLine("5. Get string");
            Console.WriteLine("6. Print string list");
            Console.WriteLine("7. Exit");

            while (true)
            {
                try
                {
                    Console.Write("Enter a number: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice >= 1 && choice <= 7)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number! Try again!");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect input! Try again!");
                }
            }
        }
    }
}