using System.ComponentModel;

namespace Task11_2
{
    class InvalidValueException : Exception
    {
        public string Name { get; set; }
        public List<int> Limits { get; set; }

        public int Value { get; set; }
        public InvalidValueException(string name, int min, int max, int zero, int val) : base($"Min:{min}," +
            $" Max:{max}, ZeroEnabled: {zero}, Value: {val}, Name: {name}")
        {
            Name = name;
            Limits = new List<int> { min, max, zero};
            Value = val;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class ValidateInt32Attribute : Attribute  // можно ли сделать ограничение только для интов??
    {
        public ValidateInt32Attribute(int min, int max, int zero)
        {
            MinValue = min;
            MaxValue = max;
            ZeroEnabled = zero;
        }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int ZeroEnabled { get; set; }
    }

    static class Int32Validate
    {
        public static void Validate(Object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                ValidateInt32Attribute attr = (ValidateInt32Attribute)Attribute.GetCustomAttribute(prop, 
                    typeof(ValidateInt32Attribute));
                if (attr != null)
                {
                    int value = (int)prop.GetValue(obj);
                    if (value < attr.MinValue || value > attr.MaxValue || (value == 0 && attr.ZeroEnabled == 0))
                    {
                        try
                        {
                            throw new InvalidValueException(prop.Name, attr.MinValue,
                            attr.MaxValue, attr.ZeroEnabled, value);
                        }
                        catch (InvalidValueException ve)
                        {
                            Console.WriteLine(ve + "\n\n");
                        }
                        
                    }
                }
            }

            foreach (var field in obj.GetType().GetFields())
            {
                ValidateInt32Attribute attr = (ValidateInt32Attribute)Attribute.GetCustomAttribute(field,
                    typeof(ValidateInt32Attribute));
                if (attr != null)
                {
                    int value = (int)field.GetValue(obj);
                    if (value < attr.MinValue || value > attr.MaxValue || (value == 0 && attr.ZeroEnabled == 0))
                    {
                        try
                        {
                            throw new InvalidValueException(field.Name, attr.MinValue,
                            attr.MaxValue, attr.ZeroEnabled, value);
                        }
                        catch (InvalidValueException ve)
                        {
                            Console.WriteLine(ve + "\n\n");
                        }
                    }
                }
            }
        }
    }

    class Example1
    {
        public Example1(int a, int b, int c, int d)
        {
            number1 = a;
            number2 = b;
            Number1 = c;
            Number2 = d;
        }
        [ValidateInt32(0, 1000, 1)]
        public int number1;

        [ValidateInt32(0, 1000, 0)]
        public int number2;

        [ValidateInt32(0, 10, 1)]
        public int Number1 { get; set; }

        public int Number2 { get; set; }
    }

    class Example2
    {
        public Example2(int a, int b, int c, int d)
        {
            number1 = a;
            number2 = b;
            Number1 = c;
            Number2 = d;
        }

        [ValidateInt32(-200, 0, 0)]
        public int number1;

        public int number2;

        [ValidateInt32(-100, 24, 0)]
        public int Number1 { get; set; }

        [ValidateInt32(0, 1000, 0)]
        public int Number2 { get; set; }
    }


    
    class Program
    {
        static void Main()
        {
            Example1 ex1 = new(100, 0, 100, 20);
            Example2 ex2 = new(-100, 30, 0, 1);

            Int32Validate.Validate(ex1);
            Int32Validate.Validate(ex2);
        }
    }
}

