using System.IO;
using System.Windows.Forms;

namespace Task10_5
{
    class KeyboardManager
    {
        public delegate void KeyPress(char key);
        public event KeyPress ThreeKeyPressed;
        public event KeyPress FiveKeyPressed;
        public event KeyPress DigitKeyPressed;
        public event KeyPress AnyKeyPressed;

        public void Run()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();
                Console.WriteLine("\n--------------");
                if (key.KeyChar >= '0' && key.KeyChar <= '9')
                {
                    DigitKeyPressed(key.KeyChar);
                }
                if (key.KeyChar == '3')
                {
                    ThreeKeyPressed(key.KeyChar);
                }
                if (key.KeyChar == '5')
                {
                    FiveKeyPressed(key.KeyChar);
                }
                AnyKeyPressed(key.KeyChar);
                Console.WriteLine("--------------\n");
            }
        }
    }
    class ThreeSubscriber
    {
        public void Subscribe(char key)
        {
            Console.WriteLine($"ThreeSubscriber: {key}");
        }
    }

    class FiveSubscriber
    {
        public void Subscribe(char key)
        {
            Console.WriteLine($"FiveSubscriber: {key}");
        }
    }

    class DigitSubscriber
    {
        public void Subscribe(char key)
        {
            Console.WriteLine($"DigitSubscriber: {key}");
        }
    }

    class LogSubscriber
    {
        string fileName = "C:\\Users\\timot\\Desktop\\log.txt";
        public void Subscribe(char key)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"LogSubscriber: {key}");
            }
            Console.WriteLine($"LogSubscriber: {key}");
        }
    }

    class Program
    {
        static void Main()
        {
            KeyboardManager km = new();
            ThreeSubscriber ts = new();
            FiveSubscriber fs = new();
            DigitSubscriber ds = new();
            LogSubscriber ls = new();

            km.ThreeKeyPressed += ts.Subscribe;
            km.FiveKeyPressed += fs.Subscribe;
            km.DigitKeyPressed += ds.Subscribe;
            km.AnyKeyPressed += ls.Subscribe;

            km.Run();
        }
    }
}
