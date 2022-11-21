using System.Text;

class NumberArray
{
    public delegate void SortMethod(NumberArray array);

    int[] array;

    public NumberArray(int count)
    {
        array = new int[count];
    }

    public int GetLength()
    {
        return array.Length;
    }

    public void Sort(SortMethod sortMethod)
    {
        sortMethod.Invoke(this);
    }

    public void SetRandom(int minValue, int maxValue)
    {
        Random rng = new();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rng.Next(minValue, maxValue);
        }
    }

    public NumberArray GetCopy()
    {
        NumberArray newArray = new(array.Length);

        for (int i = 0; i < array.Length; i++)
        {
            newArray.array[i] = array[i];
        }

        return newArray;
    }

    public override string ToString()
    {
        StringBuilder s = new();
        s.Append("[");

        foreach (int i in array)
        {
            s.Append(i.ToString() + " ");
        }

        s.Replace(' ', ']', s.Length - 1, 1);
        return s.ToString();
    }

    public int this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }
}

class Program
{
    static void MergeSort(NumberArray array)
    {
        Sort(0, array.GetLength() - 1);

        void Sort(int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                Sort(left, mid);
                Sort((mid + 1), right);
                MergeMethod(left, (mid + 1), right);
            }
        }

        void MergeMethod(int left, int mid, int right)
        {
            int[] temp = new int[array.GetLength()];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (array[left] <= array[mid])
                    temp[tmp_pos++] = array[left++];
                else
                    temp[tmp_pos++] = array[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = array[left++];
            while (mid <= right)
                temp[tmp_pos++] = array[mid++];
            for (i = 0; i < num_elements; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }
    }

    static void BubbleSort(NumberArray array)
    {
        bool flag = true;

        while (flag)
        {
            flag = false;

            for (int i = 1; i < array.GetLength(); i++)
            {
                if (array[i] < array[i - 1])
                {
                    flag = true;
                    int temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        int length = 20;

        NumberArray arr1 = new(length);

        arr1.SetRandom(0, length);
        NumberArray arr2 = arr1.GetCopy();

        Console.WriteLine(
            "Первый массив до сортировки пузырьком: " + arr1);
        arr1.Sort(BubbleSort);
        Console.WriteLine(
            "Первый массив после сортировки пузырьком: " + arr1 + "\n");

        Console.WriteLine(
            "Второй массив до сортировки слиянием: " + arr2);
        arr1.Sort(MergeSort);
        Console.WriteLine(
            "Второй массив после сортировки слиянием: " + arr2 + "\n");

        int length1 = 10000;
        long time1 = 0;
        long time2 = 0;

        arr1 = new(length1);
        arr1.SetRandom(0, length1);
        arr2 = arr1.GetCopy();

        var watch = System.Diagnostics.Stopwatch.StartNew();
        arr1.Sort(BubbleSort);
        watch.Stop();
        time1 = watch.ElapsedMilliseconds;

        Console.WriteLine(
            "На сортировку массива длиной " + length1 + " пузырьком ушло " +
            time1 + " миллисекунд");

        watch.Restart();
        arr2.Sort(MergeSort);
        watch.Stop();
        time2 = watch.ElapsedMilliseconds;

        Console.WriteLine(
            "На сортировку массива длиной " + length1 + " слиянием ушло " +
            time2 + " миллисекунд");

    }
}