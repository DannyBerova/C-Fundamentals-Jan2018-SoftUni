namespace _11.ThePartyReservationFilterMod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var invitations = Console.ReadLine()
                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .ToList();
            var commands = GetCommands();

            invitations = FilterInvitationsFunc(invitations, commands);
            Console.WriteLine(string.Join(" ", invitations));
        }

        private static List<string> FilterInvitationsPredicate(List<string> invitations, HashSet<string> commands)
        {
            var filteredInvitations = new List<string>();

            for (var i = 0; i < invitations.Count; i++)
            {
                var isExcluded = false;

                foreach (var command in commands)
                {
                    var tokens = command
                                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => s.Trim())
                                .ToList();

                    var filterType = tokens[0];
                    var filterParameter = tokens[1];

                    var filters = new Dictionary<string, Predicate<string>>();

                    filters["Starts with"] = x => x.StartsWith(filterParameter);
                    filters["Ends with"] = x => x.EndsWith(filterParameter);
                    filters["Length"] = x => x.Length == int.Parse(filterParameter);
                    filters["Contains"] = x => x.Contains(filterParameter);

                    if (filters.ContainsKey(filterType) && filters[filterType](invitations[i]))
                    {
                        isExcluded = true;
                        break;
                    }
                }
                if (!isExcluded)
                {
                    filteredInvitations.Add(invitations[i]);
                }
            }
            return filteredInvitations;
        }

        private static List<string> FilterInvitationsFunc(List<string> invitations, HashSet<string> commands)
        {

            var filters = new Dictionary<string, Func<string, string, bool>>();
            filters["Starts with"] = (x, y) => x.StartsWith(y);
            filters["Ends with"] = (x, y) => x.EndsWith(y);
            filters["Length"] = (x, y) => x.Length == int.Parse(y);
            filters["Contains"] = (x, y) => x.Contains(y);

            var filteredInvitations = new List<string>();

            for (var i = 0; i < invitations.Count; i++)
            {
                var isExcluded = false;

                foreach (var command in commands)
                {
                    var tokens = command
                                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => s.Trim())
                                .ToList();

                    var filterType = tokens[0];
                    var filterParameter = tokens[1];

                    if (filters.ContainsKey(filterType) && filters[filterType](invitations[i], filterParameter))
                    {
                        isExcluded = true;
                        break;
                    }
                }
                if (!isExcluded)
                {
                    filteredInvitations.Add(invitations[i]);
                }
            }
            return filteredInvitations;
        }



        private static HashSet<string> GetCommands()
        {
            var commands = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Print")
                {
                    break;
                }

                var tokens = input
                            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Trim())
                            .ToList();

                var command = tokens[0];
                var filterType = tokens[1];
                var filterParameter = tokens[2];

                switch (command)
                {
                    case "Add filter":
                        commands.Add(filterType + ";" + filterParameter);
                        break;
                    case "Remove filter":
                        commands.Remove(filterType + ";" + filterParameter);
                        break;
                }
            }
            return commands;
        }
    }
}

