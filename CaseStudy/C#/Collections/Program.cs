using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementApp
{
    // Student class with ID and Name
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            // Adding students
            studentList.Add(new Student(1, "Alice"));
            studentList.Add(new Student(2, "Bob"));
            studentList.Add(new Student(3, "Charlie"));

            Console.WriteLine("All Students:");
            foreach (var student in studentList)
            {
                student.Display();
            }

            // Search for a student
            Console.Write("\nEnter name to search: ");
            string searchName = Console.ReadLine();

            var foundStudent = studentList
                .FirstOrDefault(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"Found: ID={foundStudent.ID}, Name={foundStudent.Name}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            // Remove a student
            Console.Write("\nEnter name to remove: ");
            string removeName = Console.ReadLine();

            var studentToRemove = studentList
                .FirstOrDefault(s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));

            if (studentToRemove != null)
            {
                studentList.Remove(studentToRemove);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            // Display updated list
            Console.WriteLine("\nUpdated List of Students:");
            foreach (var student in studentList)
            {
                student.Display();
            }

            // Display total count
            Console.WriteLine($"\nTotal number of students: {studentList.Count}");
        }
    }
}
