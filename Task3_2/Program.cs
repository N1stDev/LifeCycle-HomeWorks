using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using System.Text;
using System.Threading.Tasks;


namespace task3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet4>
            const string FileName = @"../../../SavedLoan.bin";
            // </Snippet4>

            // <Snippet1>
            Loan TestLoan = new Loan(10002.0, 7.5, 36, "Neil Why");
            // </Snippet1>

            // <Snippet5>
            if (File.Exists(FileName)) //создание объекта TestLoan
            {
                Console.WriteLine("Reading saved file");
                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                TestLoan = (Loan)deserializer.Deserialize(openFileStream);
                TestLoan.TimeLastLoaded = DateTime.Now;
                openFileStream.Close();
            }
            // </Snippet5>

            // <Snippet2>
            TestLoan.PropertyChanged += (_, __) => Console.WriteLine($"New customer value: {TestLoan.Customer}");

            TestLoan.Customer = "Henry Clay";
            Console.WriteLine(TestLoan.InterestRatePercent);
            TestLoan.InterestRatePercent = 7.1;
            Console.WriteLine(TestLoan.InterestRatePercent);
            // </Snippet2>

            // <Snippet6>
            Stream SaveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, TestLoan);
            SaveFileStream.Close();
            // </Snippet6>
        }
    }
}