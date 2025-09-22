/*
Linked List 
What is it ?
A linear data structure where elements(nodes) are connected through pointers
Each node contains two parts : data and a pointer to the next node

How it works :

Visual Structure:
HEAD -> [DATA|NEXT] -> [DATA|NEXT] -> [DATA|NEXT] -> NULL

Example:
HEAD -> [  5  | •] -> [ 10  | •] -> [ 15  | •] -> NULL
        Node 1       Node 2        Node 3

The first node is called "Head" - your entry point to the list
Each node points to the next one in sequence
The last node points to "null" indicating the end.
To access any element, you start from head and follow the pointers


Key characteristics :
Dynamic size - can grow / shrink during runtime
Elements are not stored in contiguous(ورا بعض) memory locations
No direct access to elements by index(unlike arrays)
Efficient insertion / deletion at the beginning

Main advantage :

Memory efficient - allocates space as needed
Easy insertion / deletion operations

Main disadvantage :

No random access - must traverse from beginning to reach
*/