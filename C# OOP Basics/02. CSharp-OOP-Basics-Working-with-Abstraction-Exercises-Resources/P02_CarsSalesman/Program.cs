using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            var cars = new HashSet<Car>();
            var engines = new HashSet<Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                AddEngine(engines);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                AddCar(cars, engines);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void AddCar(HashSet<Car> cars, HashSet<Engine> engines)
        {
            var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var carModel = carInfo[0];
            var carEngine = carInfo[1];
            var car = new Car(carModel, engines.FirstOrDefault(e => e.Model == carEngine));

            if (carInfo.Length > 2)
            {
                var colorOrWeight = carInfo[2];
                int result;
                var isNumber = int.TryParse(colorOrWeight, out result);

                if (isNumber)
                {
                    car.Weight = result;
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

        private static void AddEngine(HashSet<Engine> engines)
        {
            var engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engineModel = engineInfo[0];
            var enginePower = int.Parse(engineInfo[1]);

            var engine = new Engine(engineModel, enginePower);

            if (engineInfo.Length > 2)
            {
                var displacementOrEfficiency = engineInfo[2];
                int result;
                bool isNumber = int.TryParse(displacementOrEfficiency, out result);

                if (isNumber)
                {
                    engine.Displacement = result;
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
    }

}
