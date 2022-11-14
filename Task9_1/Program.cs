interface ICustomComparable<T>
{
    int CustomCompare(T val1, T val2);
}

class A: ICustomComparable<int>
{
    public int CustomCompare(int val1, int val2)
    {
        if (val1 > val2)
        {
            return 1;
        }
        else if (val1 == val2)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}

class B: ICustomComparable<string>
{
    public int CustomCompare(string val1, string val2)
    {
        int res = String.Compare(val1, val2);

        if (res > 0)
        {
            return 1;
        }
        else if (res == 0)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}

class CustomArray<T>
{
    int n;
    T[] arr;
    public CustomArray(int count)
    {
        n = count;
        arr = new T[n];
    }

    public void Sort()
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                //int res = CustomCompare(arr[j], arr[j + 1]);
                if (res == 1)
                {
                    T tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }
        }
    }

    public T this[int index]
    {
        get
        {
            if (index >= 0 && index < n)
            {
                return arr[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }

        set
        {
            if (index >= 0 && index < n)
            {
                arr[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        CustomArray<int> arr1 = new(5);
        #region Заполняем первый массив
        arr1[0] = -28;
        arr1[1] = 14;
        arr1[2] = 12;
        arr1[3] = 0;
        arr1[4] = -100;
        #endregion

        CustomArray<string> arr2 = new(5);
        #region Заполняем второй массив
        arr2[0] = "aaaa";
        arr2[1] = "bbbb";
        arr2[2] = "ksdjsdls";
        arr2[3] = "a";
        arr2[4] = "asasasaksal;ska";
        #endregion
    }
}
