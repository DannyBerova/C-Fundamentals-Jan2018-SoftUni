using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CustomListSorter
{
    class CommandInterpreter
    {
        private CustomList<string> list = new CustomList<string>();

        public void ParseCommand(string input)
        {
            var tokens = input.Split(' ');
            var command = tokens[0];

            switch (command)
            {
                case "Add":
                    var element = tokens[1];
                    list.Add(element);
                    break;
                case "Remove":
                    var index = int.Parse(tokens[1]);
                    list.Remove(index);
                    break;
                case "Contains":
                    element = tokens[1];
                    Console.WriteLine(list.Contains(element));
                    break;
                case "Swap":
                    var firstIndex = int.Parse(tokens[1]);
                    var secondIndex = int.Parse(tokens[2]);
                    list.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    element = tokens[1];
                    Console.WriteLine(list.CountGreaterThan(element));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    var printList = list.GetList();
                    Console.WriteLine(String.Join(Environment.NewLine, printList));
                    break;
                case "Sort":
                    list = Sorter<string>.Sort(list);
                    break;
            }
        }
    }
}
