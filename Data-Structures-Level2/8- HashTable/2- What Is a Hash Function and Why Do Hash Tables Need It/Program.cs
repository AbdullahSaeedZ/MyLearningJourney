
/*
================================================================================
LESSON 09: What Is a Hash Function & Why Do Hash Tables Need It?
================================================================================

1. THE PROBLEM:

Arrays use integer indexes to access elements:

    array[0] -> "555-123-4251"
    array[1] -> "555-987-6543"

But what if we want to store data using String keys?

    "James" -> "555-123-4251"
    "Sarah" -> "555-987-6543"

An array cannot directly use "James" as its physical index.

We need a way to convert a String key into an integer index.

THAT IS WHY WE USE A HASH FUNCTION!


================================================================================
2. WHAT DOES A HASH FUNCTION DO?
================================================================================

A HASH FUNCTION takes a key (String, Object, etc.) and
converts it into an integer called a HASH CODE.

Example:

    hash("James") -> 105

But 105 might be larger than our array's size.

So the Hash Table uses the MODULO (%) operator to
calculate a valid array index.

    105 % 10 = 5

Now we have a valid index!

THE COMPLETE PROCESS:

       KEY
    "James"
       |
       v
    +----------------+
    |  HASH FUNCTION |
    +----------------+
       |
       v
    HASH CODE: 105
       |
       v
    +----------------+
    | MODULO (% 10)  |
    +----------------+
       |
       v
    ARRAY INDEX: 5
       |
       v
    +----------------+
    | STORAGE[5]     |
    | James -> Phone |
    +----------------+


================================================================================
3. HOW IS IT USED INSIDE A HASH TABLE?
================================================================================

Imagine a Hash Table with 10 buckets.

When inserting a key-value pair:

    put("James", "555-123-4251")

The Hash Table:

    1. Passes "James" to the hash function.
    2. Gets the hash code: 105.
    3. Calculates the index: 105 % 10 = 5.
    4. Stores the key-value pair at index 5.

When retrieving the value:

    get("James")

The Hash Table repeats the same process to calculate
index 5 and access the stored value directly.

    INSERTION                  RETRIEVAL

     "James"                    "James"
        |                          |
        v                          v
    Hash Function             Hash Function
        |                          |
        v                          v
       105                        105
        |                          |
        v                          v
     % 10                       % 10
        |                          |
        v                          v
    Index 5                    Index 5
        |                          |
        v                          v
     STORE                     RETRIEVE


================================================================================
4. IMPORTANT THING TO REMEMBER
================================================================================

A hash function does NOT guarantee a unique index.

Different keys can produce the same index. This is
called a COLLISION.

Hash Tables have techniques to handle collisions.

Also, hash functions used in Hash Tables are designed
for speed and good distribution, not encryption.


================================================================================
FINAL SUMMARY
================================================================================

A Hash Table needs a hash function because arrays use
integer indexes, while we want to access data using keys
such as Strings.

The hash function converts the key into an integer.
Modulo converts that integer into a valid array index.

    KEY -> HASH FUNCTION -> HASH CODE -> MODULO -> INDEX

This allows Hash Tables to achieve O(1) average-case
insertion, retrieval, and deletion.

*/
