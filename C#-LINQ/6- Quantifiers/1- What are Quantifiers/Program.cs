

/*
====================================================================================================
                             LINQ QUANTIFIERS - HIGH-LEVEL INTRO
====================================================================================================

1. THE PROBLEM:
   Often, you don't need to retrieve, slice, or transform records. You only need a simple answer (yes/no ... true/false)
   to a logical question about your data:
   - "Does this collection have anything in it?"
   - "Does at least one record meet this rule?"
   - "Does every single record satisfy this policy?"
   - "Does this specific item exist in the dataset?"
   Writing manual foreach loops with flag variables (`bool found = false;`) and break statements
   for these basic checks creates repetitive, cluttered code.

2. THE CORE IDEA:
   Quantifiers evaluate whether some, all, or specific elements satisfy a condition, returning a bool:
   - Any()       : True if collection is not empty, OR if AT LEAST ONE element matches a condition.
   - All()       : True if EVERY SINGLE element matches a condition.
   - Contains()  : True if the collection contains a SPECIFIC value or reference.

   ASCII Diagrams:

   Any(x => x > 5):
   [ 02 ] [ 04 ] [ 06 ] [ 08 ]  ===> True (Stops checking at [ 06 ]!)
   |--No--|--No--|- YES (Short-circuit) -|

   All(x => x > 5):
   [ 06 ] [ 08 ] [ 03 ] [ 09 ]  ===> False (Stops checking at [ 03 ]!)
   |-Yes--|-Yes--|- NO (Short-circuit) -|

   Contains(Target):
   [ E01 ] [ E02 ] [ Target ] [ E04 ] ===> True (Found target via equality comparer)

3. HOW LINQ HANDLES IT:
   - Immediate Execution: Quantifiers do NOT return an IEnumerable; they execute immediately to a bool.
   - Short-Circuiting:
     * Any() returns true on the VERY FIRST match and stops iterating immediately.
     * All() returns false on the VERY FIRST failure and stops iterating immediately.
   - Database Awareness: In EF Core, Any() translates to SQL `EXISTS (...)`, which avoids pulling
     any rows across the network.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Quantifiers.Shared;

namespace _1__What_are_Quantifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                 LINQ QUANTIFIERS: INTRO DEMO                     ");
            Console.WriteLine("==================================================================\n");

            // Goal 1: Check if AT LEAST ONE employee has a salary over $200,000.
            // Why Any: Stops iterating the moment the first match is found.
            bool hasHighEarners = employees.Any(e => e.Salary > 200000);

            // Goal 2: Check if EVERY SINGLE employee has an email address provided.
            // Why All: Returns true only if all records satisfy the rule; stops on first null/empty.
            bool allHaveEmails = employees.All(e => !string.IsNullOrWhiteSpace(e.Email));

            // Goal 3: Check if the collection contains a specific skill list or reference.
            // (Here demonstrating basic Any existence check on the whole collection)
            bool hasRecords = employees.Any();

            Console.WriteLine($"Has at least one high earner (> $200k) : {hasHighEarners}");
            Console.WriteLine($"All employees have valid emails        : {allHaveEmails}");
            Console.WriteLine($"Repository has any records at all      : {hasRecords}");

        }
    }
}