using System;
using System.Collections.Generic;
using System.Linq;

namespace _4__Method_Syntax_vs_Query_Syntax;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // 1. METHOD SYNTAX (Fluent Syntax / Extension Method Syntax)
        // =====================================================================
        // - Uses standard C# extension methods on IEnumerable<T> from System.Linq.
        // - Relies on lambda expressions to define logic (e.g., e => e % 2 == 0).
        // - Covers the full set of LINQ operators (some operators like Take, Skip,
        //   and Distinct exist ONLY in Method Syntax).
        Console.WriteLine("Method Syntax");
        var evenNumberMethod = numbers.Where(e => e % 2 == 0);
        foreach (var num in evenNumberMethod)
        {
            Console.Write(num + " ");
        }

        // 2. QUERY SYNTAX (Query Expression Syntax)
        // =====================================================================
        // - Looks declarative and familiar to developers coming from SQL.
        // - Starts with the 'from' clause and must end with 'select' or 'group'.
        // - Purely syntactic sugar: The C# compiler lowers (translates) this
        //   directly into Method Syntax calls before generating IL code.
        // - Best suited for complex multi-table joins or queries with multiple
        //   'from' (SelectMany) clauses for better readability.
        Console.WriteLine("\nQuery Syntax");
        var evenNumberQuery =
            from n in numbers
            where n % 2 == 0
            select n;

        foreach (var num in evenNumberQuery)
        {
            Console.Write(num + " ");
        }

        // Note: Both syntaxes produce identical IL instructions and performance;
        // choose based on team consistency and readability.
    }
}