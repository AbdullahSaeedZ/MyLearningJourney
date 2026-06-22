using System;

namespace TestProject
{
    /*
      ====================================================================================================
      LESSON: METHOD CHAINING & THE FLUENT API PATTERN
      ====================================================================================================
      
      ====================================================================================================
      1. THE PROBLEM: BOILERPLATE CLUTTER AND REPETITIVE VARIABLES
      ====================================================================================================
      When configuring complex objects, building strings, or executing queries, traditional code requires 
      you to call a method, store the result, or type the object name repeatedly on every single line. 
      
      This introduces "boilerplate clutter." It forces you to read line-by-line vertically, creating temporary
      states that make the code harder to scan, maintain, and write cleanly.
      
      ====================================================================================================
      2. THE CORE IDEA: THE "RETURN THIS" MECHANISM
      ====================================================================================================
      Method Chaining allows you to string multiple method calls together sequentially in a single statement, 
      reading smoothly from left to right (or top to bottom). 
      
      The magic behind this pattern is incredibly simple: **Every method executes its logic, and then returns 
      the exact instance of the object it belongs to (`return this;`).**
      
      Because the method outputs the object itself, you can immediately append a dot (`.`) and call the 
      next method in the pipeline without breaking the chain.
    */

    // ================================================================================================
    // UNDER THE HOOD: HOW A FLUENT CLASS IS BUILT
    // ================================================================================================
    public class LicensePlateBuilder
    {
        private string _prefix = "";
        private string _numbers = "";
        private string _suffix = "";

        // Standard method returns void, breaking the chain.
        // Fluent method returns the class type (LicensePlateBuilder) to access the object methods and keep the chain alive.
        public LicensePlateBuilder SetPrefix(string prefix)
        {
            _prefix = prefix;
            return this; // <-- CRITICAL: Returns the exact same instance!
        }

        public LicensePlateBuilder SetNumbers(string numbers)
        {
            _numbers = numbers;
            return this; // <-- CRITICAL: Allows the next dot (.) call
        }

        public LicensePlateBuilder SetSuffix(string suffix)
        {
            _suffix = suffix;
            return this;
        }

        public string Build()
        {
            return $"{_prefix} - {_numbers} - {_suffix}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== APPROACH 1: BEFORE METHOD CHAINING (TRADITIONAL) ===");
            // We have to repeat the variable name 'traditionalBuilder' on every single line.

            LicensePlateBuilder traditionalBuilder = new LicensePlateBuilder();
            traditionalBuilder.SetPrefix("KSA");
            traditionalBuilder.SetNumbers("1234");
            traditionalBuilder.SetSuffix("DLV");
            string plate1 = traditionalBuilder.Build();

            Console.WriteLine($"Result 1: {plate1}");


            Console.WriteLine("\n=== APPROACH 2: AFTER METHOD CHAINING (THE FLUENT WAY) ===");
            // Because each method returns 'this', we chain them cleanly. 
            // We can break lines at the dot (.) to make it incredibly readable.

            string plate2 = new LicensePlateBuilder()
                .SetPrefix("USA")
                .SetNumbers("7777")
                .SetSuffix("TX")
                .Build(); // The final .Build() returns the actual string, ending the chain.

            Console.WriteLine($"Result 2: {plate2}");


            Console.WriteLine("\n=== REAL-WORLD COMMON EXAMPLES YOU ALREADY USE ===");

            // Example A: System.Text.StringBuilder uses method chaining natively
            string message = new System.Text.StringBuilder()
                .Append("Hello ")
                .Append("Abu Fahad! ")
                .AppendLine("Welcome to modern C#.")
                .ToString();

            Console.WriteLine(message);
        }

        /*
          ====================================================================================================
          3. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
          ====================================================================================================
          * Debugging Friction: If a massive chain crashes at runtime, the stack trace might point to the 
            entire block rather than the specific sub-method. Keep chains logical and focused.

          * The "Fluent Everything" Trap: Do not waste time making every single domain class fluent. 
            Method chaining is highly practical for Configurations, Queries (like LINQ), and Creational 
            Design Patterns (like the Builder Pattern). For standard business entities, simple properties 
            with getters and setters are much preferred.
        */
    }
}