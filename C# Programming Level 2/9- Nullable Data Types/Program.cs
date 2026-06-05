namespace _9__Nullable_Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nullable data types are data types that can hold null value

            // the issue:
            // in DVLD, when i needed to reciece int values from DB then put them in int variables in app, but sometimes DB values are null
            // so i was handling this situation by using if statements to put -1 or 0 if the data form DB is null

            // solution:
            // is naullable data types, where we can assign null values, implemented this way:

            Nullable<int> nullable = null;

            // or a shortened way:

            int? nullableInt = null;
            DateTime? nullableDate = null; // instead of storing old dates as initial value

            // it can be used on any value data type, not reference data types

            // to check if the variable is null or has a value through HasValue method:
            if (nullableInt.HasValue)
            {
                Console.WriteLine("nullable variable has value");
            }
            else
            {
                Console.WriteLine("nullable variable has no value");
            }

            // another way to check is by using a null-coalescing operator:
            int result = nullableInt ?? 0;  // if nullableInt has value, then return it, otherwise return a default value which i choose to be 0

            // we can use the Null-Conditional operator to avoid execution on a null reference then throw an exception:
            string name = nullableInt?.ToString(); // same used in delegates, if the variable is null, then it wont run the toString method and will return null

            // practice:
            Console.WriteLine($"Your name is: {name ?? "not provided" }");

            int? Age = null;
            Console.WriteLine($"Your Age is: {Age?.ToString() ?? "not provided" }");

        }
    }
}
