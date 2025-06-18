
using System;
using System.Linq; // For users.Any()

using EventManagement.DAL; // ✅ Required for EventDbContext
using EventManagement.DAL.Entities;
using EventManagement.DAL.Repositories;


class Program
{
    static void Main(string[] args)
    {
        using var context = new EventDbContext();
        IUserRepository userRepo = new UserRepository(context);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Event Management System =====");
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Delete User by Email");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddUser(userRepo);
                    break;

                case "2":
                    ViewUsers(userRepo);
                    break;

                case "3":
                    DeleteUser(userRepo);
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void AddUser(IUserRepository repo)
    {
        Console.WriteLine("\n--- Add New User ---");

        Console.Write("Email ID: ");
        string email = Console.ReadLine();

        Console.Write("User Name: ");
        string name = Console.ReadLine();

        Console.Write("Role (Admin/Participant): ");
        string role = Console.ReadLine();

        Console.Write("Password (6-20 characters): ");
        string password = Console.ReadLine();

        var user = new UserInfo
        {
            EmailId = email,
            UserName = name,
            Role = role,
            Password = password
        };

        repo.AddUser(user);
        Console.WriteLine("✅ User added successfully!");
    }

    static void ViewUsers(IUserRepository repo)
    {
        Console.WriteLine("\n--- All Users ---");
        var users = repo.GetAllUsers();

        if (users.Any())
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Email: {user.EmailId}, Name: {user.UserName}, Role: {user.Role}");
            }
        }
        else
        {
            Console.WriteLine("No users found.");
        }
    }

    static void DeleteUser(IUserRepository repo)
    {
        Console.Write("\nEnter Email ID to delete: ");
        string email = Console.ReadLine();

        repo.DeleteUser(email);
        Console.WriteLine("✅ User deleted (if existed).");
    }
}

