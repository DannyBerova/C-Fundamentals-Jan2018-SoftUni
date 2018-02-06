
namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicAssault
    {
        public static void Main(string[] args)
        {
            var regions = new Dictionary<String, Region>();
            string inputLine = Console.ReadLine();

            while (inputLine != "Count em all")
            {
                string[] inputTokens = inputLine.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var regionName = inputTokens[0];
                var metheorType = inputTokens[1];
                var metheorAmount = long.Parse(inputTokens[2]);

                var currentMetheor = new Metheor(metheorType, metheorAmount);
                var currentRegion = new Region(regionName);

                if (!regions.ContainsKey(regionName))
                {
                    regions[regionName] = currentRegion;
                }
                var regionToCheck = regions[regionName];

                if (metheorType == "Green")
                {
                    regionToCheck.GreenMetheor.Amount += metheorAmount;
                    while (regionToCheck.GreenMetheor.Amount >= 1000000)
                    {
                        regionToCheck.GreenMetheor.Amount -= 1000000;
                        regionToCheck.RedMetheor.Amount += 1;
                        while (regionToCheck.RedMetheor.Amount >= 1000000)
                        {
                            regionToCheck.RedMetheor.Amount -= 1000000;
                            regionToCheck.BlackMetheor.Amount += 1;
                        }
                    }
                }

                if (metheorType == "Red")
                {
                    regionToCheck.RedMetheor.Amount += metheorAmount;
                    
                        
                        while (regionToCheck.RedMetheor.Amount >= 1000000)
                        {
                            regionToCheck.RedMetheor.Amount -= 1000000;
                            regionToCheck.BlackMetheor.Amount += 1;
                        }
                    
                }

                if (metheorType == "Black")
                {
                    regionToCheck.BlackMetheor.Amount += metheorAmount;
                }

                inputLine = Console.ReadLine();
            }

            var sortedRegions = regions.OrderByDescending(x => x.Value.BlackMetheor.Amount)
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var region in sortedRegions)
            {
                
                Console.WriteLine(region.Key);

                foreach (var metheor in region.Value.Metheors.OrderByDescending(x => x.Amount).ThenBy(x => x.Type))
                {
                    Console.WriteLine($"-> {metheor.Type} : {metheor.Amount}");
                }

            }
        }

        public class Metheor
        {
            public Metheor()
            {

            }

            public Metheor(string type, long amount)
            {
                this.Type = type;
                this.Amount = amount;
            }

            public string Type { get; set; }
            public long Amount { get; set; }
        }

        public class Region
        {
            public Region()
            {

            }

            public Region(string name)
            {
                this.Name = name;
                this.BlackMetheor = new Metheor("Black", 0);
                this.GreenMetheor = new Metheor("Green", 0);
                this.RedMetheor = new Metheor("Red", 0);
                this.Metheors = new List<Metheor>() { BlackMetheor, GreenMetheor, RedMetheor };
            }

            public string Name { get; set; }
            public Metheor BlackMetheor { get; set; }
            public Metheor GreenMetheor { get; set; }
            public Metheor RedMetheor { get; set; }
            public List<Metheor> Metheors { get; set; }


        }
    }
}
