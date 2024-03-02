using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.basic_control_structures
{
    public class LoopOperations
    {
        /// <summary>
        /// This method demonstrates the use of a while loop
        /// It counts down from the given number to 0.
        /// </summary>
        /// <param name="start">the starting number</param>
        /// <returns>The final value of the start variable</returns>
        public int CountDownWhile(int start)
        {
            while (start > 0)
            {
                start--;
            }
            return start; // Should return 0
        }

        /// <summary>
        /// This method demonstrates the use of a do-while loop
        /// It counts down from the given number to 0
        /// </summary>
        /// <param name="number">The starting number</param>
        /// <returns>The final value of the number variable</returns>
        public int DoWhileExample(int number)
        {
            do
            {
                number--;
            } while (number > 0);
            return number; // Should return 0
        }

        /// <summary>
        /// This method demonstrates the use of a for loop
        /// It calculates the sum of numbers from start to end, inclusive
        /// </summary>
        /// <param name="start">The starting number</param>
        /// <param name="end">The ending number</param>
        /// <returns></returns>
        public int ForLoopSum(int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += i;
            }
            return sum; // Sum of start to end, inclusive
        }

        /// <summary>
        /// This method demonstrates the use of a for-each loop
        /// It calculates the sum of all elements in the given array
        /// </summary>
        /// <param name="numbers">The array of numbers</param>
        /// <returns>The sum of all elements in the array</returns>
        public int ForEachSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum; // Sum of array elements
        }

        /// <summary>
        /// This method demonstrates the use of a for loop
        /// It finds the first positive number in the given array
        /// And also highlights the use of the return statement
        /// </summary>
        /// <param name="numbers">The array of numbers</param>
        /// <returns>The first positive number in the array</returns>
        public int FindFirstPositiveReturn(int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    return num; // Returns the first positive number and exits the method
                }
            }
            return 0; // No positive number found
        }

        /// <summary>
        /// This method demonstrates the use of a for loop
        /// It finds the first positive number in the given array and prints it
        /// And also highlights the use of the break statement
        /// </summary>
        /// <param name="numbers">the array of numbers</param>
        public void FindAndPrintFirstPositiveBreak(int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    Console.WriteLine(num); // Prints the first positive number
                    break; // Exits the loop
                }
            }
        }

        /// <summary>
        /// This method demonstrates the use of a for loop.
        /// It prints all non-negative numbers in the given array.
        /// And also highlights the use of the continue statement.
        /// </summary>
        /// <param name="numbers">the array of numbers</param>
        public void PrintAllExceptNegativeContinue(int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num < 0)
                {
                    continue; // Skips the current iteration, so negative numbers are not printed
                }
                Console.WriteLine(num); // Prints non-negative numbers
            }
        }
    }
}
