/*
================================================================================
LESSON: LINQ EXECUTION MODES — DEFERRED VS. IMMEDIATE EXECUTION
================================================================================

1. THE PROBLEM & SQL ANALOGY
--------------------------------------------------------------------------------
In standard C#, calling a method executes immediately and allocates memory.
If chained operations always did this, each step would create unnecessary copies:
Filter Active -> Copy 1 -> Filter Salary -> Copy 2 -> Take 10 -> Copy 3.

LINQ solves this by separating query building from query running, exactly like SQL:
    
    // Phase 1: Preparation (No execution, no network round-trip)
    SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE Salary > 5000", conn);
    
    // Phase 2: Enumeration Trigger (Query actually runs here)
    SqlDataReader reader = cmd.ExecuteReader();

Key Rule: A LINQ query is NOT the results; it is the set of instructions to get them.
Execution occurs ONLY when enumeration is triggered.


2. THE TWO PHASES OF EXECUTION
--------------------------------------------------------------------------------
Phase 1: QUERY PREPARATION (Deferred)
- Methods: Where, Select, OrderBy, Take, Skip.
- What happens: Returns an IEnumerable<T> pipeline definition.
- Execution status: IDLE. Zero items evaluated.

Phase 2: ENUMERATION TRIGGER (Evaluation)
- Triggers: foreach, .ToList(), .ToArray(), .Count(), .First(), .Any().
- What happens: Pulls items through the pipeline, evaluating source state NOW.


3. EXECUTION FLOW & MEMORY LIFECYCLE
--------------------------------------------------------------------------------
DEFERRED EXECUTION (Query as an unexecuted recipe):
Timeline:
  T1: list = [1, 2]
  T2: q = list.Where(x => x > 1)   --> PREPARATION: Saves instructions only.
  T3: list.Add(3)                  --> Source list mutates to [1, 2, 3].
  T4: foreach (var x in q)         --> ENUMERATION TRIGGER: Pipeline runs at T4.

  Result: Yields [2, 3] because evaluation inspects the source state at T4.

--------------------------------------------------------------------------------
IMMEDIATE EXECUTION (Query materialized into a snapshot):
Timeline:
  T1: list = [1, 2]
  T2: q = list.Where(...).ToList() --> PREPARATION + INSTANT ENUMERATION.
                                       Runs immediately; allocates new List in RAM.
  T3: list.Add(3)                  --> Modifies original list; snapshot is untouched.
  T4: foreach (var x in q)         --> Reads cached snapshot created at T2.

  Result: Yields [2]. Ignores '3' because enumeration happened at T2.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
}

public class Program
{
    public static void Main()
    {
        DemonstrateDeferredExecution();
        Console.WriteLine(new string('-', 50));
        DemonstrateImmediateExecution();
    }

    // METHOD 1: Deferred Execution
    public static void DemonstrateDeferredExecution()
    {
        Console.WriteLine("[DEMO 1: Deferred Execution]");

        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Sami", Salary = 6000 },
            new Employee { Id = 2, Name = "Sara", Salary = 4000 }
        };

        // Phase 1: Query Preparation (Like preparing a SQL command string)
        // No iteration or evaluation occurs here.
        // Breakpoint here: 'query' holds an internal 'WhereEnumerableIterator' object.
        // It is neither null nor an in-memory collection of filtered items; it simply
        // wraps the source list (employees list) and the predicate delegate, waiting for enumeration
        // (e.g., foreach, .ToList()) to actually pull and evaluate items.
        IEnumerable<Employee> query = employees.Where(e => e.Salary > 5000);

        // State change occurs while the query pipeline is still dormant
        employees.Add(new Employee { Id = 3, Name = "Salma", Salary = 7000 });

        // Phase 2: Enumeration Trigger
        // foreach (enumeration) will execute the query at this moment and state, pulling items through the filter right now.
        Console.WriteLine("Executing query now via foreach:");
        foreach (var emp in query)
        {
            Console.WriteLine($" - {emp.Name} (Salary: {emp.Salary})");
        }
    }
    

    // METHOD 2: Immediate Execution
    public static void DemonstrateImmediateExecution()
    {
        Console.WriteLine("[DEMO 2: Immediate Execution]");

        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Sami", Salary = 6000 },
            new Employee { Id = 2, Name = "Sara", Salary = 4000 }
        };

        // Phase 1 & 2 combined:
        // .ToList() internally enumerates the pipeline right now and materializes 
        // the results into an independent List<Employee> in memory.
        List<Employee> staticResult = employees
            .Where(e => e.Salary > 5000)
            .ToList();

        // State change occurs AFTER the query has already materialized
        employees.Add(new Employee { Id = 3, Name = "Salma", Salary = 7000 });

        // Reading the static memory buffer; no LINQ pipeline runs here
        Console.WriteLine("Reading cached snapshot:");
        foreach (var emp in staticResult)
        {
            Console.WriteLine($" - {emp.Name} (Salary: {emp.Salary})");
        }
    }
}

/*
--------------------------------------------------------------------------------
4. PITFALLS & PRAGMATIC RULES
--------------------------------------------------------------------------------
- Pitfall: Accidental Multiple Enumeration
  Because deferred queries do not store results, iterating over them twice 
  executes the entire underlying pipeline twice:
      var query = employees.Where(e => HeavyDatabaseOrApiCall(e));
      if (query.Any())            // Execution 1: runs pipeline
      {
          foreach (var e in query) // Execution 2: re-runs pipeline from scratch!
          { ... }
      }

- Pragmatic Rule:
  * Keep queries deferred (IEnumerable<T>) while assembling logic, filters, or paging.
  * Materialize immediately (.ToList() / .ToArray()) when handing data to consumer 
    layers (UI, APIs, or when you need to read the same result set multiple times).
*/