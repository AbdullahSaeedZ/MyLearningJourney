using System;

namespace InputExample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ===== Using Console.Read() =====
            // Reads the next character from the input stream and returns its ASCII value.
            // You must press Enter after typing the character.

            Console.Write("Enter a single character: ");
            int charASCII = Console.Read(); // Reads one character as its ASCII code
            // then convert ASCII to the actual character using (char)
            char character = (char)charASCII;
            Console.WriteLine($"ASCII value: {charASCII}");
            Console.WriteLine($"Character: {character}");



            // ===== Reading a String Input =====
            Console.Write("Enter your name: ");
            string name = Console.ReadLine(); // Always returns string input




            // ===== Reading an Integer Input =====
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine()); // Converts string → int





            // ===== Reading a Decimal (Double) Input =====
            Console.Write("Enter your height in meters: ");
            double height = Convert.ToDouble(Console.ReadLine()); // Converts string → double




            // ===== Safe Conversion using TryParse =====
            // TryParse prevents program crashes if the user enters invalid input.
            Console.Write("Enter your score: ");
            string input = Console.ReadLine();
            int score;

            // Try to parse the input into an integer
            if (int.TryParse(input, out score))
            {
                Console.WriteLine($"Score saved successfully: {score}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }





            // ===== Basic ReadKey (Wait for any key) =====
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); // Waits for any key press before continuing

            Console.WriteLine("\n---------------------------------");



            // ===== ReadKey with Key Storage =====
            // Here we store the pressed key in a variable for decision-making


            // ConsoleKeyInfo is a struct that stores information about the key the user pressed.
            // It is returned by Console.ReadKey() and contains details like:
            // - Key: which key was pressed (e.g., ConsoleKey.Y)
            // - KeyChar: the actual character of the key (e.g., 'y') // we can kind of say case sensitive
            // - Modifiers: whether Shift, Alt, or Ctrl were also press

            Console.WriteLine("Do you want to continue? (Y/N)");
            ConsoleKeyInfo pressedKey = Console.ReadKey(); // Reads a single key press



            if (pressedKey.Key == ConsoleKey.Y)
            {
                Console.WriteLine("\nYou chose YES");
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                Console.WriteLine("\nYou chose NO");
            }
            else
            {
                Console.WriteLine("\nInvalid key pressed.");
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Program finished. Press any key to exit...");
            Console.ReadKey(); // Final pause before closing
        }
    }
}
