using System;
using System.Linq;

namespace _11.Threeuple
{
    class StartUp
    {
        static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            var firstName = firstLine[0] + " " + firstLine[1];
            var adress = firstLine[2];
            var town = firstLine[3];

            var firstTuple = new Threeuple<string, string, string>(firstName, adress, town);
            Console.WriteLine(firstTuple);

            var secondLine = Console.ReadLine().Split();
            var secondLineName = secondLine[0];
            var amountOfBeer = int.Parse(secondLine[1]);
            bool drunk = secondLine[2] == "drunk";

            var secondTuple = new Threeuple<string, int, bool>(secondLineName, amountOfBeer, drunk);
            Console.WriteLine(secondTuple);

            var thirdLine = Console.ReadLine().Split();
            var thirdLineName = thirdLine[0];
            var balance = double.Parse(thirdLine[1]);
            var bankName = thirdLine[2];

            var thirdTuple = new Threeuple<string, double, string>(thirdLineName, balance, bankName);
            Console.WriteLine(thirdTuple);
        }
    }
}
