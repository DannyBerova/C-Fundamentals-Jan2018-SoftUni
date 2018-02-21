using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        public const int MIN_AGE = 0;
        public const int MAX_AGE = 15;
        public const string NAME_ERROR = "{0} cannot be empty.";
        public const string AGE_ERROR = "{0} should be between {1} and {2}.";


        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(NAME_ERROR, nameof(Name)));
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value > MAX_AGE || value < MIN_AGE)
                {
                    throw new ArgumentException(string.Format(AGE_ERROR, nameof(Age), MIN_AGE, MAX_AGE));
                }
                this.age = value;
            }
        }

        public double GetProductPerDay()
        {
            return this.CalculateProductPerDay();
        }

        public double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
