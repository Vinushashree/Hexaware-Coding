using System;

class Program
{
    static void Main(string[] args)
    {
        // Base employee
        Employee baseEmp = new Employee
        {
            EmpCode = 1001,
            EmpName = "John Doe",
            Email = "john@abc.com",
            DeptName = "HR",
            Location = "Mumbai"
        };

        // Part-Time Employee
        PartTimeEmployee pte = new PartTimeEmployee
        {
            EmpCode = 1002,
            EmpName = "Alice",
            Email = "alice@abc.com",
            DeptName = "Support",
            Location = "Delhi",
            Basic = 8000
        };
        pte.CalculateSalary();
        Console.WriteLine(pte.PrintEmployeeDetails(pte));

        // Full-Time Employee
        FullTimeEmployee fte = new FullTimeEmployee
        {
            EmpCode = 1003,
            EmpName = "Bob",
            Email = "bob@abc.com",
            DeptName = "Development",
            Location = "Chennai",
            Basic = 25000
        };
        fte.CalculateSalary();
        Console.WriteLine(fte.PrintEmployeeDetails(fte));
    }
}
