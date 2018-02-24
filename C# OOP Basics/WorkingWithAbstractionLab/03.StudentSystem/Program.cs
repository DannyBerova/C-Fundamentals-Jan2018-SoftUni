using System;

public class Program
{
    public static void Main()
    {
        string command;
        StudentSystem studentSystem = new StudentSystem();

        while ((command = Console.ReadLine()) != "Exit")
        {
            studentSystem.ParseCommand(command, Console.WriteLine);
        }
    }
}
