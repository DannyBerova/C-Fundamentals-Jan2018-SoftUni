using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public abstract class Animal
    {
        private const string ERROR_MESSAGE = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) ||value < 0)
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();
    }
}
