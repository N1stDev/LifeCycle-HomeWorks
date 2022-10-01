using System;

namespace Task4_2
{

    class Element
    {
        public string name;
        public int value;
        public Element(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return "Name: " + name + "; Value: " + Convert.ToString(value);
        }
    }

    class ArrElem
    {
        Element[] ArrEl;

        public ArrElem(params Element[] elements)
        {
            ArrEl = elements;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < ArrEl.Length; i++)
            {
                str += ArrEl[i] + "\n";
            }
            return str;
        }

        public Element this[int i]
        {
            get
            {
                return ArrEl[i];
            }

            set
            {
                ArrEl[i] = value;
            }
        }

        public Element this[string name]
        {
            get
            {
                for (int i = 0; i < ArrEl.Length; i++) { 
                    if (ArrEl[i].name == name)
                    {
                        return ArrEl[i];
                    }
                }
                throw new IndexOutOfRangeException();
            }

            set
            {
                bool done = false;
                for (int i = 0; i < ArrEl.Length; i++)
                {
                    if (ArrEl[i].name == name)
                    {
                        ArrEl[i] = value;
                        done = true;
                    }
                }
                if (!done) throw new IndexOutOfRangeException();
            }
        }

    }

    class Program
    {
        static int Main()
        {
            ArrElem ArrEl = new ArrElem(new Element("Element1", 100), new Element("Element2", 1337), 
                new Element("Element3", -99), new Element("Element4", 0));

            Console.WriteLine(ArrEl);
            Console.WriteLine(ArrEl[2]);
            Console.WriteLine(ArrEl["Element4"] + "\n");

            ArrEl["Element4"] = new Element("NewElement4", 88);
            ArrEl[2] = new Element("NewElement3", 67);
            
            Console.WriteLine(ArrEl[2]);
            Console.WriteLine(ArrEl["NewElement3"]);
            Console.WriteLine(ArrEl["NewElement4"]);

            // здесь выведет IndexOutOfRangeException
            //Console.WriteLine(ArrEl["Element4"]);
            //Console.WriteLine(ArrEl[5]);

            return 0;
        }
    }
}