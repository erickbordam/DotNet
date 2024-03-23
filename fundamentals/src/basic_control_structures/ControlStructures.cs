using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.basic_control_structures
{
    public class ControlStructures
    {
        /// <summary>
        /// This method checks the age group of a person based on the given age.
        /// The purpose of this method is to demonstrate the use of control structures
        /// through if, else if and else manipulation
        /// </summary>
        /// <param name="age">The age of the person</param>
        /// <returns>The age group of the person</returns>
        public string CheckAgeGroup(int age)
        {
            Console.WriteLine("Age: " + age);
            string ageVal = "";
            if (age < 13)
            {
                ageVal = "Child";
            }
            else if (age >= 13 && age <= 19)
            {
                ageVal = "Teenager";
            }
            else if (age > 19 && age < 65)
            {
                ageVal = "Adult";
            }
            else if (!(age < 13 || age >= 65))
            {
                ageVal = "Specific age group";
            }
            else
            {
                ageVal = "Other";
            }
            Console.WriteLine("Age group: " + ageVal);
            return ageVal;
        }
        /// <summary>
        /// This method checks the day name based on the given day number
        /// The purpose of this method is to demonstrate the use of control structures
        /// through switch manipulation
        /// </summary>
        /// <param name="dayNumber">the day number</param>
        /// <returns>the day name</returns>
        public string GetDayName(int dayNumber)
        {
            Console.WriteLine("Day number: " + dayNumber);
            string dayName;
            switch (dayNumber)
            {
                case 1:
                    dayName = "Sunday";
                    break;
                case 2:
                    dayName = "Monday";
                    break;
                case 3:
                    dayName = "Tuesday";
                    break;
                case 4:
                    dayName = "Wednesday";
                    break;
                case 5:
                    dayName = "Thursday";
                    break;
                case 6:
                    dayName = "Friday";
                    break;
                case 7:
                    dayName = "Saturday";
                    break;
                default:
                    dayName = "Invalid day number";
                    break;
            }
            Console.WriteLine("Day: " + dayName);
            return dayName;
        }

        /// <summary>
        /// This method checks the age group of a person based on the given age.
        /// The purpose of this method is to demonstrate the use of control structures
        /// through if, else if and else manipulation.
        /// </summary>
        /// <param name="originalPrice">The original price of the item</param>
        /// <param name="customerType">The type of customer ("regular" or "premium")</param>
        /// <returns>The discounted price</returns>
        public double CalculateDiscount(double originalPrice, string customerType)
        {
            double discountRate = customerType.Equals("premium", StringComparison.OrdinalIgnoreCase) ? 0.2 : 0.1; // 20% for premium, 10% for regular
            return originalPrice * (1 - discountRate);
        }

    }
}
