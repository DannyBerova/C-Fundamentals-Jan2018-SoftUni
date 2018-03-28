using System;
using System.Linq;

namespace _10.Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            var firstName = firstLine[0] + " " + firstLine[1];
            var adress = firstLine.LastOrDefault();

            var firstTuple = new Tuple<string, string>(firstName, adress);
            Console.WriteLine(firstTuple);

            var secondLine = Console.ReadLine().Split();
            var secondLineName = secondLine[0];
            var amountOfBeer = int.Parse(secondLine[1]);

            var secondTuple = new Tuple<string, int>(secondLineName, amountOfBeer);
            Console.WriteLine(secondTuple);

            var thirdLine = Console.ReadLine().Split();
            var intValue = int.Parse(thirdLine[0]);
            var doubleValue = double.Parse(thirdLine[1]);

            var thirdTuple = new Tuple<int, double>(intValue, doubleValue);
            Console.WriteLine(thirdTuple);
        }
    }
}
