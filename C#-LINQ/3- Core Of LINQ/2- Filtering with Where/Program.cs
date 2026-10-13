using System.Collections.Generic;
using System.Linq;

namespace _2__Filtering_with_Where;

class Program
{
    // This shows the basic usage of the LINQ Where method.
    // However, LINQ queries do not execute the moment you write them. 
    // In the next lesson, we will explore execution timing and mechanics: Deferred vs. Immediate Execution.
    
    static void Main(string[] args)
    {
        var employees = Repository.LoadEmployees();

        // 1. Query definition using our custom extension method
        IEnumerable<Employee> resultCustom = employees
            .Filter(e => e.Gender == "female" && e.FirstName.ToLowerInvariant().StartsWith("s"));

        // 2. Query definition using LINQ's built-in Where
        // Key concept: The query is defined and assigned, but NOT executed yet
        IEnumerable<Employee> resultLinq = employees
            .Where(e => e.Gender == "female" && e.FirstName.ToLowerInvariant().StartsWith("s"));

        // 3. Execution triggers here when Print() enumerates the sequence
        resultCustom.Print("Females with Fname starts with S / using Filter method");
        resultLinq.Print("Females with Fname starts with S / using LINQ Where method");
    }
}