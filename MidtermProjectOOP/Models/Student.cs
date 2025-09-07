using System;

namespace MidtermProjectOOP.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }  
        public School School { get; set; } 
        public long ContactNumber { get; set; }
        public string Email { get; set; }

        public static int ReadIntFromConsole(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public static long ReadLongFromConsole(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (long.TryParse(input, out long value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public static School ReadSchoolFromConsole()
        {
            while (true)
            {
                Console.WriteLine("Select School:");
                foreach (var s in Enum.GetValues(typeof(School)))
                {
                    Console.WriteLine($"[{(int)s}] {s}");
                }

                Console.Write("Enter choice (1-3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(School), choice))
                    return (School)choice;

                Console.WriteLine("Invalid input. Please choose again.");
            }
        }
    }
}
