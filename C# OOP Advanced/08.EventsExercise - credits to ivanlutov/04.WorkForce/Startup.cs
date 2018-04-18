namespace _04.WorkForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _04.WorkForce.Models;

    public class Startup
    {
        public delegate void JobDoneEventHandler(object sender, JobEventArgs e);
        public static void Main()
        {
            JobsList jobs = new JobsList();
            List<Employee> employees = new List<Employee>();

            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Job":
                        Job realJob = new Job(input[1], int.Parse(input[2]), employees.FirstOrDefault(e => e.Name == input[3]));
                        realJob.JobDone += realJob.OnJobDone;
                        jobs.Add(realJob);
                        break;
                    case "StandardEmployee":
                        employees.Add(new StandardEmployee(input[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(input[1]));
                        break;
                    case "Pass":
                        foreach (var job in jobs)
                        {
                            job.Update();
                        }
                        break;
                    case "Status":
                        foreach (var job in jobs)
                        {
                            if (!job.IsDone)
                            {
                                Console.WriteLine(job.ToString());
                            }
                        }
                        break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
