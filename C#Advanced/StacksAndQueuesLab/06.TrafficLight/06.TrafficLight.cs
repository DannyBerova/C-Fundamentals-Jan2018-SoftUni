using System;
using System.Collections.Generic;

namespace _06.TrafficLight
{
    public class Program
    {
        public static void Main()
        {
            var vehiclesPerGreenLight = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var vehiclesQueue = new Queue<string>();
            var totalPassedVehicles = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    var vehiclesThatCanPass = Math.Min(vehiclesQueue.Count, vehiclesPerGreenLight);

                    for (int cnt = 0; cnt < vehiclesThatCanPass; cnt++)
                    {
                        Console.WriteLine($"{vehiclesQueue.Dequeue()} passed!");
                        totalPassedVehicles++;
                    }

                }
                else
                {
                    vehiclesQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalPassedVehicles} cars passed the crossroads.");
        }
    }
}
