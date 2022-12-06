using System;


namespace Task12_1
{
    public class Foo
    {
        public int FindMax(int[] arr) //для пункта а) 
        {
            if (arr == null || arr.Length == 0) //проверка на наличие элементов
            {
                throw new ArgumentException("Массив не может быть пуст", nameof(arr));
            }

            if (arr.Length == 1)
            {
                return arr[0];
            }

            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        public int FindMaxIndex(int[] arr) //для пункта б)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Массив не может быть пуст", nameof(arr));
            }

            //возвращает 0, тк первый элемент имеет индекс 0
            if (arr.Length == 1)
            {
                return 0;
            }

            int idx = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[idx])
                {
                    idx = i;
                }
            }

            return idx;
        }

        public StructXnY FindMaxByY(StructXnY[] arr) // пункт В)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Массив не может быть пуст", nameof(arr));
            }

            if (arr.Length == 1)
            {
                return arr[0];
            }

            StructXnY max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Y > max.Y)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        public StrXnY4G2[] SortByYnTransform(StrXnY4G[] arr) // пункт г)
        {
            Array.Sort(arr, (s1, s2) => s1.CompareTo(s2));

            StrXnY4G2[] res = new StrXnY4G2[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                res[i].X = arr[i].Y;
                res[i].Y = arr[i].X;
            }

            return res;
        }

    }
}