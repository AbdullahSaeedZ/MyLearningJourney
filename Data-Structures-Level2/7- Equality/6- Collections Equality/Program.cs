/*
================================================================================
LESSON 06: Collections & Equality (Where This Hits Your Code)
================================================================================

1. THE PROBLEM:
You put a custom object into a `List<T>`, create a brand-new object with the 
exact same data, and call `list.Contains(newObject)`. Even though the data matches 
100%, it returns FALSE! Why?

2. THE CORE IDEA (Built-in vs. Custom Search Mechanisms):
Different collection methods handle equality in completely different ways:
- Method 1 (`List<T>.Contains()`): Relies on `EqualityComparer<T>.Default`, which 
  behind the scenes calls your class's `GetHashCode()` and `.Equals()` methods.
- Methods 2 & 3 (`List<T>.Exists()` and LINQ `.Any()`): Completely bypass your 
  equality methods by asking you to supply a custom lambda expression (predicate).

   COLLECTION SEARCH FLOW:
   
   A) list.Contains(target)  ---> Uses GetHashCode() & .Equals() (Needs Lessons 02 & 03!)
   
   B) list.Exists(x => ...)  ---> Evaluates your custom lambda condition directly
   
   C) list.Any(x => ...)     ---> Evaluates your custom lambda condition directly

3. HOW IT WORKS INTERNALLY:
When you call `Contains()`, the list does not loop through items using `==`. 
Instead, it asks the default comparer:
1. Do their hash codes match? (Using `GetHashCode()` from Lesson 02)
2. Do their values match? (Using `.Equals()` from Lesson 02)
If you never overrode `Equals()` and `GetHashCode()`, `Contains()` defaults back to 
checking memory addresses, causing identical data searches to fail.

4. PITFALL:
- Assuming LINQ methods like `.Any()` require you to override `.Equals()`. 
  Because `.Any()` evaluates a custom lambda expression (`p => p.Name == "Ahmed"`), 
  it works even if your class has zero custom equality logic written into it.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLessons;

public class Person
{
    public string Name { get; set; }

    // From Lesson 02: Value Equality for .Equals()
    public override bool Equals(object? obj) => obj is Person other && Name == other.Name;
    public override int GetHashCode() => Name?.GetHashCode() ?? 0;
}

class Lesson06_CollectionsEquality
{
    static void Main()
    {
        // Populate a List with one Person object
        List<Person> people = new List<Person>
        {
            new Person { Name = "Ahmed" }
        };

        // Create a completely separate object in memory with identical data
        Person searchPerson = new Person { Name = "Ahmed" };

        Console.WriteLine("=== 1. Contains() Uses .Equals() & GetHashCode() ===");
        // Returns True BECAUSE we overrode Equals() and GetHashCode() in Lessons 02!
        // (If we hadn't overridden them, this would return False).
        Console.WriteLine($"people.Contains(searchPerson) : {people.Contains(searchPerson)}");


        Console.WriteLine("\n=== 2. Exists() and LINQ Any() Use Custom Predicates ===");
        // These methods don't care about .Equals()—they evaluate your lambda expression directly
        bool existsResult = people.Exists(p => p.Name == "Ahmed");
        bool anyResult = people.Any(p => p.Name == "Ahmed");

        Console.WriteLine($"people.Exists(...)            : {existsResult}"); // True
        Console.WriteLine($"people.Any(...)               : {anyResult}");    // True
    }
}