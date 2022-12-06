using System;

namespace Task12_1

{
    public struct StructXnY // структура для пункта в)
    {
        public int X;
        public int Y;

        public StructXnY(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }
    }

    public struct StrXnY4G : IComparable // первая структура для пункта г)
    {
        public int X;
        public double Y;

        public StrXnY4G(int x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }

        public int CompareTo(object obj)
        {
            StrXnY4G s = (StrXnY4G)obj;
            return Y.CompareTo(s.Y);
        }
    }

    public struct StrXnY4G2 // вторая структура для пункта г)
    {
        public double X;
        public int Y;

        public StrXnY4G2(double x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }
    }

}
