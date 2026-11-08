/*
 * ============================================================================
 * LESSON: WORKING WITH A LIST OF CUSTOM OBJECTS IN C#
 * ============================================================================
 * 
 * 1. LISTS AS REFERENCE CONTAINERS
 * --------------------------------
 * When storing custom class instances (reference types) in List<T>:
 * - The list stores references (heap memory addresses), not the object bodies.
 * - Iteration, searching, and filtering evaluate object properties via lambda expressions.
 * 
 * 
 * 2. SEARCH & FILTER BEHAVIORS FOR REFERENCE TYPES
 * ------------------------------------------------
 * - Find(predicate) vs. FirstOrDefault(predicate):
 *   * Both return the first matching object, scanning from left to right.
 *   * If no item matches, both return default(T), which is null for reference types.
 *   * Find is a built-in method on List<T>; FirstOrDefault is a LINQ extension method 
 *     available on all IEnumerable<T> types.
 *   * Always perform a null-check on the result before accessing object properties 
 *     to prevent a NullReferenceException.
 * 
 * - FindAll(predicate):
 *   * Returns a new List<T> containing references to every element satisfying the predicate.
 * 
 * - RemoveAll(predicate):
 *   * Performs an in-place removal of all objects matching the condition in a single 
 *     O(N) pass, shifting the remaining elements left.
 */

namespace _10__Working_with_a_List_of_Custom_Objects;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>()
        {
            new Person("Ali", 21),
            new Person("Yasser", 22),
            new Person("Waleed", 28),
            new Person("Ahmed", 16),
            new Person("Mohammed", 33),
            new Person("Nasser", 30),
            new Person("Nora", 40),
            new Person("Fahad", 20)
        };
        
        // Iterating over the list using List<T>.ForEach:
        people.ForEach(person => Console.WriteLine($"Name: {person.Name}, Age: {person.Age}"));
        
        // Using built-in Find:
        // Returns default (null) if no match is found
        Person ali = people.Find(person => person.Name == "Ali");
        if (ali != null)
            Console.WriteLine($"\n\nFind Ali:  Name: {ali.Name}, Age: {ali.Age}");
        
        // Using LINQ FirstOrDefault:
        // Returns first matching object, or default (null) if not found
        Person minor = people.FirstOrDefault(person => person.Age <= 18);
        if (minor != null)
            Console.WriteLine($"FirstOrDefault:  Name: {minor.Name}, Age: {minor.Age}");

        // Using FindAll to filter people over 30 into a new List<Person>:
        List<Person> peopleOver30 = people.FindAll(person => person.Age > 30);
        Console.WriteLine("\n\nPeople over 30:");
        foreach (Person person in peopleOver30)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }

        // Using LINQ Any to check if any element meets the condition:
        bool containsOver40 = people.Any(p => p.Age >= 40);
        Console.WriteLine("\nAny over 40? " + containsOver40);
        
        // Using built-in Exists:
        bool containsYasser = people.Exists(p => p.Name == "Yasser");
        Console.WriteLine("\nDoes Yasser exist in the list? " + containsYasser);

        // In-place removal matching a predicate:
        Console.WriteLine("\nAfter removing all people under 30:");
        people.RemoveAll(person => person.Age < 30);
        
        foreach (Person person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}