using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    public class Program
    {
        public static void Main()
        {
            var pumpsCount = int.Parse(Console.ReadLine());
            var pumps = new Queue<Pumps>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var pumpInfo = Console.ReadLine()
                            .Trim()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(long.Parse)
                            .ToArray();

                var pump = new Pumps()
                {
                    IndexOfPump = i,
                    DistanceToNextFuelPump = pumpInfo[1],
                    AmountOfPetrol = pumpInfo[0]
                };

                pumps.Enqueue(pump);
            }

            for (int pumpIndex = 0; pumpIndex < pumpsCount; pumpIndex++)
            {
                long petrol = 0;
                long distance = 0;
                bool IsTourCompleted = true;

                foreach (var p in pumps)
                {
                    petrol += p.AmountOfPetrol;
                    distance += p.DistanceToNextFuelPump;
                    if (petrol < distance)
                    {
                        IsTourCompleted = false;
                        break;
                    }
                }

                if (IsTourCompleted)
                {
                    Console.WriteLine(pumpIndex);
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }
        }

        public class Pumps
        {
            public long DistanceToNextFuelPump;
            public long AmountOfPetrol;
            public int IndexOfPump;
        }
    }
}