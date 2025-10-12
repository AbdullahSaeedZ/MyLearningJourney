 ================== Classification of Data Structures ==================

 Data Structures are broadly classified into two main categories:
 1. Primitive (Basic) Data Structures
 2. Non-Primitive (Advanced) Data Structures

 
 
 ------------------------------------------------------
 1) Primitive Data Structures
 ------------------------------------------------------
 - These are the fundamental/basic data types provided by the programming language.
 - Already implemented in the language (you don’t need to code them from scratch).
 - Examples:
    • int
    • float
    • char
    • pointer
 - Example: int x = 10;   // The language itself handles how this is stored in memory.

 
 
 ------------------------------------------------------
 2) Non-Primitive Data Structures
 ------------------------------------------------------
 - Built on top of primitive types.
 - Used to store and manage collections of data.
 - Examples: array, linked list, stack, queue, tree, graph.
 - Without primitive data types, non-primitive ones cannot exist.
 - Sub-classified into:
    a) Linear Data Structures
    b) Non-Linear Data Structures

 
 
 ------------------------------------------------------
 2a) Linear Data Structures
 ------------------------------------------------------
 - "Linear" means elements are arranged sequentially (like a line).
 - You can traverse them using a single loop.
 - Examples:
    • Array
    • Linked List
    • Stack
    • Queue

   Example structure:
      Root → Node1 → Node2 → Node3 → Node4

 
 
 ------------------------------------------------------
 2b) Non-Linear Data Structures
 ------------------------------------------------------
 - Elements are not arranged sequentially, but hierarchically or in a network.
 - Traversal often requires nested loops or recursion.
 - Examples:
    • Tree
    • Graph

   Example structure (Tree):
               A
           /   |   \
         B    C    D
        / \   |   / \
       E  F   G  H   I

 
 
 ------------------------------------------------------
 Non-Primitive Data Structures: Homogeneous vs Heterogeneous
 ------------------------------------------------------
 - Homogeneous Data Structures:
    • All elements are of the same data type.
    • Example: int arr[5] = {1, 2, 3, 4, 5};
 - Heterogeneous Data Structures:
    • Elements can be of different data types.
    • Example: a structure/class containing int, string, and float together.

 
 
 ------------------------------------------------------
 Static vs Dynamic Data Structures
 ------------------------------------------------------
 - Static Data Structures:
    • Fixed memory size.
    • Allocated at compile time (cant at run time).
    • Example: int arr[100];   // Array with fixed size.
 - Dynamic Data Structures:
    • Memory size can change at runtime.
    • size is not fixed.
    • Allocated and freed as needed.
    • Examples: Stack, Queue, Linked List.
    • Example:
          int length;
          int* ptr = new int[length];   // allocated at runtime
          delete[] ptr;                 // freed memory
 
 
 ------------------------------------------------------
 Operations On Data Structures
 ------------------------------------------------------
 - operations are :
    • Create
    • Update
    • Search
    • Select
    • Sorting
    • Merging
    • Destroy or delete
 
 
 ------------------------------------------------------
 Overall Structure (Tree Diagram):
 ------------------------------------------------------
 ================== Classification of Data Structures ==================

                                       Data Structure
                                             |
        ----------------------------------------------------------------------------
        |                                                                          |
   Primitive (Basic)                                                      Non-Primitive (Advanced)
        |                                                                          |
   -----------------------------                           ---------------------------------------------------------
   |            |           |   |                          |                                                      |
 Integer      Float       Char Pointer                 Linear Structures                                 Non-Linear Structures
                                                           |                                                      |
                                                 -------------------------                               -----------------------
                                                 |                       |                               |                     |
                                          Static Structures      Dynamic Structures                     Tree                  Graph
                                                 |                       |
                                               Array         -------------------------------
                                                             |             |               |
                                                           Stack         Queue        Linked List
                                                             |
                                                           Vector

    Extra classification:
    ---------------------
    • Homogeneous (same type elements)
         Example: int arr[5] = {1,2,3,4,5};
    • Heterogeneous (different type elements)
         Example: struct { int id; string name; float gpa; };




 ------------------------------------------------------
 NOTES:
 ------------------------------------------------------

 1) Primitive Data Structures:
    - Built-in, basic data types provided by language.
    - Examples: int, float, char, pointer.

 2) Non-Primitive Data Structures:
    - Built on top of primitives.
    - Divided into Linear & Non-Linear.

 3) Linear Structures:
    - Sequential (line by line).
    - Examples: Array, Stack, Queue, Linked List.
    - Further divided into:
        a) Static (fixed size, e.g., Array).
        b) Dynamic (size changes at runtime, e.g., Linked List, Stack, Queue).

 4) Non-Linear Structures:
    - Non-sequential, hierarchical or networked.
    - Examples: Tree, Graph.

 5) Homogeneous vs Heterogeneous:
    - Homogeneous: same data type (e.g., array of int).
    - Heterogeneous: different data types (e.g., struct with int, float, string).

 ------------------------------------------------------
