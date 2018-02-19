using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < num; i++)
            {
                var tokens = Console.ReadLine().Split();

                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                people.Add(person);
            }

            var sorted = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var pers in sorted)
            {
                Console.WriteLine($"{pers.Name} - {pers.Age}");
            }
        }
    }
