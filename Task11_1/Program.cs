namespace Task11_1
{
    [AttributeUsage(AttributeTargets.Property)]
    class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string desc) => Description = desc;
        public string Description { get; }
    }
    class FirstClass
    {
        [Description("Int property description")]
        public int? First { get; set; }

        [Description("Float property description")]
        public float? Second { get; set; }

        [Description("String property description")]
        public string? Third { get; set; }

        [Description("String[] property description")]
        public string[]? Forth { get; set; }

        [Description("Int[] property description")]
        public int[]? Fifth { get; set; }

        [Description("Float[] property description")]
        public float[]? Sixth { get; set; }

        [Description("Double property description")]
        public double? Seventh { get; set; }

        [Description("Double[] property description")]
        public double[]? Eighth { get; set; }

        [Description("Bool property description")]
        public bool? Nineth { get; set; }

        [Description("Bool[] property description")]
        public bool[]? Tenth { get; set; }
    }
    class Program
    {
        static void Main()
        {
            FirstClass fc = new();

            foreach (var prop in fc.GetType().GetProperties())
            {
                DescriptionAttribute? MyAttribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute));
                if (MyAttribute != null)
                {
                    Console.WriteLine("{0} - {1}", prop.Name, MyAttribute.Description);
                }
            }
        }
    }
}
