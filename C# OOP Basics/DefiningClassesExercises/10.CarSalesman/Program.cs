using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        var engines = new List<Engine>();

        for (int index = 0; index < numberOfEngines; index++)
        {
            var engineInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var engineModel = engineInfo[0];
            var enginePower = double.Parse(engineInfo[1]);

            var engine = new Engine(engineModel, enginePower);

            if (engineInfo.Length > 2)
            {
                var displacementOrEfficiency = engineInfo[2];
                double result;
                bool isNumber = double.TryParse(displacementOrEfficiency, out result);

                if (isNumber)
                {
                    engine.Displacement = engineInfo[2];
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                }
            }

            if (engineInfo.Length > 3)
            {
                engine.Efficiency = engineInfo[3];
            }
            engines.Add(engine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            var carInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = carInfo[0];
            var carEngine = carInfo[1];
            var car = new Car(carModel, engines.FirstOrDefault(e => e.Model == carEngine));

            if (carInfo.Length > 2)
            {
                var colorOrWeight = carInfo[2];
                double result;
                var isNumber = double.TryParse(colorOrWeight, out result);

                if (isNumber)
                {
                    car.Weight = colorOrWeight;
                }
                else
                {
                    car.Color = carInfo[2];
                }
            }

            if (carInfo.Length > 3)
            {
                car.Color = carInfo[3];
            }

            cars.Add(car);
        }

        cars.ForEach(c => Console.Write(c.ToString()));
    }
}