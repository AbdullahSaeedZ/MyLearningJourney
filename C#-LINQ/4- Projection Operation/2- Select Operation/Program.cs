/*
================================================================================
LESSON 1: THE .Select() OPERATOR (1-to-1 PROJECTION)
================================================================================

1. WHAT IT IS (THE THEORY)
--------------------------------------------------------------------------------
`.Select()` is LINQ's primary projection operator. It maps every element of an 
input sequence to a new output element using a transformation function (selector).

Key Invariants:
- 1-to-1 Mapping: If N elements go into the pipeline, exactly N elements come out.
- Non-Mutating: It does not alter the original objects; it instantiates new 
  values or shapes derived from them.
- Deferred Execution: No work happens when `.Select()` is declared. It returns an 
  internal iterator (e.g., `SelectEnumerableIterator`) that yields transformed items 
  one by one only as they are pulled via enumeration (`foreach`, `.ToList()`).

Diagram:
  Source:     [ Item A ]       [ Item B ]       [ Item C ]
                  |                |                |
  Operation:  .Select()        .Select()        .Select()
                  |                |                |
  Output:     [ Form A ]       [ Form B ]       [ Form C ]
================================================================================
*/

namespace _2__Select_Operation;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal MonthlySalary { get; set; }
}

public class EmployeeDto
{
    public string FullName { get; set; }
    public decimal AnnualSalary { get; set; }
}

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 101, FirstName = "Sami", LastName = "Ali", MonthlySalary = 6000m },
            new Employee { Id = 102, FirstName = "Sara", LastName = "Omar", MonthlySalary = 4500m }
        };

        // ---------------------------------------------------------------------
        // OVERLOAD 1: Standard Element Projection .Select(x => ...)
        // ---------------------------------------------------------------------

        // Shape A: Scalar / Primitive (Extracting a string or calculated value)
        IEnumerable<string> firstNames = employees.Select(e => e.FirstName);
        IEnumerable<decimal> yearlyTaxes = employees.Select(e => (e.MonthlySalary * 12) * 0.10m);

        // Shape B: Custom DTO (Strongly typed, safe to pass across API boundaries)
        IEnumerable<EmployeeDto> dtos = employees.Select(e => new EmployeeDto
        {
            FullName = $"{e.FirstName} {e.LastName}",
            AnnualSalary = e.MonthlySalary * 12
        });

        // Shape C: Anonymous Type (Temporary shape inside this method scope)
        var summaries = employees.Select(e => new
        {
            e.Id,
            DisplayName = $"{e.LastName}, {e.FirstName}",
            IsHighEarner = e.MonthlySalary > 5000m
        });

        // ---------------------------------------------------------------------
        // OVERLOAD 2: Indexed Projection .Select((x, index) => ...)
        // Provides the 0-based index of each item without a manual counter loop.
        // ---------------------------------------------------------------------
        var indexedRows = employees.Select((e, index) => new
        {
            RowNumber = index + 1, // example of how we can use this numbering feature (indexing)
            e.FirstName,
            e.MonthlySalary
        });

        // Enumeration Trigger
        foreach (var row in indexedRows)
        {
            Console.WriteLine($"#{row.RowNumber}: {row.FirstName} earns {row.MonthlySalary:C}");
        }
    }
}

/*
--------------------------------------------------------------------------------
5. WHEN NOT TO USE & COMMON PITFALLS
--------------------------------------------------------------------------------
- Flattening Mistake:
  Do NOT use `.Select()` if the property is a collection and you need a flat list.
  Example: `employees.Select(e => e.Skills)` yields `IEnumerable<List<string>>`.
  To unroll nested sequences, use `.SelectMany()` instead.

- Multiple Enumeration Overhead:
  Because `.Select()` is deferred, enumerating the query multiple times re-runs
  the transformation lambda for every item each time. Materialize with `.ToList()`
  or `.ToArray()` if the transformed result will be read repeatedly.

- Heavy Side Effects:
  Never execute database calls, file I/O, or state modifications inside the
  `.Select()` lambda. It is designed solely for pure data transformation.
*/