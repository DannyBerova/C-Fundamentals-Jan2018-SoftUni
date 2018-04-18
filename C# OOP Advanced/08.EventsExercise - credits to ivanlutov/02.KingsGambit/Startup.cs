namespace _02.KingsGambit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.KingsGambit.Models;

    public class Startup
    {
        public static void Main()
        {
            var king = new King(Console.ReadLine());
            var soldiers = new List<Soldier>();

            var royalGuards = Console.ReadLine().Split();
            foreach (var royalGuard in royalGuards)
            {
                var guard = new RoyalGuard(royalGuard);
                king.UnderAttack += guard.KingUnderAttack;
                soldiers.Add(guard);
            }

            var footmans = Console.ReadLine().Split();
            foreach (var footman in footmans)
            {
                var currentFootman = new Footman(footman);
                king.UnderAttack += currentFootman.KingUnderAttack;
                soldiers.Add(currentFootman);
            }

            var command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Kill":
                        Soldier soldier = soldiers.FirstOrDefault(s => s.Name == command[1]);
                        king.UnderAttack -= soldier.KingUnderAttack;
                        soldiers.Remove(soldier);
                        break;
                    case "Attack":
                        king.OnUnderAttack();
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
