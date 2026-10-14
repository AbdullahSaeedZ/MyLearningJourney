/*
====================================================================================================
                             LINQ QUANTIFIERS - CONTAINS()
====================================================================================================

1. THE PROBLEM:
   You need to determine whether a collection contains a specific element or value without writing
   repetitive foreach loops and manual equality checks.

2. THE CORE IDEA:
   Contains() checks if a sequence contains a specified item and returns a bool:
   - Contains(value) : Evaluates whether 'value' exists in the sequence.

3. KEY ARCHITECTURAL POINTS:

   A. Instance Method vs. LINQ Extension Method:
      - On `string` (e.g., `emp.Name.Contains("John")`):
        This is an INSTANCE method on `System.String`. It checks whether a substring exists inside a string.
        
      - On collections (e.g., `employees.Contains(target)` or `emp.Skills.Contains("C++")`):
        This is the LINQ EXTENSION method defined in `System.Linq.Enumerable`. It checks whether an element
        exists inside an `IEnumerable<T>`.

   B. Algorithmic Complexity: O(N) vs. O(1) with Hash-based Collections:
      - Over `IEnumerable<T>` or `List<T>`:
        LINQ performs a linear scan from index 0 to N.
        Time Complexity = O(N) (Slow for huge datasets).
        
      - Over `HashSet<T>`: (will be explained fully in course 22)
        The CLR casts `IEnumerable<T>` to `ICollection<T>` internally. Because `HashSet<T>` uses a hash table
        with buckets calculated via `GetHashCode()`, lookup is near-instantaneous.
        Time Complexity = O(1) (Constant time lookup).

   C. Class Equality (`Equals` & `GetHashCode` Overrides):
      - By default, C# classes compare by MEMORY ADDRESS (Reference Equality).
      - When your class overrides `Equals()` and `GetHashCode()` (like did in Employee class using `Email`),
        LINQ's `Contains()` uses your overridden `Equals()` logic instead of checking memory addresses.
        Two different instances with the same email will be treated as EQUAL!

   ASCII Diagram (HashSet O(1) vs. List O(N)):

   List<T>.Contains(Target) -> O(N) Linear Scan:
   [ Emp 01 ] -> [ Emp 02 ] -> [ Emp 03 ] -> [ Target Emp ] (Iterates step by step)

   HashSet<T>.Contains(Target) -> O(1) Hash Lookup:
   Target.GetHashCode() ===> Bucket Index 42 ===> [ Target Emp ] (Direct jump, no scanning)
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Quantifiers.Shared;

namespace Contains_Quantifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                  LINQ QUANTIFIERS: CONTAINS()                    ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // Point 1: Instance Method (on String) vs LINQ Extension (on Collection)
            // =========================================================================
            var sampleEmployee = employees.First();

            // 1A. Instance Method on String (Substring search):
            bool nameHasJohn = sampleEmployee.Name.Contains("John"); // Belongs to System.String

            // 1B. LINQ Extension Method on IEnumerable (Element search):
            bool hasCppSkill = sampleEmployee.Skills.Contains("C++"); // Belongs to System.Linq.Enumerable

            Console.WriteLine($"Employee: {sampleEmployee.Name}");
            Console.WriteLine($"1. String Instance Method  -> Name contains 'John' : {nameHasJohn}");
            Console.WriteLine($"2. LINQ Extension Method   -> Skills contains 'C++' : {hasCppSkill}\n");


            // =========================================================================
            // Point 2: Overridden Equals() & GetHashCode() in Employee
            // Because we overrode Equals() comparing 'Email', a brand new
            // instance with the same Email matches successfully!
            // =========================================================================
            Console.WriteLine("--- Overridden Equals() in Employee ---");

            // Brand new object in memory (different heap reference), but matching Email:
            var employeeToFind = new Employee
            {
                Email = sampleEmployee.Email // Same email as the first employee
            };

            // Without overriding Equals(), this would return FALSE (checks memory reference).
            // With the Equals() override, it returns TRUE (checks value by Email).
            // Complexity: Still O(N) because IEnumerable<T> enumerates sequentially via MoveNext().
            bool employeeExists = employees.Contains(employeeToFind);

            Console.WriteLine($"Looking for employee by Email: {employeeToFind.Email}");
            Console.WriteLine($"Found in repository via overridden Equals(): {employeeExists}\n");


            // =========================================================================
            // Point 3: Performance Difference - O(N) Scan vs O(1) Hash Lookup
            //
            // Q: Is O(N) specific to List<T> or IEnumerable<T> in general?
            // A: It applies to BOTH.
            //    - IEnumerable<T> only provides forward iteration (MoveNext()), which is always O(N).
            //    - List<T> is an array internally; finding an unsorted item requires scanning
            //      index by index, which is also O(N).
            //    - HashSet<T> uses GetHashCode() to map directly to a memory bucket, achieving O(1).
            // =========================================================================
            Console.WriteLine("--- O(N) Linear Scan vs O(1) HashSet Lookup ---");

            // A. List<Employee> -> O(N) Linear Scan
            // Checks each item sequentially from index 0 until a match is found.
            List<Employee> employeeList = employees.ToList();
            bool foundInList = employeeList.Contains(employeeToFind); // O(N)

            // B. HashSet<Employee> -> O(1) Constant-Time Lookup
            // Calls employeeToFind.GetHashCode() to jump directly to the target bucket.
            // No sequential loop is performed.
            HashSet<Employee> employeeSet = employees.ToHashSet();
            bool foundInSet = employeeSet.Contains(employeeToFind);   // O(1)

            Console.WriteLine($"Found in List<Employee>    (Linear scan O(N)) : {foundInList}");
            Console.WriteLine($"Found in HashSet<Employee> (Hash lookup O(1)) : {foundInSet}");
        }
    }
}