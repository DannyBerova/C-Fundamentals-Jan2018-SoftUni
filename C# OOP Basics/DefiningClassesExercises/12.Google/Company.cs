public class Company
{
    private string companyName;
    private string department;
    private decimal salary;

    public Company(string companyName, string department, decimal salary)
    {
        this.CompanyName = companyName;
        this.Department = department;
        this.Salary = salary;
    }

    public string CompanyName
    {
        get => this.companyName;
        set => this.companyName = value;
    }

    public string Department
    {
        get => this.department;
        set => this.department = value;
    }

    public decimal Salary
    {
        get => this.salary;
        set => this.salary = value;
    }

    public override string ToString()
    {
        return $"{this.CompanyName} {this.Department} {this.Salary:f2}";
    }
}

