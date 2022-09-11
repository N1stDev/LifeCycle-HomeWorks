namespace Task1_1
{
    class Man
    {
        protected string name;
        protected int age;

        public Man(string inputName, int inputAge)
        {
            name = inputName;
            age = inputAge;
        }

        public void UpdateName(string newName)
        {
            if (newName == "")
            {
                Console.WriteLine("Name can not be an empty value! Name was not updated!");
            }
            else
            {
                name = newName;
            }
        }

        public void UpdateAge(int newAge)
        {
            if (age < 0)
            {
                Console.WriteLine("Age can not be a negative value! Age was not updated!");
            }
            else
            {
                age = newAge;
            }
        }

        public string Str()
        {
            return $"Man, {name}, {age}";
        }
    }

    class Teenager: Man
    {
        string school;

        public Teenager(string inputName, int inputAge, string inputSchool) : base(inputName, inputAge)
        {
            if (age < 13 || age > 19)
            {
                Console.WriteLine("Age is not for teenager! Age set to default=13");
                age = 13;
            }
            school = inputSchool;
        }

        public new void UpdateAge(int newAge)
        {
            if (newAge < 13 || newAge > 19)
            {
                Console.WriteLine("Age is not for teenager! Age was not updated!");
            }
            else
            {
                age = newAge;
            }
        }

        public new string Str()
        {
            return $"Teenager, {name}, {age}, School: {school}";
        }
    }

    class Worker: Man
    {
        string jobPlace;

        public Worker(string inputName, int inputAge, string inputJobPlace): base(inputName, inputAge)
        {
            if (age < 16 || age > 70)
            {
                Console.WriteLine("Age is not for worker! Age set to default=16");
                age = 16;
            }
            jobPlace = inputJobPlace;
        }

        public new void UpdateAge(int newAge)
        {
            if (newAge < 16 || newAge > 70)
            {
                Console.WriteLine("Age is not for worker! Age was not updated!");
            }
            else
            {
                age = newAge;
            }
        }

        public new string Str()
        {
            return $"Worker, {name}, {age}, Job place: {jobPlace}";
        }
    }

    class Program
    {
        static void Main()
        {
            Man man = new Man("Alex", 25);
            Teenager teen1 = new Teenager("Boris", 33, "1st school");
            Teenager teen2 = new Teenager("Oleg", 18, "2nd school");
            Worker worker1 = new Worker("Helen", 100, "REA");
            Worker worker2 = new Worker("Viktor", 50, "Yandex");

            man.UpdateName("Tim");
            man.UpdateAge(20);

            teen2.UpdateAge(40);

            worker1.UpdateAge(42);

            Console.WriteLine("Created people:");
            Console.WriteLine(man.Str());
            Console.WriteLine(teen1.Str());
            Console.WriteLine(teen2.Str());
            Console.WriteLine(worker1.Str());
            Console.WriteLine(worker2.Str());

        }
    }
}
