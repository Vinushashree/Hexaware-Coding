public class PartTimeEmployee : Employee, IPartTimeEmployee
{
    public double Basic { get; set; }
    public double Da { get; set; }
    public double NetSalary { get; set; }

    public double CalculateSalary()
    {
        Da = Basic * 0.05;
        NetSalary = Basic + Da;
        return NetSalary;
    }

    public string PrintEmployeeDetails(Employee employee)
    {
        return $"PTE: {employee.EmpName}, Email: {employee.Email}, Dept: {employee.DeptName}, Location: {employee.Location}, NetSalary: {NetSalary}";
    }
}
