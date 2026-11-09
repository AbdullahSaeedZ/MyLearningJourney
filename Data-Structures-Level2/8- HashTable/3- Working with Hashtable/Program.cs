namespace _3__Working_with_Hashtable;

using System;
using System.Collections;


class Program
{
    static void Main()
    {
        // Initialization
        Hashtable myHashtable = new Hashtable();
        
        // Adding pairs, keys must be unique
        // Any value types will involve boxing 
        myHashtable.Add("key1", "value1");
        myHashtable.Add("key2", "value2");
        myHashtable.Add("key3", "value3");

        // Accessing an element
        Console.WriteLine($"Accessing key1: {myHashtable["key1"]}");

        // Modifying an element
        myHashtable["key1"] = "newValue1";

        // Removing an element
        myHashtable.Remove("key2");

        // Iterating over elements
        Console.WriteLine("\nCurrent Hashtable contents:");
        
        // pairs are NOT ordered in hashtables
        foreach (DictionaryEntry entry in myHashtable)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }

    }
}
