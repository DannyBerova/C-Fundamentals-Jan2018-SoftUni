using System;
using System.Collections.Generic;
using _06.TrafficLights.Contracts;
using _06.TrafficLights.Models;

namespace _06.TrafficLights
{
    public class StartUp
    {
        public static void Main()
        {
            var lightsInit = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trafficLights = new List<ITrafficLight>();

            foreach (var light in lightsInit)
            {
                trafficLights.Add(new TrafficLight(light));
            }

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                trafficLights.ForEach(l => l.ChangeLights());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
