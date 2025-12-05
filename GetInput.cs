// a class to handle getting cli input.
using System;

namespace CIS207.Input
{
    internal class GetInput
    {

        public static int AsInt(string prompt)                                      // static method to show a given prompt and return input as an int
        {
            while (true)                                                            // loop until valid input
            {
                Console.Write($"{prompt}: ");                                       // print the prompt
                string input = Console.ReadLine() ?? "";                            // get input

                if (int.TryParse(input, out int value))                             // try to parse input to int
                { return value; }                                                   // return the int

                Console.WriteLine("Invalid number. Please enter a valid integer."); // or print error
            }
        }

        public static int AsInt(string prompt, int min, int max)                    // static method to get int between given min and max
        {
            while (true)                                                            // loop until valid input
            {
                int value = AsInt($"{prompt} ({min} - {max})");                     // call regular int input method

                if (value >= min && value <= max)                                   // check if input in bounds
                { return value; }                                                   // return the int

                Console.WriteLine($"Value must be between {min} and {max}.");       // or print out of bounds error
            }
        }


        public static double AsDouble(string prompt)                                // static method to return input as a double
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine() ?? "";

                if (double.TryParse(input, out double value))
                { return value; }

                Console.WriteLine("Invalid number. Please enter a valid decimal value.");
            }
        }

        public static double AsDouble(string prompt, int min, int max)              // static method to get double within given bounds
        {
            while (true)
            {
                double value = AsDouble($"{prompt} ({min} - {max})");

                if (value >= min && value <= max)
                { return value; }

                Console.WriteLine($"Value must be between {min} and {max}.");
            }
        }


        public static decimal AsDecimal(string prompt)                              // static method to return input as decimal
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine() ?? "";

                if (decimal.TryParse(input, out decimal value))
                { return value; }

                Console.WriteLine("Invalid number. Please enter a valid decimal value.");
            }
        }

        public static decimal AsDecimal(string prompt, int min, int max)            // static method to get decimal within bounds
        {
            while (true)
            {
                decimal value = AsDecimal($"{prompt} ({min} - {max})");

                if (value >= min && value <= max)
                { return value; }

                Console.WriteLine($"Value must be between {min} and {max}.");
            }
        }


        public static string AsString(string prompt)                                // static method to return string
        {
            while (true)                                                            // loop until valid input
            {
                Console.Write($"{prompt}: ");                                       // print prompt
                string input = Console.ReadLine() ?? "";                            // get input

                if (!string.IsNullOrWhiteSpace(input))                              // check if null or whitespace
                { return input; }                                                   // return string

                Console.WriteLine("Input cannot be empty. Please try again.");      // or print error message
            }
        }
    }
}
