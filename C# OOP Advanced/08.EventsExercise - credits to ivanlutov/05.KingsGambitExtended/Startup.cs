namespace _05.KingsGambitExtended
{
    using System;
    using System.Linq;
    using _02.KingsGambit.Models;
    using _05.KingsGambitExtended.Models;

    public class Startup
    {
        public static void Main()
        {
            SoldierList soldiers = new SoldierList();
            King king = new King(Console.ReadLine());
            string[] royalGuardsNames = Console.ReadLine().Split();

            foreach (string guardName in royalGuardsNames)
            {
                RoyalGuard currentRoyalGuard = new RoyalGuard(guardName, king);
                soldiers.Add(currentRoyalGuard);
                king.BeingAttacked += currentRoyalGuard.OnKingBeingAttacked;
            }

            string[] footmenNames = Console.ReadLine().Split();

            foreach (string footManName in footmenNames)
            {
                Footman footman = new Footman(footManName, king);
                soldiers.Add(footman);
                king.BeingAttacked += footman.OnKingBeingAttacked;
            }

            soldiers.ForEach(s => s.SoldierKilled += soldiers.OnSoldierKilled);

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Kill":

                        Soldier attackedSoldier = soldiers.FirstOrDefault(s => s.Name.Equals(command[1]));
                        attackedSoldier.TakeAttack();
                        break;

                    case "Attack":

                        king.TakeAttack();
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
