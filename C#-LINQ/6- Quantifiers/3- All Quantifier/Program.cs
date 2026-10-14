
/*
====================================================================================================
                              LINQ QUANTIFIERS - ALL()
====================================================================================================

1. THE PROBLEM:
   You need to validate an entire dataset against a business rule or invariant:
   - "Did every student pass the exam?"
   - "Do all employees have an email address on file?"
   - "Are all transaction records marked as settled?"
   Without All(), you would write a foreach loop, check if any single item fails, toggle a flag,
   and break manually.

2. THE CORE IDEA:
   All(predicate) determines whether EVERY element in a sequence satisfies a condition:
   - Returns true if every element satisfies the predicate.
   - Returns false the INSTANT a single element fails the predicate (short-circuit).
   - Vacuous Truth: If the collection is EMPTY, All() returns TRUE for ANY condition!

   ASCII Diagram:

   All(x => x.Salary >= 100000):
   Input:  [ 103,200 ]  [ 192,400 ]  [ 85,000 ]  [ 210,000 ]
           |-- True --| |-- True --| |- FALSE -|
                                     (Halt: Returns FALSE immediately! 210,000 is NEVER checked)

   All(x => x.Salary >= 50000) (All pass):
   Input:  [ 103,200 ] [ 192,400 ] [ 85,000 ]
           |-- True --| |-- True --| |-- True --| --> Returns TRUE after inspecting all items.

3. CAN ANY() REPLACE ALL()? (DE MORGAN'S LAWS):
   YES. Mathematically and logically:
   
       collection.All(condition)  ===  !collection.Any(!condition)

   - Statement A (using All): "All employees earn at least $50,000."
   - Statement B (using Any): "It is NOT true that ANY employee earns LESS than $50,000."
   Both produce the exact same boolean result.
   
   Why choose All() over !Any(!x)?
   - Readability: All() directly expresses the positive intent without mental double-negatives.
   - Vacuous Truth handling: On an empty collection, !Any(...) yields true, matching All().

4. HOW IT WORKS INTERNALLY:
   - Immediate Execution: Returns a scalar bool immediately.
   - Short-Circuiting: Loops via MoveNext(). The FIRST time predicate(current) returns false,
     it stops enumeration immediately and returns false. It only iterates the full sequence
     if every element passes.
   - SQL Translation (EF Core): Translates to NOT EXISTS (SELECT 1 FROM ... WHERE NOT (condition)).

5. COMMON PITFALLS:
   - Vacuous Truth Trap: Calling .All(...) on an empty collection ALWAYS returns TRUE.
     If you need the collection to also be non-empty, check list.Any() && list.All(...).
   - Inverted Logic Bugs: When replacing All() with !Any(), forgetting to invert the internal
     condition creates silent bugs.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Quantifiers.Shared;

namespace _3__All_Quantifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                    LINQ QUANTIFIERS: ALL()                       ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // Example 1: Basic All() validation
            // Question: Does every employee earn at least $50,000?
            // Why: Evaluates every employee. If even ONE earns less, it halts and returns false.
            // =========================================================================
            bool allEarnAbove50K = employees.All(e => e.Salary >= 50000);
            Console.WriteLine($"1. Does every employee earn >= $50,000? : {allEarnAbove50K}");

            // Question: Does every employee have at least 1 skill recorded?
            bool allHaveSkills = employees.All(e => e.Skills.Count > 0);
            Console.WriteLine($"2. Does every employee have skills?      : {allHaveSkills}\n");


            // =========================================================================
            // Example 2: Replicating All() using Any() (De Morgan's Laws)
            // Rule: All(condition) is identical to !Any(opposite_condition)
            // =========================================================================
            Console.WriteLine("--- Equivalence Demo: All() vs !Any(!cond) ---");

            // Check using All:
            // "Are all employees' names at least 3 characters long?"
            bool checkUsingAll = employees.All(e => e.Name.Length >= 3);

            // Equivalent check using Any:
            // "Is it NOT true that ANY employee has a name SHORTER than 3 characters?"
            bool checkUsingAny = !employees.Any(e => e.Name.Length < 3);

            Console.WriteLine($"Check using All(e => e.Name.Length >= 3)   : {checkUsingAll}");
            Console.WriteLine($"Check using !Any(e => e.Name.Length < 3)   : {checkUsingAny}");
            Console.WriteLine($"Are the results identical?                  : {checkUsingAll == checkUsingAny}\n");


            // =========================================================================
            // Example 3: The "Vacuous Truth" Gotcha (Empty Collections)
            // An empty collection returns TRUE for All() regardless of the predicate!
            // =========================================================================
            Console.WriteLine("--- The Empty Collection Trap (Vacuous Truth) ---");

            var emptyEmployees = new List<Employee>();

            // Logically: "There are no counterexamples in an empty list, so it must be true."
            bool emptyResultAll = emptyEmployees.All(e => e.Salary > 1000000);
            bool emptyResultAny = !emptyEmployees.Any(e => e.Salary <= 1000000);

            Console.WriteLine($"Empty list .All(Salary > 1,000,000)        : {emptyResultAll} (Always True!)");
            Console.WriteLine($"Empty list !.Any(Salary <= 1,000,000)      : {emptyResultAny} (Always True!)");
            
            // The safe pattern if you must require both existence AND condition satisfaction:
            bool safeCheck = emptyEmployees.Any() && emptyEmployees.All(e => e.Salary > 1000000);
            Console.WriteLine($"Safe check (Any() && All(...))              : {safeCheck}");

            // using All with Where method for example, eliminating any employee that has at least one skill of less than 3 letters, like C#:
            Console.WriteLine("\n\nEmployees with skills that consist of more than 2 letters");
            var test = employees.Where(emp => emp.Skills.All(skill => skill.Length > 2));
            foreach (var employee in test)
            {
                Console.WriteLine(employee);
            }
        }
    }
}