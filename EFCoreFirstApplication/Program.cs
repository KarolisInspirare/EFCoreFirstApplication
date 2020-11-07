using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EFCoreFirstApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my first EF application!");

            Console.WriteLine("Please enter your first name to register:");

            var inputName = Console.ReadLine();

            using (var context = new SchoolContext()) 
            {
                var Std = new Student()
                {
                    Name = inputName
                };

                context.Students.Add(Std);
                context.SaveChanges();

                Console.WriteLine("You are number: ", Std.StudentId);
                Console.WriteLine("Thank you for registering!");
            }

            Console.WriteLine("If you want to find out all registered - press 1, else 0?");

            var input = Console.ReadLine();
            var isDoubleParsed = int.TryParse(input, out var inputDouble);

            /*
            if (!isDoubleParsed)
            {
                Console.WriteLine("Please select a valid option.");
                Console.WriteLine("Press any button to try again.");
                Console.ReadKey();
                Main(args);
                return;
            }
            */
            switch (inputDouble) 
            {
                case 0:
                    
                    break;
                
                case 1:
                    using (var context = new SchoolContext())
                    {
                        //var getStudents = new Student();
                        var studentList = context.Students.ToList();

                        foreach (var StudentName in studentList)
                        {
                            Console.WriteLine(" - ", StudentName.Name.ToString());
                        }
                        
                    }
                        break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    Console.WriteLine("Press any button to try again.");
                    Console.ReadKey();
                    Main(args);
                    return;                    
            }
        }
    }
}
