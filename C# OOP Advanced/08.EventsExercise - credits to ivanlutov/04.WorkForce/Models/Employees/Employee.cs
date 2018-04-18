namespace _04.WorkForce.Models
{
    public abstract class Employee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; private set; }
        public int WorkHoursPerWeek { get; private set; }
    }
}