public interface IFullTimeEmployee : IEmployee<Employee>
{
    double Basic { get; set; }
    double Hra { get; set; }
    double Da { get; set; }
    double NetSalary { get; set; }

    double CalculateSalary();
}
