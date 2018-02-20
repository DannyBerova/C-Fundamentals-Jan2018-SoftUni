using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        public static Dictionary<string, UnitType> types;

        public static void Main()
        {
            types = new Dictionary<string, UnitType>();
            types.Add("Gold", new UnitType("Gold"));
            types.Add("Gem", new UnitType("Gem"));
            types.Add("Cash", new UnitType("Cash"));

            var capacity = long.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine();
            var inputTokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int quantityPairs = 0; quantityPairs < inputTokens.Length - 1; quantityPairs += 2)
            {
                DistributeItemsByType(capacity, inputTokens, quantityPairs);
            }

            PrintAllItemsByTheGivenCriteria();
        }

        private static void PrintAllItemsByTheGivenCriteria()
        {
            foreach (var type in types.Where(x => x.Value.Units.Any()).OrderByDescending(x => x.Value.TotalAmount))
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.TotalAmount}");
                foreach (var unit in type.Value.Units.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    Console.WriteLine(unit);
                }
            }
        }

        private static void DistributeItemsByType(long capacity, string[] inputTokens, int quantityPairs)
        {
            var currentUnitName = inputTokens[quantityPairs].ToLower();
            var currentUnitNameOriginal = inputTokens[quantityPairs];
            var currentUnitAmount = long.Parse(inputTokens[quantityPairs + 1]);
            var currentUnit = new Unit(currentUnitNameOriginal, currentUnitAmount);

            var itemCounter = types.Sum(x => x.Value.TotalAmount);
            bool isNotInCapacity = itemCounter + currentUnitAmount > capacity;
            var searchedType = string.Empty;

            if (inputTokens[quantityPairs].ToLower() == "gold")
            {
                searchedType = "Gold";
                CheckOrAddUnit(searchedType, isNotInCapacity, currentUnitName, currentUnitAmount, currentUnit);
            }

            if (inputTokens[quantityPairs].ToLower().EndsWith("gem") && inputTokens[quantityPairs].Length >= 4)
            {

                if (types["Gold"].TotalAmount >= types["Gem"].TotalAmount + currentUnitAmount)
                {
                    searchedType = "Gem";
                    CheckOrAddUnit(searchedType, isNotInCapacity, currentUnitName, currentUnitAmount, currentUnit);
                }
            }

            if (currentUnitName.Length == 3 && inputTokens[quantityPairs].ToCharArray().All(x => char.IsLetter(x)))
            {
                if (types["Gem"].TotalAmount >= types["Cash"].TotalAmount + currentUnitAmount)
                {
                    searchedType = "Cash";
                    CheckOrAddUnit(searchedType, isNotInCapacity, currentUnitName, currentUnitAmount, currentUnit);
                }
            }
        }

        public static void CheckOrAddUnit(string searchedType, bool isNotInCapacity, string currentUnitName, long currentUnitAmount, Unit currentUnit)
        {
            if (types[searchedType].Units == null || !types[searchedType].Units.Any(x => x.Name.ToLower() == currentUnitName))
            {
                if (isNotInCapacity) return;

                types[searchedType].Units.Add(currentUnit);
                types[searchedType].TotalAmount += currentUnitAmount;

                return;
            }
            types[searchedType].Units.First(x => x.Name.ToLower() == currentUnitName).Amount += currentUnitAmount;
            types[searchedType].TotalAmount += currentUnitAmount;
        }
    }
}