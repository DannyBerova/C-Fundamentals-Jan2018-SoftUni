namespace _04.WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private const int WorkHoursPerWeek = 40;
        public StandardEmployee(string name) 
            : base(name, WorkHoursPerWeek)
        {
        }
    }
}