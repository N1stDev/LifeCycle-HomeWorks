using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{

    public class Enum1
    {
       enum Days { Monday=1 , Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };


        static void Main(string[] args)
        {
            Type weekdays = typeof(Days);

            Console.WriteLine("Enter weekday`s number: ");

            int i = int.Parse(Console.ReadLine());

            if (0 < i && i < 8)
                Console.WriteLine("{0} = {1}", i, Enum.GetName(weekdays, i), "d");
            else { throw new Exception("Неверное число!"); }
            Console.ReadKey();
           
        }
    }

}
