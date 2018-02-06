using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GreedyTimes
{
    public class GreedyTimes
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

            for (int i = 0; i < inputTokens.Length - 1; i += 2)
            {
                var currentUnitName = inputTokens[i];
                var currentUnitAmount = long.Parse(inputTokens[i + 1]);
                var currentUnit = new Unit(currentUnitName, currentUnitAmount);

                var itemCounter = types.Sum(x => x.Value.TotalAmount);
                bool isNotInCapacity = itemCounter + currentUnitAmount > capacity;
                var searchedType = string.Empty;

                if (inputTokens[i].ToLower() == "gold")
                {
                    searchedType = "Gold";
                    CheckOrAddUnit(searchedType, isNotInCapacity, currentUnitName, currentUnitAmount, currentUnit);
                }

                if (inputTokens[i].ToLower().EndsWith("gem") && inputTokens[i].Length >= 4)
                {

                    if (types["Gold"].TotalAmount >= types["Gem"].TotalAmount + currentUnitAmount)
                    {
                        searchedType = "Gem";
                        CheckOrAddUnit(searchedType, isNotInCapacity, currentUnitName, currentUnitAmount, currentUnit);
                    }
                }

                if (currentUnitName.Length == 3 && inputTokens[i].ToCharArray().All(x => char.IsLetter(x)))
                {
                    if (types["Gem"].TotalAmount >= types["Cash"].TotalAmount + currentUnitAmount)
                    {
                        searchedType = "Cash";
                        CheckOrAddUnit(searchedType, isNotInCapacity, currentUnitName, currentUnitAmount, currentUnit);
                    }
                }
            }

            foreach (var type in types.Where(x => x.Value.Units.Any()).OrderByDescending(x => x.Value.TotalAmount))
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.TotalAmount}");
                foreach (var unit in type.Value.Units.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    Console.WriteLine($"##{unit.Name} - {unit.Amount}");
                }
            }
        }

        public static void CheckOrAddUnit(string searchedType, bool isNotInCapacity, string currentUnitName, long currentUnitAmount, Unit currentUnit)
        {
            if (types[searchedType].Units == null || !types[searchedType].Units.Any(x => x.Name == currentUnitName))
            {
                if (isNotInCapacity) return;

                types[searchedType].Units.Add(currentUnit);
                types[searchedType].TotalAmount += currentUnitAmount;

                return;
            }
            types[searchedType].Units.First(x => x.Name == currentUnitName).Amount += currentUnitAmount;
            types[searchedType].TotalAmount += currentUnitAmount;
        }

        public class Unit
        {           
            public Unit(string name, long amount)
            {
                this.Name = name;
                this.Amount = amount;
            }
            public string Name { get; set; }
            public long Amount { get; set; }
        }

        public class UnitType
        {
            public UnitType(string name)
            {
                this.Name = name;
                this.Units = new List<Unit>();
            }
            public string Name { get; set; }
            public long TotalAmount { get; set; }
            public List<Unit> Units { get; set; }
        }
    }
}
