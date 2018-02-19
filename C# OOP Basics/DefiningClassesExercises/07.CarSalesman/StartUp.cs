using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int engineCounter = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        for (int i = 0; i < engineCounter; i++)
        {
            AddEngines(engines);
        }

        int carCounter = int.Parse(Console.ReadLine());

        for (int i = 0; i < carCounter; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            Engine engineModel = null;
            foreach (Engine engine in engines)
            {
                if (engine.Model == input[1])
                {
                    engineModel = engine;
                }
            }
            Car currentCar = new Car(model, engineModel);
            switch (input.Length)
            {
                case 3:
                    int digit = 0;
                    bool isDigit = int.TryParse(input[2], out digit);
                    if (isDigit)
                    {
                        currentCar.Weight = input[2];
                    }
                    else
                    {
                        currentCar.Color = input[2];
                    }
                    break;
                case 4:
                    currentCar.Weight = input[2];
                    currentCar.Color = input[3];
                    break;
            }
            cars.Add(currentCar);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }

    //private static void AddCars(List<Engine> engines, List<Car> cars)
    //{
    //    string[] input = Console.ReadLine().Split();
    //    string model = input[0];
    //    Engine engineModel = null;
    //    foreach (Engine engine in engines)
    //    {
    //        if (engine.Model == input[1])
    //        {
    //            engineModel = engine;
    //        }
    //    }
    //    Car currentCar = new Car(model, engineModel);
    //    switch (input.Length)
    //    {
    //        case 3:
    //            int digit = 0;
    //            bool isDigit = int.TryParse(input[2], out digit);
    //            if (isDigit)
    //            {
    //                currentCar.Weight = input[2];
    //            }
    //            else
    //            {
    //                currentCar.Color = input[2];
    //            }
    //            break;
    //        case 4:
    //            currentCar.Weight = input[2];
    //            currentCar.Color = input[3];
    //            break;
    //    }
    //    cars.Add(currentCar);
    //}

    private static void AddEngines(List<Engine> engines)
    {
        string[] input = Console.ReadLine().Split();
        string engineModel = input[0];
        int power = int.Parse(input[1]);
        Engine currentEngine = new Engine(engineModel, power);
        switch (input.Length)
        {
            case 3:
                int digit = 0;
                bool isDigit = int.TryParse(input[2], out digit);
                if (isDigit)
                {
                    currentEngine.Displacement = input[2];
                }
                else
                {
                    currentEngine.Efficiency = input[2];
                }
                break;
            case 4:
                currentEngine.Displacement = input[2];
                currentEngine.Efficiency = input[3];
                break;
        }
        engines.Add(currentEngine);
    }
}