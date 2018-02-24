using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp3
{
    static void Main(string[] args)
    {
        string[] studentInfo = Console.ReadLine().Split();
        string firstName = studentInfo[0];
        string lastName = studentInfo[1];
        string facultyNumber = studentInfo[2];

        string[] workerInfo = Console.ReadLine().Split();
        string wFirstName = workerInfo[0];
        string wLastName = workerInfo[1];
        decimal weekSalary = decimal.Parse(workerInfo[2]);
        decimal workingHours = decimal.Parse(workerInfo[3]);

        try
        {
            Student student = new Student(firstName, lastName, facultyNumber);

            Worker worker = new Worker(wFirstName, wLastName, weekSalary, workingHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {

            Console.WriteLine(ae.Message);
        }
    }
}