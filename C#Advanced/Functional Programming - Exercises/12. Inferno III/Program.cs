namespace _12.Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var gems = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var commands = GetCommands();

            gems = FilterGems(gems, commands);

            Console.WriteLine(string.Join(" ", gems));

        }

        private static List<int> FilterGems(List<int> gems, HashSet<string> commands)
        {
            var filteredGems = new List<int>();

            for (var i = 0; i < gems.Count; i++)
            {
                var isExcluded = false;

                foreach (var command in commands)
                {
                    var tokens = command
                                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToList();
                    var filterType = tokens[0];
                    var filterParameter = int.Parse(tokens[1]);

                    var filters = new Dictionary<string, Func<int, int>>();

                    filters["Sum Left"] = x => gems[x] + (x == 0 ? 0 : gems[x - 1]);
                    filters["Sum Right"] = x => gems[x] + (x == gems.Count - 1 ? 0 : gems[x + 1]);               
                    filters["SumLeftRight"] = x => filters["Sum Left"](x) + filters["Sum Right"](x) - gems[x];

                    Predicate<int> isMatch = x => x == filterParameter;

                    var sum = 0;

                    if (filters.ContainsKey(filterType))
                    {
                        sum = filters[filterType](i);
                    }
                    
                    if (isMatch(sum))
                    {
                        isExcluded = true;
                        break;
                    }
                }
                if (!isExcluded)
                {
                    filteredGems.Add(gems[i]);
                }
            }
            return filteredGems;
        }

        private static HashSet<string> GetCommands()
        {
            var commands = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Forge")
                {
                    break;
                }

                var tokens = input
                            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                var command = tokens[0];
                var filterType = tokens[1];            
                var filterParameter = int.Parse(tokens[2]);
                
                switch (command)
                {
                    case "Exclude":
                        commands.Add(filterType + ";" + filterParameter);
                        break;
                    case "Reverse":    
                        commands.Remove(filterType + ";" + filterParameter);
                        break;
                }
            }
            return commands;
        }
    }
}
