using System.Text;

class NumberArray
{
    public delegate void SortMethod(NumberArray array);

    int[] array;

    public NumberArray(uint count)
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
        NumberArray newArray = new((uint)array.Length);

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

    enum MenuOption
    {
        arrayNotCreated,
        arrayCreated,
        arrayIsReadyToBeSorted
    }

    static void Main()
    {
        bool exitFlag = false;
        MenuOption currentMenuOption = MenuOption.arrayNotCreated;
        string input = "";

        NumberArray numberArray = new(0);

        while (!exitFlag)
        {
            Console.Clear();

            if (currentMenuOption == MenuOption.arrayNotCreated)
            {
                Console.WriteLine("Введите длину требуемого массива:");
                input = Console.ReadLine();

                try
                {
                    uint length = Convert.ToUInt32(input);
                    numberArray = new NumberArray(length);
                    currentMenuOption = MenuOption.arrayCreated;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено некорректное значение.");
                    Console.ReadKey();
                }
            }
            else if (currentMenuOption == MenuOption.arrayCreated)
            {
                Console.WriteLine(numberArray);
                Console.WriteLine("(1) Заполнить массив случайными числами");
                Console.WriteLine("(2) Сортировать массив");
                Console.WriteLine("(3) Заново создать массив");
                Console.WriteLine("(4) Выйти из программы");
                input = Console.ReadLine();

                try
                {
                    uint choice = Convert.ToUInt32(input);
                    
                    if (choice == 1)
                    {
                        numberArray.SetRandom(0, numberArray.GetLength());
                    }
                    else if (choice == 2)
                    {
                        currentMenuOption = MenuOption.arrayIsReadyToBeSorted;
                    }
                    else if (choice == 3)
                    {
                        currentMenuOption = MenuOption.arrayNotCreated;
                    }
                    else if (choice == 4)
                    {
                        exitFlag = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено некорректное значение.");
                    Console.ReadKey();
                }
            }
            else if (currentMenuOption == MenuOption.arrayIsReadyToBeSorted)
            {
                Console.WriteLine(numberArray);
                Console.WriteLine("(1) Сортировать пузырьком");
                Console.WriteLine("(2) Сортировать слиянием");
                input = Console.ReadLine();

                try
                {
                    uint choice = Convert.ToUInt32(input);
                    long time;

                    if (choice == 1)
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        numberArray.Sort(BubbleSort);
                        watch.Stop();
                        time = watch.ElapsedMilliseconds;

                        Console.WriteLine(
                            "На сортировку массива длиной " + numberArray.GetLength() + " пузырьком ушло " +
                            time + " миллисекунд");
                        Console.ReadKey();
                    }
                    else if (choice == 2)
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        numberArray.Sort(MergeSort);
                        watch.Stop();
                        time = watch.ElapsedMilliseconds;

                        Console.WriteLine(
                            "На сортировку массива длиной " + numberArray.GetLength() + " слиянием ушло " +
                            time + " миллисекунд");
                        Console.ReadKey();
                    }

                    currentMenuOption = MenuOption.arrayCreated;
                }
                catch (Exception)
                { 
                    Console.WriteLine("Введено некорректное значение.");
                    Console.ReadKey();
                }
            }
        }
    }
}