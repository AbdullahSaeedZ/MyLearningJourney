/*
================================================================================
IGrouping<TKey, TElement> — The Multi-Value Bucket
================================================================================

1. THE PROBLEM:
Standard key-value collections like `KeyValuePair<TKey, TValue>` or `Dictionary<TKey, TValue>` 
map one key to strictly ONE value slot. When partitioning data (e.g., categorizing 
records by department or category), a single key must associate with MULTIPLE items.

Without a dedicated contract, you are forced to pass around clunky, nested signatures:
    KeyValuePair<string, List<Employee>>

2. THE CORE IDEA (What IGrouping Actually Is):
`IGrouping<TKey, TElement>` is simply a list with a label:
- `.Key`: The single label on the bucket (e.g., Department name).
- The instance itself: An `IEnumerable<TElement>` containing all matching items.

Think of it as ONE single row inside a multi-value dictionary:
- `Dictionary<TKey, TValue>`      -> ONE slot per key ("HR" => "Issam")
- `IGrouping<TKey, TElement>`       -> MANY slots per key ("HR" => ["Issam", "Omar"])

3. WHY THE SIGNATURE IS IGrouping<TKey, TElement> (Not IEnumerable<TElement>):
The interface definition inherits from `IEnumerable<TElement>`:
    public interface IGrouping<out TKey, out TElement> : IEnumerable<TElement>
    {
        TKey Key { get; }
    }

- `TKey`: The type of the bucket's label.
- `TElement`: The type of ONE individual item inside the bucket.
- Because `IGrouping` inherits from `IEnumerable<TElement>`, the group ITSELF is 
  the collection. Just like `List<string>` holds multiple strings without being 
  named `List<List<string>>`, `IGrouping<string, string>` holds multiple strings.

4. THE DATA STRUCTURE IN MEMORY:
Methods like GroupBy will return IEnumerable<IGrouping<string, string>> (Collection of Groups)
│
├── [Group 1: IGrouping<string, string>]
│     ├── .Key = "Apple"
│     └── Enumerable Items: ["Apple", "Apple", "Apple", "Apple"]
│
└── [Group 2: IGrouping<string, string>]
      ├── .Key = "Banana"
      └── Enumerable Items: ["Banana", "Banana", "Banana"]

5. PITFALLS:
- Not a Dictionary: `IGrouping` does NOT support indexer lookups (you cannot write 
  `group["Apple"]`). It is an enumerable bucket produced by operators like `GroupBy()` 
  or `ToLookup()`.
- Read-Only Contract: `IGrouping` provides no `.Add()` or `.Remove()` methods; 
  it represents an immutable snapshot of grouped results.
================================================================================
*/

