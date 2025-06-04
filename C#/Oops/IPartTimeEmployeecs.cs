public interface IPartTimeEmployee : IEmployee<Employee>
{
    double Basic { get; set; }
    double Da { get; set; }
    double NetSalary { get; set; }

    double CalculateSalary();
}
