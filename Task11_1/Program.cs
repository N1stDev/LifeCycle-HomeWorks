namespace Task11_1
{
    class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string desc) => description = desc;
        public string description { get; }
    }
    class FirstClass
    {
        [Description("Int property description")]
        public int first { get; set; }

        [Description("Float property description")]
        public float second { get; set; }

        [Description("String property description")]
        public string third { get; set; }

        [Description("String[] property description")]
        public string[] forth { get; set; }

        [Description("Int[] property description")]
        public int[] fifth { get; set; }

        [Description("Float[] property description")]
        public float[] sixth { get; set; }

        [Description("Double property description")]
        public double seventh { get; set; }

        [Description("Double[] property description")]
        public double[] eighth { get; set; }

        [Description("Bool property description")]
        public bool nineth { get; set; }

        [Description("Bool[] property description")]
        public bool[] tenth { get; set; }
    }
    class Program
    {
        static void Main()
        {
            FirstClass fc = new();

            foreach (var prop in fc.GetType().GetProperties())
            {
                DescriptionAttribute MyAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute));
                Console.WriteLine("{0} - {1}", prop.Name, MyAttribute.description);
            }
        }
    }
}
