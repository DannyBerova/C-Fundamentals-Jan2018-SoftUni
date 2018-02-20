using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainPersonInput = Console.ReadLine();
            FamilyTreeBuilder familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ParseInput(familyTreeBuilder, command);
            }

            PrintMainPersonTree(familyTreeBuilder.MainPerson);
        }

        private static void PrintMainPersonTree(Person mainPerson)
        {
            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Children:");
            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }
        }

        private static void ParseInput(FamilyTreeBuilder familyTreeBuilder, string input)
        {
            string[] tokens = input.Split(" - ");
            if (tokens.Length > 1)
            {

                string parentInput = tokens[0];
                string childInput = tokens[1];
                familyTreeBuilder.SetParentChildRelation(parentInput, childInput);
            }
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];
                familyTreeBuilder.SetFullInfo(name, birthday);
            }
        }
    }
}
