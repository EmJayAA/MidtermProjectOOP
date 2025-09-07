using System;
using MidtermProjectOOP.Models;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- STUDENT RECORD SYSTEM ---");
            Console.WriteLine("[1] Add Student");
            Console.WriteLine("[2] Delete Student");
            Console.WriteLine("[3] Search Student");
            Console.WriteLine("[4] Update Student");
            Console.WriteLine("[5] Display All Students");
            Console.WriteLine("[6] Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice, please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Student newStudent = new Student();
                    newStudent.Id = Student.ReadIntFromConsole("Enter Student ID: ");
                    Console.Write("Enter First Name: ");
                    newStudent.FirstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    newStudent.LastName = Console.ReadLine();
                    Console.Write("Enter Course: ");
                    newStudent.Course = Console.ReadLine();
                    Console.Write("Enter Year Level (e.g., 1st, 2nd): ");
                    newStudent.Year = Console.ReadLine();
                    newStudent.School = Student.ReadSchoolFromConsole();
                    newStudent.ContactNumber = Student.ReadLongFromConsole("Enter Contact #: ");
                    Console.Write("Enter Email: ");
                    newStudent.Email = Console.ReadLine();

                    list.AddStudent(newStudent);
                    PauseAndReturn();
                    break;

                case 2:
                    Console.Clear();
                    int deleteId = Student.ReadIntFromConsole("Enter Student ID to delete: ");
                    list.DeleteStudent(deleteId);
                    PauseAndReturn();
                    break;

                case 3:
                    Console.Clear();
                    list.SearchStudent();
                    PauseAndReturn();
                    break;

                case 4:
                    Console.Clear();
                    int updateId = Student.ReadIntFromConsole("Enter Student ID to update: ");
                    list.UpdateStudent(updateId);
                    PauseAndReturn();
                    break;

                case 5:
                    Console.Clear();
                    list.DisplayRecords();
                    break;

                case 6:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
    static void PauseAndReturn()
    {
        Console.WriteLine("\nPress any key to return to Main Menu...");
        Console.ReadKey();
    }
}
