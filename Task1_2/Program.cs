using System.Runtime.InteropServices;

namespace Task1_2
{
    class StringList
    {
        string[] strList;
        int curCount = 0;
        int maxCount;

        public StringList(int listSize = 100)
        {
            if (listSize <= 0)
            {
                throw new Exception("List size can not be less than 1");
            }
            strList = new string[listSize];
            maxCount = listSize;
        }

        public void Append(string str)
        {
            if (curCount == maxCount)
            {
                throw new Exception("Max count detected!");
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
                for (int i = pos; i < curCount; i++)
                {
                    strList[pos] = strList[pos + 1];
                }
                curCount--;
            }
            else
            {
                throw new Exception("Incorrect index to delete!");
            }
        }

        public int Search(string str)
        {
            for (int i = 0; i < curCount; i++)
            {
                if (strList[i] == str)
                {
                    return i;
                }
            }
            return -1;
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
                        return;
                    }
                }
            }
            else
            {
                throw new Exception("Incorrect index to update!");
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
                throw new Exception("Incorrect index to get string!");
            }
        }

        public string Str()
        {
            string res = "";
            for (int i = 0; i < curCount; i++)
            {
                res += strList[i] + "\n";
            }

            return res;
        }
    }

    class Program
    {
        static void Main()
        {
            StringList stringList = new StringList();

            stringList.Append("asdasdd");
            stringList.Append("erwerwr");
            Console.WriteLine(stringList.Str());
        }
    }
}