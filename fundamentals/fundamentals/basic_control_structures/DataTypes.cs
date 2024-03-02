using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.basic_control_structures
{
    public class DataTypes
    {
        public void DataTypesSample()
        {
            // Simple (Primitive) data types
            int myInt = 100;
            double myDouble = 10.5;
            bool myBoolean = true;
            char myChar = 'A';

            // Wrapper class equivalent in C# (though not commonly referred to as such)
            Int32 myInteger = 200; // No explicit autoboxing needed, it's a value type in C#

            // Reference data type
            string myString = "Hello, C#!";

            // Demonstrating operations
            // Arithmetic operation
            int sum = myInt + myInteger; // Direct addition, no unboxing required as in Java

            // String concatenation
            string greeting = myString + " We are working with data types.";

            // Boolean in control flow
            if (myBoolean)
            {
                Console.WriteLine("Boolean value is true.");
            }
            else
            {
                Console.WriteLine("Boolean value is false.");
            }

            // Displaying results
            Console.WriteLine("Integer value: " + myInt);
            Console.WriteLine("Double value: " + myDouble);
            Console.WriteLine("Character value: " + myChar);
            Console.WriteLine("Wrapped Integer value: " + myInteger); // In C#, this is just another int
            Console.WriteLine("Sum of myInt and myInteger: " + sum);
            Console.WriteLine(greeting);
        }
    }
}
