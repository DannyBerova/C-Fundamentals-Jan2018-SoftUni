using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Animals
{
    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                var animalArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    var name = animalArgs[0];
                    var age = int.Parse(animalArgs[1]);
                    var gender = animalArgs[2];
                    AddValidAnimal(animals, animalType, name, age, gender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PrintAllAnimals(animals);
        }

        private static void PrintAllAnimals(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static void AddValidAnimal(List<Animal> animals, string animalType, string name, int age, string gender)
        {
            Animal currentAnimal;
            switch (animalType)
            {
                case "Cat":
                    currentAnimal = new Cat(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Kitten":
                    currentAnimal = new Kitten(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Tomcat":
                    currentAnimal = new Tomcat(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Dog":
                    currentAnimal = new Dog(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                case "Frog":
                    currentAnimal = new Frog(name, age, gender);
                    animals.Add(currentAnimal);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
