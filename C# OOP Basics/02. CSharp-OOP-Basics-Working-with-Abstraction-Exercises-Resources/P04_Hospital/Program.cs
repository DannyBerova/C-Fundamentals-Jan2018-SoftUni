using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
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
                    DistributePatientsByDepartmentsAndDoctors(departments, doctors, inputTokens);
                }

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                var tokensToOutput = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokensToOutput.Length == 1)
                {
                    PrintAllPatientsInDepartment(departments, inputLine);
                }
                else
                {
                    if (doctors.ContainsKey(inputLine.Trim()))
                    {
                        PrintAllPatientsHealedByGivenDoctor(doctors, inputLine);
                    }
                    else
                    {
                        PrintAllPatientsInTheGivenDepartmentRoomAlphabetically(departments, tokensToOutput);
                    }
                }

                inputLine = Console.ReadLine();
            }
        }

        private static void DistributePatientsByDepartmentsAndDoctors(Dictionary<string, List<string>> departments, Dictionary<string, List<string>> doctors, string[] inputTokens)
        {
            var departmentName = inputTokens[0];
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

        private static void PrintAllPatientsInTheGivenDepartmentRoomAlphabetically(Dictionary<string, List<string>> departments, string[] tokensToOutput)
        {
            string department = tokensToOutput[0];
            int room = int.Parse(tokensToOutput[1]);

            if (room <= 20 && departments[department].Count > (room * 3) - 2)
            {
                var patientsInRoom = departments[department].Skip(room * 3 - 3).Take(3).OrderBy(x => x);
                Console.WriteLine(string.Join(Environment.NewLine, patientsInRoom));
            }
        }

        private static void PrintAllPatientsHealedByGivenDoctor(Dictionary<string, List<string>> doctors, string inputLine)
        {
            var doc = inputLine.Trim();
            var patients = doctors[doc].OrderBy(x => x);
            Console.WriteLine(string.Join(Environment.NewLine, patients));
        }

        private static void PrintAllPatientsInDepartment(Dictionary<string, List<string>> departments, string inputLine)
        {
            Console.WriteLine(string.Join(Environment.NewLine, departments[inputLine]));
        }
    }
}
