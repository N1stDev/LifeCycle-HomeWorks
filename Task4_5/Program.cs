﻿using System.Numerics;

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
        /*
        static bool IsOnSegment(float x, float y, float x1, float y1, float x2, float y2)
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
        static bool CheckConvex(Point[] points)
        {
            // проверим пересекаются ли две пары проивоположных прямых
            for (int i = 0; i < 2; i++)
            {
                //формируем уравнения двух прямых
                // ax + by = c
                float a1 = 1 / (points[(i+1) % 4].X - points[i].X);
                float b1 = 1 / (points[i].Y - points[(i + 1) % 4].Y);
                float c1 = points[i].X / (points[(i + 1) % 4].X - points[i].X) -
                    points[i].Y / (points[(i + 1) % 4].Y - points[i].Y);

                float a2 = 1 / (points[(i + 3) % 4].X - points[i + 2].X);
                float b2 = 1 / (points[i + 2].Y - points[(i + 3) % 4].Y);
                float c2 = points[i + 2].X / (points[(i + 3) % 4].X - points[i + 2].X) -
                    points[i + 2].Y / (points[(i + 3) % 4].Y - points[i + 2].Y);

                if (a1 * b2 != a2 * b1)  // если прямые не параллельны - ищем где они пересекаются
                {
                    float x = (c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
                    float y = (a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
                    bool onFirst = IsOnSegment(x, y, points[i].X, points[i+1].X, points[i].Y, points[i + 1].Y);
                    bool onSecond = IsOnSegment(x, y, points[i+2].X, points[i+2].Y, points[(i+3)%4].X, points[(i+3)%4].Y);
                    if (onFirst || onSecond) // если точка пересечения лежит на одном из отрезков - невыпуклый
                    {
                        return false;
                    }
                }

            }
            return true;
        }*/

        static Point[] SortedPoints(Point[] points) // сортировка по x, если x1 = x2 - то их по y
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3 - i; j++)
                {
                    if (points[j].X > points[j + 1].X)
                    {
                        Point tmp = points[j];
                        points[j] = points[j + 1];
                        points[j + 1] = tmp;
                    }
                    else if (points[j].X == points[j + 1].X)
                    {
                        if (points[j].Y > points[j + 1].Y)
                        {
                            Point tmp = points[j];
                            points[j] = points[j + 1];
                            points[j + 1] = tmp;
                        }
                    }
                }
            }
            return points;
        }

        static double GetSquare(Point[] points) // вычисление площади по формуле Гаусса
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

            return Math.Abs(num1 + points[3].X * points[0].Y - num2 - points[0].X * points[3].Y) / 2;
        }

        static double GetPerimeter(Point[] points)
        {
            double perimeter = 0;
            for (int i = 0; i < 4; i++)
            {
                perimeter += Math.Sqrt(Math.Pow(points[(i + 1) % 4].X - points[i].X, 2) +
                    Math.Pow(points[(i + 1) % 4].Y - points[i].Y, 2));
            }
            return perimeter;
        }
        

        public static int Main()
        {
            // координаты задаются по часовой стрелке
            Point[] points = new Point[] { new Point(0, 0), new Point(0, 50), new Point(100, 50), new Point(100, 0) };

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Convert.ToString(points[i].X) + " " + Convert.ToString(points[i].Y));
            }
            
            double square = Math.Round(GetSquare(points), 3);
            double perimeter = Math.Round(GetPerimeter(points), 3);

            Console.WriteLine("Perimeter: " + Convert.ToString(perimeter));
            Console.WriteLine("Square: " + Convert.ToString(square));

            return 0;
        }
    }
}
