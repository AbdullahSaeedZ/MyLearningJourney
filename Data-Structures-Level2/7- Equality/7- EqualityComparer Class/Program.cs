/*
================================================================================
LESSON 07: EqualityComparer<T> (External Comparison Logic)
================================================================================

1. THE PROBLEM:
What happens if you want to use a class written by someone else (where you cannot 
add or edit `Equals()` and `GetHashCode()`), or if you need to compare the same 
class using different rules in different places (e.g., sometimes comparing by ID, 
sometimes by Name)?

2. THE CORE IDEA (The Key Rule):
We customize how other classes are compared by writing the comparison logic inside 
a separate helper class (inheriting from `EqualityComparer<T>`), and then passing 
that helper into collections or methods that need it. 

   BUILT-IN EQUALITY                          EXTERNAL COMPARISON (Helper Class)
   +------------------------+                 +-----------------------------------------+
   | Person class owns      |                 | Product class has NO equality code.     |
   | Equals() & GetHashCode()|                 | ProductComparer helper class does it!   |
   +------------------------+                 +-----------------------------------------+

3. HOW IT WORKS INTERNALLY & COMMON USES:
When collections like `Dictionary<TKey, TValue>` or `HashSet<T>` are created, 
they look for an `IEqualityComparer<T>`. If you don't pass one, they default to 
`EqualityComparer<T>.Default` (which calls the object's internal `.Equals()` and 
`GetHashCode()`). 

Common Use Cases:
- External Classes: Comparing types from third-party libraries where you cannot modify source code.
- Multiple Rules: Having one collection compare `Product` by ID, and another compare `Product` by Name.
- Case-Insensitive Comparisons: Comparing strings ignoring case (e.g., `StringComparer.OrdinalIgnoreCase`).

4. PITFALL:
- Forgetting to keep `Equals` and `GetHashCode` perfectly synchronized inside your 
  custom comparer. If two objects return `true` for `Equals`, they MUST return the exact 
  same integer for `GetHashCode`, otherwise hash-based collections will corrupt data.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace EqualityLessons;

// Notice: Product has NO custom Equals or GetHashCode here!
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Custom External Equality Comparer (The Helper Class)
public class ProductComparer : EqualityComparer<Product>
{
    public override bool Equals(Product? x, Product? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        
        // Define our custom rule: Products are equal if their IDs match
        return x.Id == y.Id;
    }

    public override int GetHashCode(Product obj)
    {
        if (obj is null) return 0;
        
        // Hash code must be generated from the exact same property used in Equals
        return obj.Id.GetHashCode();
    }
}

class Lesson07_EqualityComparer
{
    static void Main()
    {
        Product p1 = new Product { Id = 1, Name = "Laptop" };
        Product p2 = new Product { Id = 1, Name = "Gaming Laptop" }; // Same ID, different name

        // =====================================================================
        // SCENARIO 1: Default Comparison (Fails because Product has no Equals override)
        // =====================================================================
        bool defaultResult = EqualityComparer<Product>.Default.Equals(p1, p2);
        Console.WriteLine($"Default Comparison (Memory Address): {defaultResult}"); // False

        // =====================================================================
        // SCENARIO 2: Using Our Custom EqualityComparer
        // =====================================================================
        ProductComparer customComparer = new ProductComparer();
        bool customResult = customComparer.Equals(p1, p2);
        Console.WriteLine($"Custom Comparer (Compares by ID)   : {customResult}");   // True


        // =====================================================================
        // SCENARIO 3: Passing the Comparer Directly into a HashSet
        // =====================================================================
        // We instruct the HashSet to use our custom helper class instead of defaults
        HashSet<Product> products = new HashSet<Product>(new ProductComparer());
        
        products.Add(p1);
        
        // Even though p2 is a new instance with a different name, 
        // the HashSet uses ProductComparer to recognize that ID 1 already exists!
        bool exists = products.Contains(p2);
        Console.WriteLine($"HashSet Contains p2 (via Comparer) : {exists}");        // True
    }
}