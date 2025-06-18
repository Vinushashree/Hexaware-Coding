public class FullTimeEmployee : Employee, IFullTimeEmployee
{
    public double Basic { get; set; }
    public double Hra { get; set; }
    public double Da { get; set; }
    public double NetSalary { get; set; }

    public double CalculateSalary()
    {
        Hra = Basic * 0.15;
        Da = Basic * 0.10;
        NetSalary = Basic + Hra + Da;
        return NetSalary;
    }

    public string PrintEmployeeDetails(Employee employee)
    {
        return $"FTE: {employee.EmpName}, Email: {employee.Email}, Dept: {employee.DeptName}, Location: {employee.Location}, NetSalary: {NetSalary}";
    }
}
