/*
================================================================================
LESSON 2: THE .SelectMany() OPERATOR (1-to-MANY FLATTENING)
================================================================================
Definition (Microsoft .NET Docs):
   "Projects each element of a sequence to an IEnumerable<T> and flattens the 
   resulting sequences into one sequence."
   
   In Plain English:
   - What is a "sequence"? 
     In C#, a sequence is simply any collection you can loop over using `foreach` 
     (an array, a `List<T>`, or an `IEnumerable<T>`).
   
   The Problem:
   If you have an `Employee` object that contains a child collection like 
   `Skills` (`List<string>`), using `.Select(e => e.Skills)` keeps the boxes closed:
   it returns a collection of lists (`IEnumerable<List<string>>`), leaving you 
   with a list inside a list.
   
   The Solution:
   `.SelectMany(e => e.Skills)` opens every employee's `Skills` list and dumps all 
   individual skill strings into one single, flat stream (`IEnumerable<string>`).
   
   Cardinality: N Employees In -> M Flattened Skills Out.
   
   Diagram:
     Source:         [ Emp 1: {"C#", "SQL"} ]      [ Emp 2: {"Linux"} ]
                                \                         /
     Operation:                  \---- .SelectMany() ----/
                                            |
     Flattened:              [ "C#",     "SQL",     "Linux" ]
     
     
2. THE TWO PRIMARY OVERLOADS
--------------------------------------------------------------------------------
Overload 1 (Simple Flattening):
    source.SelectMany(parent => parent.ChildrenCollection)
    * Dumps all child items into one flat sequence (discards parent context).

Overload 2 (Parent-Child Correlation with resultSelector):
    source.SelectMany(
        parent => parent.ChildrenCollection,    <- first lambda
        (parent, child) => new { ... }          <- second lambda
    )
    * Flattens children while keeping the parent in scope to project both.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Skills { get; set; } = new();
}

public class OrderItem
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Sami", Skills = new List<string> { "C#", "SQL" } },
            new Employee { Id = 2, Name = "Sara", Skills = new List<string> { "Linux", "Docker", "C#" } },
            new Employee { Id = 3, Name = "Zaid", Skills = new List<string>() }
        };

        var orders = new List<Order>
        {
            new Order
            {
                OrderId = 1001,
                CustomerName = "Ali",
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Monitor", Price = 300m },
                    new OrderItem { ProductName = "Mouse", Price = 25m }
                }
            },
            new Order
            {
                OrderId = 1002,
                CustomerName = "Mona",
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Desk", Price = 150m }
                }
            }
        };

        // ---------------------------------------------------------------------
        // 1. Bare Flattening (Overload 1)
        // Mechanism: Iterates through each parent (Employee), unpacks every item 
        // from its inner collection (Skills), and dumps all items directly into 
        // a single, continuous output sequence (flattening them).
        // The parent object itself is consumed and discarded.
        // Result: "C#", "SQL", "Linux", "Docker", "C#"
        // ---------------------------------------------------------------------
        IEnumerable<string> allSkills = employees.SelectMany(e => e.Skills);

        // ---------------------------------------------------------------------
        // 2. Flattening + Distinct
        // Mechanism: First flattens the nested lists into one stream exactly like 
        // Form 1, then immediately filters out redundant duplicates using an 
        // internal hash set check via .Distinct().
        // Result: "C#", "SQL", "Linux", "Docker"
        // ---------------------------------------------------------------------
        IEnumerable<string> uniqueSkills = employees.SelectMany(e => e.Skills).Distinct();

        
        
        // ---------------------------------------------------------------------
        // 3. Parent-Child Correlation (Overload 2 with resultSelector) INNER JOIN IN SQL
        // 
        // GOAL:
        // Produce a flat, denormalized invoice table (like a SQL JOIN).
        // Instead of getting just items, every single item row must "remember" 
        // who bought it (CustomerName) and which receipt it belongs to (OrderId).
        // ---------------------------------------------------------------------
        var orderRows = orders.SelectMany(

            // STEP 1: Collection Selector
            // Tells LINQ: "Look at each parent (order) and open its inner child list (Items)."
            // LINQ will loop through these items one by one.
            order => order.Items,

            // STEP 2: Result Selector
            // Runs ONCE FOR EVERY CHILD ITEM inside the collection opened above.
            // Parameters:
            //   - 'order': The current parent currently being inspected.
            //   - 'item' : The specific individual child currently pulled from that order's Items list.
            // Action:
            //   Stitch properties from BOTH into a brand-new combined shape.
            (order, item) => new
            {
                order.OrderId,       // From PARENT
                order.CustomerName,  // From PARENT
                item.ProductName,    // From CHILD
                item.Price           // From CHILD
            }
        );
        
        
        
        
        
        
        
        // Execution Trigger (Iteration forces the deferred queries to run)
        Console.WriteLine("--- 1. Bare Flattened Skills ---");
        foreach (var skill in allSkills)
        {
            Console.WriteLine(skill);
        }

        Console.WriteLine("\n--- 2. Unique Skills ---");
        foreach (var skill in uniqueSkills)
        {
            Console.WriteLine(skill);
        }

        Console.WriteLine("\n--- 3. Correlated Order Rows ---");
        foreach (var row in orderRows)
        {
            Console.WriteLine($"Order #{row.OrderId} ({row.CustomerName}) -> {row.ProductName} | {row.Price:C}");
        }
    }
}

/*
--------------------------------------------------------------------------------
3. PITFALLS
--------------------------------------------------------------------------------
- Null Reference Exception:
  If a parent's child collection is `null` instead of an empty list, 
  `.SelectMany()` throws a `NullReferenceException`. Keep lists initialized (`new()`).

- Discarding Parent Context:
  Avoid Overload 1 if downstream code still needs to know which parent 
  owned the flattened child. Use Overload 2 instead.
*/