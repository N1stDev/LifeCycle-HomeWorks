using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;

class Triangle
{
    public int a;
    public int b;
    public int c;

    public Triangle(int a, int b, int c)
    {
        bool condition1 = a <= 0 || b <= 0 || c <= 0;
        bool condition2 = a > b + c || b > a + c || c > a + b;

        this.a = a;
        this.b = b;
        this.c = c;

        if (condition1 || condition2)
        {
            throw new TriangleExeption(this);
        }
    }
}

class Quadrangle
{
    public int a;
    public int b;
    public int c;
    public int d;

    public Quadrangle(int a, int b, int c, int d)
    {
        bool condition1 = a <= 0 || b <= 0 || c <= 0 || d <= 0;
        bool condition2 = a > b + c + d || b > a + c + d || c > a + b + d || d > a + b + c;

        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;

        if (condition1 || condition2)
        {
            throw new QuadringleExeption(this);
        }
    }
}

class Circle
{
    public int r;

    public Circle(int r)
    {
        this.r = r;

        if (r <= 0)
        {
            throw new CircleExeption(this);
        }
    }
}

class TriangleExeption : GeometryException
{
    public TriangleExeption(Triangle tri)
        : base("Произошла ошибка в процессе создания треугольника", 
            new int[] { tri.a, tri.b, tri.c })
    { }
}

class QuadringleExeption : GeometryException
{
    public QuadringleExeption(Quadrangle quad)
        : base("Произошла ошибка в процессе создания четырёхугольника",
            new int[] { quad.a, quad.b, quad.c, quad.d })
    { }
}

class CircleExeption : GeometryException
{
    public CircleExeption(Circle circle) 
        : base("Произошла ошибка в процессе создания круга", 
            new int[] { circle.r })
    { }
}

abstract class GeometryException : Exception
{
    protected GeometryException(string message, int[] parameters) 
        : base(message)
    {
        Parameters = parameters;
    }

    public int[] Parameters { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{");

        for (int p = 0; p < Parameters.Length; p++)
        {
            sb.Append(" " + Parameters[p]);
        }

        sb.Append(" }");

        return base.ToString() + " Параметры: " + sb;
    }
}

class Program
{
    static void Main()
    {
        Random rng = new Random();
        string filePath = "./log.txt";
        StreamWriter sw = new StreamWriter(filePath);

        for (int i = 0; i < 100; i++)
        {
            try
            {
                int choice = rng.Next(0, 3);

                if (choice == 0) new Triangle(
                    rng.Next(-100, 100),
                    rng.Next(-100, 100), 
                    rng.Next(-100, 100));
                else if (choice == 1) new Quadrangle(
                    rng.Next(-100, 100), 
                    rng.Next(-100, 100), 
                    rng.Next(-100, 100),
                    rng.Next(-100, 100));
                else new Circle(
                    rng.Next(-100, 100));
            }
            catch (CircleExeption ce)
            {
                Console.WriteLine(ce + "\n");
            }
            catch (TriangleExeption te)
            {
                Console.WriteLine(te + "\n");
                sw.WriteLine(te + "\n");
            }
            catch (QuadringleExeption qe)
            {
                Console.WriteLine(qe + "\n");
                sw.WriteLine(qe + "\n");
            }
        }

        sw.Close();
    }
}