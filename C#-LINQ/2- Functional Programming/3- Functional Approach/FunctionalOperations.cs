namespace _3__Functional_Approach;

// last lesson we were representing operations that are done in a procedural way
// implemented in impure methods:
// they deal with external dependencies (the employees list coming from repository)
// they give step by step instructions (procedural), imperative rather than declarative
// the issue was that for each purpose we have a dedicated method,
// lots of methods for filtering then returning the needed employee collection

// thats whats in the Procedural Operations class

// now we use the Functional paradigm approach, we try to:
// eliminate external dependencies
// being declarative rather than imperative, eliminating instructions (procedural) as much as possible
// moving to purity as much as possible, not creating side effects
public static class FunctionalOperations
{
    // comparing the procedural method in the bottom to this new functinoal approach
     public static IEnumerable<Employee> Filter(IEnumerable<Employee> source, Func<Employee, bool> criteria) // 1. receiving the needed source as parameter rather than calling DB
     {
         foreach (var employee in source)
         {
             if (criteria(employee)) // 2. general filtering passed as parameter
             {
                 yield return employee;
             }
         }
     }
     // notice amount of code we spared:
     
     // old procedural approach
     public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWith(string value)
     {
         var employees = Repository.LoadEmployees(); // 1. eliminated external dependencies
         foreach (var employee in employees)
         {
             if (employee.FirstName.ToLowerInvariant().StartsWith(value.ToLowerInvariant())) // 2. eliminated manual filtering in each method
             {
                 yield return employee;
             }
         }
     }


     public static void Print<T>(IEnumerable<T> source, string title)
     {
         if (source == null)
             return;
         Console.WriteLine();
         Console.WriteLine("┌───────────────────────────────────────────────────────┐");
         Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
         Console.WriteLine("└───────────────────────────────────────────────────────┘");
         Console.WriteLine();
         foreach (var item in source)
             Console.WriteLine(item);
     }
}