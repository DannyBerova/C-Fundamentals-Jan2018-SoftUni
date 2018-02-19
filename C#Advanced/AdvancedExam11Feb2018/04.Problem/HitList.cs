using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Problem
{
    public class ProblemFour
    {
        public static void Main()
        {
            var personData = new Dictionary<string, SortedDictionary<string, string>>();
            var targetInfoIndex = int.Parse(Console.ReadLine());

            var inputLine = Console.ReadLine();

            while (inputLine != "end transmissions")
            {
                var personInfo = inputLine.Split('=');
                var personName = personInfo[0];

                if (!personData.ContainsKey(personName))
                {
                    personData[personName] = new SortedDictionary<string, string>();
                }

                var currentPersonInfoPairs = personInfo[1].Split(';');
                for (int i = 0; i < currentPersonInfoPairs.Length; i++)
                {
                    var keyValuePair = currentPersonInfoPairs[i].Split(':');
                    var currentKey = keyValuePair[0];
                    var currentValue = keyValuePair[1];

                    //if (personData[personName].ContainsKey(currentKey))
                    //{
                    personData[personName][currentKey] = currentValue;
                    //}

                }

                inputLine = Console.ReadLine();
            }

            var targetPerson = Console.ReadLine();
            var personToKill = targetPerson.Substring(5);

            var hitted = personData[personToKill];
            Console.WriteLine($"Info on {personToKill}:");

            foreach (var item in hitted)
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
            }

            var infoIndexKeys = hitted.Sum(x => x.Key.Length);
            var infoIndexValues = hitted.Sum(x => x.Value.Length);
            var infoIndex = infoIndexKeys + infoIndexValues;

            if (targetInfoIndex <= infoIndex)
            {
                Console.WriteLine($"Info index: {infoIndex}");
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Info index: {infoIndex}");
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
