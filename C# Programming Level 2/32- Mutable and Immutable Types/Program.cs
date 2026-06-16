namespace _32__Mutable_and_Immutable_Types
{
    // In C#, types are classified as either mutable or immutable based on whether their instances can be modified after they are created.

    // 1- Mutable Types:
    // Mutable types are types whose instances CAN BE MODIFIED after they are created.
    // Properties or fields of a mutable type can be changed.
    // Examples include classes, arrays, and custom objects where properties can be modified.

    // example of a mutable class:
    public class MutablePerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    // 2- Immutable Types:
    // Immutable types are types whose instances CANNOT BE MODIFIED after they are created.
    // Properties or fields of an immutable type cannot be changed after the instance is created.
    // Any operation that appears to modify the instance actually returns a new instance with the desired changes.
    // Examples include strings, tuples, and some built-in value types.

    // example of an immutable class:
    public class ImmutablePerson
    {
        public string Name { get; }
        public int Age { get; }

        public ImmutablePerson(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }


    /*
     Pros and Cons:

     1- Mutable Types:

      Pros: 
      - More flexible for certain scenarios.
      - Can be more memory-efficient if state changes frequently.
      Cons: 
      - Prone to unintended side effects, like in multithreading where there can be multiple processes accessing same object and can one process will modify it then cause unwanted effect for other processes.
      - May require additional effort to maintain consistency.

     2- Immutable Types:

      Pros: 
      - Safer and less error-prone since instances cannot be modified.
      - Easier to reason about and maintain.
      Cons: 
      - Creating a new instance for each modification can be less memory-efficient for certain scenarios,
        like in strings, where changing the value will create a new instance with the new value in background, and the same reference variable will point to the new instance
     
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            // example of how strings are immutable
            string s1 = "Hello";
            string s2 = s1; // s2 now references to the "Hello" object
            s1 = "World"; // s1 now is pointing to a new object, while s2 still points to the old object

            Console.WriteLine(s2);
        }
    }
}
