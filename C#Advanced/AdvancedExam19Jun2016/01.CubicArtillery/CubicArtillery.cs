namespace _01.CubicArtillery
{
    using System;
    using System.Collections.Generic;

    public class CubicArtillery
    {
        public static void Main()
        {
            var bunkers = new Queue<string>();
            var weapons = new Queue<long>();

            var maxCapacity = long.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine();
            var bunkerCapacity = maxCapacity;

            while (inputLine != "Bunker Revision")
            {
                var inputTokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputTokens.Length; i++)
                {
                    if (inputTokens[i].Length == 1 && char.IsLetter(inputTokens[i][0]))
                    {
                        var bunkerToAdd = inputTokens[i];
                        bunkers.Enqueue(bunkerToAdd);
                        //continue;
                    }
                    else
                    {
                        var currentWeapon = long.Parse(inputTokens[i]);
                        var isWeaponContained = false;

                        while (bunkers.Count > 1)
                        {

                            
                                if (bunkerCapacity >= currentWeapon)
                                {
                                    weapons.Enqueue(currentWeapon);
                                    bunkerCapacity -= currentWeapon;
                                    isWeaponContained = true;
                                    break;

                                }
                                if (weapons.Count == 0)
                                {
                                    Console.WriteLine($"{bunkers.Peek()} -> Empty"); ;
                                }
                                else
                                {
                                    Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                                }

                                bunkers.Dequeue();
                                weapons.Clear();
                                bunkerCapacity = maxCapacity;
                                                        
                        }
                        if (!isWeaponContained && bunkers.Count == 1)
                        {
                            if (maxCapacity >= currentWeapon)
                            {
                                if (bunkerCapacity < currentWeapon)
                                {
                                    while (bunkerCapacity < currentWeapon)
                                    {
                                        var removed = weapons.Dequeue();
                                        bunkerCapacity += removed;

                                    }
                                }
                                weapons.Enqueue(currentWeapon);
                                bunkerCapacity -= currentWeapon;
                            }
                        }
                    }
                }
                inputLine = Console.ReadLine();
            }
        }
    }
}
