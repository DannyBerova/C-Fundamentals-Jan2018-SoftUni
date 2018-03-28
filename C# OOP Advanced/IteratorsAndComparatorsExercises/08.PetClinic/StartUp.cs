using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var clinics = new List<Clinic>();
        var pets = new List<Pet>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                var commandArgs = Console.ReadLine().Split();
                ExecuteCommand(clinics, pets, commandArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void ExecuteCommand(List<Clinic> clinics, List<Pet> pets, string[] commandArgs)
    {
        var command = commandArgs[0];

        switch (command)
        {
            case "Create":
                ExecuteCreateCommand(clinics, pets, commandArgs);
                break;
            case "Add":
                ExecuteAddCommand(clinics, pets, commandArgs);
                break;
            case "Release":
                ExecuteReleaseCommand(clinics, commandArgs);
                break;
            case "HasEmptyRooms":
                ExecuteHasEmptyRoomsCommand(clinics, commandArgs);
                break;
            case "Print":
                ExecutePrintCommand(clinics, commandArgs);
                break;
        }
    }

    private static void ExecutePrintCommand(List<Clinic> clinics, string[] commandArgs)
    {
        var clinicToBePrinted = clinics.FirstOrDefault(p => p.Name == commandArgs[1]);

        if (commandArgs.Length == 2)
        {
            Console.WriteLine(clinicToBePrinted.Print());
        }
        else
        {
            var roomToPrint = int.Parse(commandArgs[2]);
            Console.WriteLine(clinicToBePrinted.Print(roomToPrint));
        }
    }

    private static void ExecuteHasEmptyRoomsCommand(List<Clinic> clinics, string[] commandArgs)
    {
        var clinicToBeChecked = clinics.FirstOrDefault(p => p.Name == commandArgs[1]);
        Console.WriteLine(clinicToBeChecked.HasEmptyRooms());
    }

    private static void ExecuteReleaseCommand(List<Clinic> clinics, string[] commandArgs)
    {
        var clinicToReleasePet = clinics.FirstOrDefault(p => p.Name == commandArgs[1]);
        Console.WriteLine(clinicToReleasePet.Release());
    }

    private static void ExecuteAddCommand(List<Clinic> clinics, List<Pet> pets, string[] commandArgs)
    {
        var petToAdd = pets.FirstOrDefault(p => p.Name == commandArgs[1]);
        var clinicToBeAdded = clinics.FirstOrDefault(p => p.Name == commandArgs[2]);
        Console.WriteLine(clinicToBeAdded.Add(petToAdd));
    }

    private static void ExecuteCreateCommand(List<Clinic> clinics, List<Pet> pets, string[] commandArgs)
    {
        if (commandArgs[1] == "Pet")
        {
            var pet = new Pet(commandArgs[2], int.Parse(commandArgs[3]), commandArgs[4]);
            pets.Add(pet);
        }
        else
        {
            var clinic = new Clinic(commandArgs[2], int.Parse(commandArgs[3]));
            clinics.Add(clinic);
        }
    }
}

