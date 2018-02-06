using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    public class Hospital
    {
        public static void Main()
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            var inputLine = Console.ReadLine();


            while (inputLine != "Output")
            {
                var inputTokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputTokens.Length == 4)
                {
                    var departmentName = inputTokens[0];
                    if (departmentName.Length > 100)
                    {
                        continue;
                    }
                    var doctorsFirstName = inputTokens[1];
                    var doctorsLastName = inputTokens[2];
                    var docFullName = $"{doctorsFirstName} {doctorsLastName}";
                    var patient = inputTokens[3];

                    if (!departments.ContainsKey(departmentName))
                    {
                        departments[departmentName] = new List<string>();
                    }
                    if (doctorsFirstName.Length <= 20 && doctorsLastName.Length <= 20 && !doctors.ContainsKey(docFullName))
                    {
                        doctors[docFullName] = new List<string>();
                    }

                    if (departments[departmentName].Count < 60)
                    {
                        departments[departmentName].Add(patient);
                    }

                    doctors[docFullName].Add(patient);

                }

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                var tokensToOutput = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokensToOutput.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[inputLine]));
                }
                else
                {
                    if (doctors.ContainsKey(inputLine.Trim()))
                    {
                        var doc = inputLine.Trim();
                        var patients = doctors[doc].OrderBy(x => x);
                        Console.WriteLine(string.Join(Environment.NewLine, patients));
                    }
                    else
                    {
                        string department = tokensToOutput[0];
                        int room = int.Parse(tokensToOutput[1]);

                        if (room <= 20 && departments[department].Count > (room * 3) - 2)
                        {
                            var patientsInRoom = departments[department].Skip(room * 3 - 3).Take(3).OrderBy(x => x);
                            Console.WriteLine(string.Join(Environment.NewLine, patientsInRoom));
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
