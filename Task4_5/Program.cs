using System.Numerics;
using System.Reflection.PortableExecutable;

namespace Task4_5
{

    class Point
    {
        private double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return this.x; }
        }

        public double Y
        {
            get { return this.y; }
        }

    }
    class Program
    {
        
        static bool IsOnSegment(double x, double y, double x1, double y1, double x2, double y2)
        {
            if ((x <= x1 && x >= x2) || (x <= x2 && x>= x1))
            {
                if ((y <= y1 && y >= y2) || (y <= y2 && y >= y1))
                {
                    return true;
                }
            }
            return false;
        }
        
        static bool IsDataCorrect(Point[] points)
        {
            // проверим пересекаются ли противоположные отрезки
            for (int i = 0; i < 2; i++)
            {
                //формируем уравнения двух прямых
                // ax + by = c
                double a1 = 1 / (points[(i+1) % 4].X - points[i].X);
                double b1 = 1 / (points[i].Y - points[(i + 1) % 4].Y);
                double c1 = points[i].X / (points[(i + 1) % 4].X - points[i].X) -
                    points[i].Y / (points[(i + 1) % 4].Y - points[i].Y);

                double a2 = 1 / (points[(i + 3) % 4].X - points[i + 2].X);
                double b2 = 1 / (points[i + 2].Y - points[(i + 3) % 4].Y);
                double c2 = points[i + 2].X / (points[(i + 3) % 4].X - points[i + 2].X) -
                    points[i + 2].Y / (points[(i + 3) % 4].Y - points[i + 2].Y);

                if (a1 * b2 != a2 * b1)  // если прямые не параллельны - ищем где они пересекаются
                {
                    double x = (c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
                    double y = (a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
                    bool onFirst = IsOnSegment(x, y, points[i].X, points[i+1].X, points[i].Y, points[i + 1].Y);
                    bool onSecond = IsOnSegment(x, y, points[i+2].X, points[i+2].Y, points[(i+3)%4].X, points[(i+3)%4].Y);
                    if (onFirst && onSecond) // если точка пересечения лежит на обоих отрезках - они пересекаются
                    {
                        return false;
                    }
                }

            }

            //проверим лежат ли на одной прямой смежные стороны
            for (int i = 0; i < 4; i++)
            {
                //формируем уравнения двух прямых
                // ax + by = c
                double a1 = 1 / (points[(i + 1) % 4].X - points[i].X);
                double b1 = 1 / (points[i].Y - points[(i + 1) % 4].Y);
                double c1 = points[i].X / (points[(i + 1) % 4].X - points[i].X) -
                    points[i].Y / (points[(i + 1) % 4].Y - points[i].Y);

                double a2 = 1 / (points[(i + 2) % 4].X - points[(i + 1) % 4].X);
                double b2 = 1 / (points[(i + 1) % 4].Y - points[(i + 2) % 4].Y);
                double c2 = points[(i + 1) % 4].X / (points[(i + 2) % 4].X - points[(i + 1) % 4].X) -
                    points[(i + 1) % 4].Y / (points[(i + 2) % 4].Y - points[(i + 1) % 4].Y);

                if (a1 * b2 == a2 * b1)  // если смежные прямые параллельны - они лежат на одной прямой
                {
                    return false;
                }
            }
            return true;
        }

        static void GetSquare(Point[] points, out double square) // вычисление площади по формуле Гаусса
        {
            double num1 = 0;
            for (int i = 0; i < 3; i++)
            {
                num1 += points[i].X * points[i + 1].Y;
            }

            double num2 = 0;
            for (int i = 0; i < 3; i++)
            {
                num2 += points[i + 1].X * points[i].Y;
            }

            square =  Math.Abs(num1 + points[3].X * points[0].Y - num2 - points[0].X * points[3].Y) / 2;
        }

        static void GetPerimeter(Point[] points, out double perimeter)
        {
            perimeter = 0;
            for (int i = 0; i < 4; i++)
            {
                perimeter += Math.Sqrt(Math.Pow(points[(i + 1) % 4].X - points[i].X, 2) +
                    Math.Pow(points[(i + 1) % 4].Y - points[i].Y, 2));
            }
        }      

        public static int Main()
        {
            // координаты задаются по порядку (по кругу)
            Point[] points = new Point[] { new Point(0, 0), new Point(0, 30), new Point(30, 30), new Point(30, 0) };

            if (!IsDataCorrect(points))
            {
                throw new Exception("Incorrect data!");
            }

            double square;
            GetSquare(points, out square);
            double perimeter;
            GetPerimeter(points, out perimeter);

            Console.WriteLine("Perimeter: " + Convert.ToString(perimeter));
            Console.WriteLine("Square: " + Convert.ToString(square));

            return 0;
        }
    }
}
