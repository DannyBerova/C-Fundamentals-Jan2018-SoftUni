using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int numOfEmployees = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < numOfEmployees; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var employee = new Employee(tokens[0],
                          decimal.Parse(tokens[1]),
                                        tokens[2],
                                        tokens[3]);

            if (tokens.Length > 4)
            {
                var ageOrEmail = tokens[4];
                if (ageOrEmail.Contains("@"))
                {
                    employee.Email = ageOrEmail;
                }
                else
                {
                    employee.Age = int.Parse(ageOrEmail);
                }
            }

            if (tokens.Length > 5)
            {
                employee.Age = int.Parse(tokens[5]);
            }

            employees.Add(employee);
        }

        //inspired by master Kenov - with additions

        var result = employees
                     .GroupBy(e => e.Department)
                     .Select(e => new {
                         Department = e.Key,
                         AvgSalary = e.Average(emp => emp.Salary),
                         Empls = e.OrderByDescending(emp => emp.Salary)
                     })
                     .ToList()
                     .OrderByDescending(e => e.AvgSalary)
                     .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var empl in result.Empls)
        {
            Console.WriteLine($"{empl.Name} {empl.Salary:f2} {empl.Email} {empl.Age}");
        }
    }
}

