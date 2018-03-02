using System;

public class StartUp
{
    static void Main()
    {
        var carInfo = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

        var truckInfo = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

        var busInfo = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        var countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            var commandArgs = Console.ReadLine().Split();
            var command = commandArgs[0];
            var typeOfVehicle = commandArgs[1];
            var givenParam = double.Parse(commandArgs[2]);

            Vehicle vehicleToOperate;
            if (typeOfVehicle == "Car")
                vehicleToOperate = car;
            else if (typeOfVehicle == "Truck")
                vehicleToOperate = truck;
            else
                vehicleToOperate = bus;

            try
            {
                switch (command)
                {
                    case "Drive":
                        vehicleToOperate.Drive(givenParam);
                        Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                        break;
                    case "DriveEmpty":
                        ((Bus)vehicleToOperate).DriveEmpty(givenParam);
                        Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                        break;
                    case "Refuel":
                        vehicleToOperate.Refuel(givenParam);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}
