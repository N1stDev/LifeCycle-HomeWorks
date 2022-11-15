using System;
using System.Collections.Generics;
using System.IO;
using System.Linq;

namespace Task9_2
{
    interface ICustomComparable<T>
    {
        int CustomCompare(T val1);
    }

    interface IEnumerable<T>
    {
        IEnumerator GetEnumerator();
    }

    interface IEnumerator
    {
        bool MoveObject();
        object Current {get;}
        void Reset();
    }

    class A: ICustomComparable<A>
    {
        int op1;
        int op2;

        public A(int a, int b)
        {
            op1 = a;
            op2 = b;
        }

        public int CustomCompare(A val1)
        {
            return (op1 + op2) - (val1.op1 + val1.op2);
        }

        public override string ToString()
        {
            return String.Format("op1: {0}, op2: {1}", op1, op2);
        }
    }

    class B: ICustomComparable<B>
    {
        public string op1;
        public double op2;

        public B(string a, double b)
        {
            op1 = a;
            op2 = b;
        }

        public int CustomCompare(B val1)
        {
            return (int)(op1.Length + op2) - (int)(val1.op1.Length + val1.op2);
        }

        public override string ToString()
        {
            return String.Format("op1: {0}, op2: {1}", op1, op2);
        }
    }

    class CustomArray<T> : IEnumerable<T>, T : ICustomComparable<T>
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
            bool flag = true;

            while (flag)
            {
                flag = false;
                for (int i = 1; i < n; i++)
                {
                    if (arr[i].CustomCompare(arr[i - 1]) < 0)
                    {
                        flag = true;
                        T tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
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

        /*
        bool MoveNext()
        {

        }

        object Current {get; }

        void Reset();
        */
    }

    class Program
    {
        static void Main()
        {
            CustomArray<A> arr1 = new(5);
            #region Заполняем первый массив
            arr1[0] = new(123, 12);
            arr1[1] = new(182, 74);
            arr1[2] = new(89, 29);
            arr1[3] = new(45, 92);
            arr1[4] = new(20, 7);
            #endregion

            CustomArray<B> arr2 = new(5);
            #region Заполняем второй массив
            arr2[0] = new("aaaa", 783);
            arr2[1] = new("asdkd", 1231);
            arr2[2] = new("asudioasd", 8993);
            arr2[3] = new("ask", 120);
            arr2[4] = new("asodipadsi", 483);
            #endregion

            arr1.Sort();
            arr2.Sort();

            Console.WriteLine("Первый массив после сортировки:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arr1[i]);
            }

            Console.WriteLine("Второй массив после сортировки:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arr2[i]);
            }
        }
    }
}


