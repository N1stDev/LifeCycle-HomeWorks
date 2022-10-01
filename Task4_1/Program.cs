namespace Task4_1
{
    class Man
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Man(string inputName, int inputAge)
        {
            name = inputName;
            age = inputAge;
        }

        public void UpdateName(string newName)
        {
            if (newName == "")
            {
                throw new Exception("Empty name!");
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
                throw new Exception("Incorrect age!");
            }
            else
            {
                age = newAge;
            }
        }

        public override string ToString()
        {
            return $"Man, {name}, {age}";
        }
    }

    class Teenager : Man
    {
        private string school;

        public string School
        {
            get { return school; }
            set { school = value; }
        }

        public Teenager(string inputName, int inputAge, string inputSchool) : base(inputName, inputAge)
        {
            if (Age < 13 || Age > 19)
            {
                throw new Exception("Incorrect age!");
            }
            school = inputSchool;
        }

        public new void UpdateAge(int newAge)
        {
            if (newAge < 13 || newAge > 19)
            {
                throw new Exception("Incorrect age!");
            }
            else
            {
                Age = newAge;
            }
        }

        public override string ToString()
        {
            return $"Teenager, {Name}, {Age}, School: {school}";
        }
    }

    class Worker : Man
    {
        private string jobPlace;

        public string JobPlace
        {
            get { return jobPlace; }
            set { jobPlace = value; }
        }

        public Worker(string inputName, int inputAge, string inputJobPlace) : base(inputName, inputAge)
        {
            if (Age < 16 || Age > 70)
            {
                throw new Exception("Incorrect age!");
            }
            jobPlace = inputJobPlace;
        }

        public new void UpdateAge(int newAge)
        {
            if (newAge < 16 || newAge > 70)
            {
                throw new Exception("Incorrect age!");
            }
            else
            {
                Age = newAge;
            }
        }

        public override string ToString()
        {
            return $"Worker, {Name}, {Age}, Job place: {jobPlace}";
        }
    }

    class Program
    {
        static void Main()
        {
            Man man = new Man("Alex", 25);
            //Teenager teen1 = new Teenager("Boris", 33, "1st school"); age error
            Teenager teen1 = new Teenager("Boris", 14, "1st school");
            Teenager teen2 = new Teenager("Oleg", 18, "2nd school");
            //Worker worker1 = new Worker("Helen", 100, "REA"); age error
            Worker worker1 = new Worker("Helen", 41, "REA");
            Worker worker2 = new Worker("Viktor", 50, "Yandex");

            man.UpdateName("Tim");
            man.UpdateAge(20);

            //teen2.UpdateAge(40); age error
            teen2.UpdateAge(17);

            worker1.UpdateAge(42);

            Console.WriteLine("Created people:");
            Console.WriteLine(man);
            Console.WriteLine(teen1);
            Console.WriteLine(teen2);
            Console.WriteLine(worker1);
            Console.WriteLine(worker2);

        }
    }
}
