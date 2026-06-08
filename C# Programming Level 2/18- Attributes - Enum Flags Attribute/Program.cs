namespace _18__Attributes___Enum_Flags_Attribute
{

    /*
      === Flagged Enums in C# ===
      * 1. The Purpose (Why it exists):
      - Standard Enums only allow a variable to hold a single value at a time (e.g., DayOfWeek = Monday).
      - Flagged Enums solve this by allowing a single variable to store a COMBINATION of multiple values 
        simultaneously (e.g., WorkingDays = Monday | Wednesday | Friday) without needing a List or Array.
      - It is highly efficient in memory and database storage because it uses simple bitwise operations.


      * 2. Conditions to Apply (Rules for it to work properly):
      
      - Rule 1: You MUST decorate the enum with the [Flags] attribute so the Compiler/Runtime 
        treats it as bit flags (enabling correct .ToString() formatting and parsing).

      - Rule 2: Each enum member MUST be assigned a numeric value that is a POWER OF 2 (1, 2, 4, 8, 16, etc.) 
        or use bit-shifting (1 << 0, 1 << 1, etc.). Sequential numbers (1, 2, 3, 4) will BREAK the logic.

      - Rule 3: It is best practice to include a 'None = 0' value to represent an empty state or no flags selected.

      - Rule 4: The total number of flags cannot exceed the underlying type limit (e.g., max 32 flags for 'int' which is default, max 64 for 'ulong').
     */

    [Flags]
    public enum DaysOfWeek
    {
        None = 0,   
        Sunday = 1 << 0,   
        Monday = 1 << 1,   
        Tuesday = 1 << 2,  
        Wednesday = 1 << 3,
        Thursday = 1 << 4, 
        Friday = 1 << 5,   
        Saturday = 1 << 6, 

        // Useful combinations (Shortcuts)
        Weekdays = Monday | Tuesday | Wednesday | Thursday,
        Weekend = Friday | Saturday | Sunday
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. Combining multiple days using the Bitwise OR (|) operator
            DaysOfWeek workingDays = DaysOfWeek.Monday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday;

            // Thanks to [Flags], ToString() will print: "Monday, Wednesday, Thursday"
            Console.WriteLine($"My working days are: {workingDays}");

            // 3. Checking if a specific day is included using HasFlag()
            bool isMondayAWorkingDay = workingDays.HasFlag(DaysOfWeek.Monday);
            Console.WriteLine($"Do I work on Monday? {isMondayAWorkingDay}"); // True

            bool isFridayAWorkingDay = workingDays.HasFlag(DaysOfWeek.Friday);
            Console.WriteLine($"Do I work on Friday? {isFridayAWorkingDay}"); // False

            // 4. toggling a day using toggle (^)
            // toggle will toggle the state of the chosen enum,
            // meaning if it was not included in the combination then it will be added, if it was in the combination then it will be remove, it is toggling
            workingDays = workingDays ^ DaysOfWeek.Friday;
            Console.WriteLine($"Updated working days (toggled Friday, now it is added): {workingDays}");

            // 5. Removing a day using Bitwise AND and NOT (& ~)
            workingDays = workingDays & ~DaysOfWeek.Thursday;
            Console.WriteLine($"Updated working days (removed Thursday): {workingDays}");

            /*
              === Removing a Flag Using Bitwise AND and NOT (& ~) ===
              * 1. The Core Idea:
              To remove a specific flag from a combined enum variable, we must force its specific bit to '0' 
              while keeping all other bits exactly as they were.
              * 2. How it Works Internally (Step-by-Step):
              - Step A: The NOT operator (~Thursday) creates a "Mask". It flips all bits of Thursday, 
              turning Thursday's bit to '0' and all other bits in the entire enum to '1'.
              - Step B: The AND operator (&) compares the original variable with this inverted mask.
              Since '1 & 0 = 0', Thursday's bit is forced to turn off (0).
              Since '1 & 1 = 1' and '0 & 1 = 0', all other original flags remain completely untouched.
             */
        }
    }
}
