namespace _10.Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var guests = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

            guests = GetCommands(guests);
            PrintGuests(guests);
        }

        private static List<string> GetCommands(List<string> guests)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                var commands = input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var command = commands[0];
                var condition = commands[1];
                var pattern = commands[2];

                var filteredGuests = FilterGuests(guests, condition, pattern);

                guests = UpdateGuests(guests, filteredGuests, command);
            }
            return guests;
        }



        private static void PrintGuests(List<string> guests)

        {

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            else
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
        }

        private static List<string> UpdateGuests(List<string> guests, List<string> filteredGuests, string command)
        {
            if (guests.Count == 0 || filteredGuests.Count == 0)
            {
                return guests;
            }

            switch (command)
            {
                case "Remove":
                    guests = guests
                            .Where(g => !filteredGuests.Contains(g))
                            .ToList();

                    break;

                case "Double":
                    for (int i = 0; i < guests.Count; i++)
                    {
                        for (int j = 0; j < filteredGuests.Count; j++)
                        {
                            if (filteredGuests[j] == guests[i])
                            {
                                guests.Insert(++i, filteredGuests[j]);
                                filteredGuests.RemoveAt(j);
                                break;
                            }
                        }
                    }
                    break;
            }
            return guests;
        }

        private static List<string> FilterGuestsDict(List<string> guests, string condition, string pattern)
        {
            var filters = new Dictionary<string, Predicate<string>>();
            filters["StartsWith"] = s => s.StartsWith(pattern);
            filters["EndsWith"] = s => s.EndsWith(pattern);
            filters["Length"] = s => s.Length == int.Parse(pattern);

            var filteredGuests = guests
                                .Where(g => filters[condition](g))
                                .ToList();

            return filteredGuests;
        }

        private static List<string> FilterGuests(List<string> guests, string condition, string pattern)
        {
            Predicate<string> startsWith = s => s.StartsWith(pattern);
            Predicate<string> endsWith = s => s.EndsWith(pattern);
            Predicate<string> hasLength = s => s.Length == int.Parse(pattern);

            var filteredGuests = new List<string>();

            switch (condition)
            {
                case "StartsWith":
                    filteredGuests = guests
                                    .Where(g => startsWith(g))
                                    .ToList();
                    break;
                case "EndsWith":
                    filteredGuests = guests
                                    .Where(g => endsWith(g))
                                    .ToList();
                    break;
                case "Length":
                    filteredGuests = guests
                                    .Where(g => hasLength(g))
                                    .ToList();

                    break;
            }
            return filteredGuests;
        }
    }
}

