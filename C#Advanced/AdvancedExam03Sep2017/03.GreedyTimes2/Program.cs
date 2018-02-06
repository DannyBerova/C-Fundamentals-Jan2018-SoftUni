using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GreedyTimes
{
    public class GreedyTimes
    {
        public static void Main()
        {
            var types = new Dictionary<string, UnitType>();
            types.Add("Gold", new UnitType("Gold"));
            types.Add("Gem", new UnitType("Gem"));
            types.Add("Cash", new UnitType("Cash"));



            var capacity = long.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine();
            var inputTokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < inputTokens.Length - 1; i += 2)
            {
                var itemCounter = types.Sum(x => x.Value.TotalAmount);


                var tokenToChars = inputTokens[i].ToCharArray();
                var currentUnitName = inputTokens[i];
                var currentUnitAmount = long.Parse(inputTokens[i + 1]);
                var currentUnit = new Unit(currentUnitName, currentUnitAmount);

                //if (itemCounter + currentUnitAmount > capacity)
                //{
                //    break;
                //}

                if (currentUnitName.ToLower() == "gold" 
                    && types["Gold"].Units == null || !types["Gold"].Units.Any(x => x.Name == currentUnitName))
                {
                    if (types["Gold"].Units == null || !types["Gold"].Units.Any(x => x.Name == currentUnitName))
                    {
                        types["Gold"].Units.Add(currentUnit);
                        types["Gold"].TotalAmount += currentUnitAmount;

                        continue;
                    }
                    types["Gold"].Units.First(x => x.Name == currentUnitName).Amount += currentUnitAmount;
                    types["Gold"].TotalAmount += currentUnitAmount;

                }
                if (currentUnitName.ToLower().EndsWith("gem") && currentUnitName.Length >= 4)
                {

                    if (types["Gold"].TotalAmount >= types["Gem"].TotalAmount + currentUnitAmount)
                    {
                        if (types["Gem"].Units == null || !types["Gem"].Units.Any(x => x.Name == currentUnitName))
                        {
                            types["Gem"].Units.Add(currentUnit);
                            types["Gem"].TotalAmount += currentUnitAmount;
                            continue;
                        }
                        types["Gem"].Units.First(x => x.Name == currentUnitName).Amount += currentUnitAmount;
                        types["Gem"].TotalAmount += currentUnitAmount;
                    }
                }
                if (currentUnitName.Length == 3 && tokenToChars.All(x => char.IsLetter(x)))
                {
                    if (types["Gem"].TotalAmount >= types["Cash"].TotalAmount + currentUnitAmount)
                    {
                        if (types["Cash"].Units == null || !types["Cash"].Units.Any(x => x.Name == currentUnitName))
                        {
                            types["Cash"].Units.Add(currentUnit);
                            types["Cash"].TotalAmount += currentUnitAmount;
                            continue;
                        }
                        types["Cash"].Units.First(x => x.Name == currentUnitName).Amount += currentUnitAmount;
                        types["Cash"].TotalAmount += currentUnitAmount;
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

        public class Unit
        {
            public Unit()
            {

            }
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