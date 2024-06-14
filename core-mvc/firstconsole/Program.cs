
using System;
namespace firstconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Test t = new Test();
            t.A = 10;
            t.B = 20;
            Console.WriteLine("A = " + t.A + " B = " + t.B);
            Rectangle s = new Rectangle();
            s.Draw();
            Console.WriteLine("Demonstrating SOLID Principles:\n");
            Console.WriteLine("Demonstrating SOLID Principles:\n");

            // Single Responsibility Principle (SRP)
            Console.WriteLine("Single Responsibility Principle (SRP):");
            Customer customer = new Customer();
            customer.AddToDatabase();
            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail("customer@example.com", "Welcome to our application!");
            Console.WriteLine();

            // Open/Closed Principle (OCP)
            Console.WriteLine("Open/Closed Principle (OCP):");
            Shape rectangle = new Rectangle { Width = 5, Height = 3 };
            rectangle.CalculateArea();
            Shape circle = new Circle { Radius = 2 };
            circle.CalculateArea();
            Console.WriteLine();

            // Liskov Substitution Principle (LSP)
            Console.WriteLine("Liskov Substitution Principle (LSP):");
            Animal dog = new Dog();
            dog.MakeSound();
            Animal cat = new Cat();
            cat.MakeSound();
            Console.WriteLine();

            // Interface Segregation Principle (ISP)
            Console.WriteLine("Interface Segregation Principle (ISP):");
            IPrintable printer = new Printer();
            printer.Print();
            IScannable scanner = new Scanner();
            scanner.Scan();
            IPrintable multiFunctionDevice = new MultiFunctionDevice();
            multiFunctionDevice.Print();
            IScannable multiFunctionDevice2 = new MultiFunctionDevice();
            multiFunctionDevice2.Scan();
            Console.WriteLine();

            // Dependency Inversion Principle (DIP)
            Console.WriteLine("Dependency Inversion Principle (DIP):");
            IEmailSender emailSenderDIP = new EmailSender();
            UserRegistration userRegistration = new UserRegistration(emailSenderDIP);
            userRegistration.RegisterUser("user@example.com", "password123");


            Console.WriteLine("LINQ Examples:\n");
            // LINQ Examples
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            var query = from i in ints where i > 3 select i;
            foreach (var i in query)
            {
                Console.WriteLine(i);
            }


            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Alice", City = "New York" },
                new Customer { Name = "Bob", City = "New York" },
                new Customer { Name = "Charlie", City = "Chicago" }
            };

            // Complex query
            var query2 = from c in customers
                         where c.City == "New York"
                         select c.Name;
            

        }
    }
}


