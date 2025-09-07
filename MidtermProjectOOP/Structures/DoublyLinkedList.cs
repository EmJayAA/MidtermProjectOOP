using System;

namespace MidtermProjectOOP.Models
{
    public class DoublyLinkedList
    {
        private Node head;

        public void AddStudent(Student student)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data.Id == student.Id)
                {
                    Console.WriteLine("DUPLICATE RECORD - ID already exists");
                    return;
                }
                temp = temp.Next;
            }

            Node newNode = new Node(student);

            int choice;
            do
            {
                Console.WriteLine("Where do you want to insert the record?");
                Console.WriteLine("[1] Beginning");
                Console.WriteLine("[2] End");
                Console.WriteLine("[3] Specific position");
                Console.Write("Enter choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3));

            if (choice == 1)
            {
                newNode.Next = head;
                if (head != null)
                    head.Prev = newNode;
                head = newNode;
            }
            else if (choice == 2)
            {
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    temp = head;
                    while (temp.Next != null)
                        temp = temp.Next;

                    temp.Next = newNode;
                    newNode.Prev = temp;
                }
            }
            else if (choice == 3)
            {
                Console.Write("Enter position: ");
                int position = int.Parse(Console.ReadLine());
                temp = head;
                int count = 1;

                while (temp != null && count < position - 1)
                {
                    temp = temp.Next;
                    count++;
                }

                if (temp == null)
                {
                    Console.WriteLine("Position out of range. Adding at END instead.");
                    temp = head;
                    while (temp.Next != null)
                        temp = temp.Next;

                    temp.Next = newNode;
                    newNode.Prev = temp;
                }
                else
                {
                    newNode.Next = temp.Next;
                    if (temp.Next != null)
                        temp.Next.Prev = newNode;
                    temp.Next = newNode;
                    newNode.Prev = temp;
                }
            }
        }

        public void DeleteStudent(int id)
        {
            if (head == null)
            {
                Console.WriteLine("EMPTY");
                return;
            }

            if (head.Data.Id == id)
            {
                head = head.Next;
                if (head != null)
                    head.Prev = null;
                return;
            }

            Node current = head;
            while (current != null && current.Data.Id != id)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine("NOT FOUND");
                return;
            }

            current.Prev.Next = current.Next;
            if (current.Next != null)
                current.Next.Prev = current.Prev;
        }

        public void SearchStudent()
        {
            int choice;
            do
            {
                Console.WriteLine("Search by:");
                Console.WriteLine("[1] ID");
                Console.WriteLine("[2] Name");
                Console.Write("Enter choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2));

            if (choice == 1)
            {
                int searchId = Student.ReadIntFromConsole("Enter Student ID: ");
                Node temp = head;
                while (temp != null)
                {
                    if (temp.Data.Id == searchId)
                    {
                        PrintStudent(temp.Data);
                        return;
                    }
                    temp = temp.Next;
                }
                Console.WriteLine("STUDENT NOT FOUND");
            }
            else if (choice == 2)
            {
                Console.Write("Enter Student Name (First or Last): ");
                string searchName = Console.ReadLine();
                Node temp = head;
                bool found = false;

                while (temp != null)
                {
                    if (temp.Data.FirstName.Equals(searchName, StringComparison.OrdinalIgnoreCase) ||
                        temp.Data.LastName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!found)
                        {
                            Console.WriteLine("Matching Students Found:");
                        }
                        found = true;
                        PrintStudent(temp.Data);
                    }
                    temp = temp.Next;
                }

                if (!found)
                    Console.WriteLine("NO STUDENTS MATCH THAT NAME");
            }
        }

        public void UpdateStudent(int id)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data.Id == id)
                {
                    Console.WriteLine("Student Found. Enter new details:");

                    Console.Write("First Name: ");
                    temp.Data.FirstName = Console.ReadLine();

                    Console.Write("Last Name: ");
                    temp.Data.LastName = Console.ReadLine();

                    Console.Write("Course: ");
                    temp.Data.Course = Console.ReadLine();

                    Console.Write("Year Level (e.g., 1st, 2nd, 3rd): ");
                    temp.Data.Year = Console.ReadLine();

                    temp.Data.School = Student.ReadSchoolFromConsole();

                    temp.Data.ContactNumber = Student.ReadLongFromConsole("Contact #: ");

                    Console.Write("Email: ");
                    temp.Data.Email = Console.ReadLine();

                    Console.WriteLine("Record Updated Successfully");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Student NOT FOUND");
        }

        public void DisplayRecords()
        {
            if (head == null)
            {
                Console.WriteLine("NO RECORDS");
                return;
            }

            Node temp = head;

            while (temp != null)
            {
                PrintStudent(temp.Data);

                char choice;
                do
                {
                    Console.WriteLine("Options: N = Next, P = Prev, E = Exit");
                    choice = Char.ToUpper(Console.ReadKey(true).KeyChar);
                }
                while (choice != 'N' && choice != 'P' && choice != 'E');

                if (choice == 'N')
                {
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("END OF LIST - Press any key to continue...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
                else if (choice == 'P')
                {
                    if (temp.Prev != null)
                    {
                        temp = temp.Prev;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("NO PREVIOUS RECORDS - Press any key to continue...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
                else if (choice == 'E')
                {
                    break;
                }
            }
        }

        private void PrintStudent(Student s)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"ID: {s.Id}");
            Console.WriteLine($"First Name: {s.FirstName}");
            Console.WriteLine($"Last Name: {s.LastName}");
            Console.WriteLine($"Course: {s.Course}");
            Console.WriteLine($"Year: {s.Year}");
            Console.WriteLine($"School: {s.School}");
            Console.WriteLine($"Contact #: {s.ContactNumber}");
            Console.WriteLine($"Email: {s.Email}");
        }
    }
}
