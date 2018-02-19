using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int numOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numOfCars; i++)
        {
            var tokens = Console.ReadLine().Split();
            var modelCar = tokens[0];

            if (!cars.Any(c => c.Model == modelCar))
            {
                Car car = new Car(modelCar,
                                 double.Parse(tokens[1]),
                                 double.Parse(tokens[2]));
                cars.Add(car);
            }
        }

        string inputLine;

        while ((inputLine = Console.ReadLine()) != "End")
        {
            var inputParams = inputLine.Split();

            string model = inputParams[1];
            double distance = double.Parse(inputParams[2]);

            Car car = cars.Find(c => c.Model == model);
            bool isMoved = car.Drive(distance);

            if (!isMoved)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.Distance}");
        }
    }
}

