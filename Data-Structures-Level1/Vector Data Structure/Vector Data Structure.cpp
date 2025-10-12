// no new info on vectors!

/*
Vector vs Stack (STL)
---------------------

VECTOR (built inside STL, it is a sequence container):
- Dynamic array (can grow/shrink).
- Can access ANY element by index (random access).
- Supports iteration (loops, begin/end).
- Functions: push_back, pop_back, insert, erase, operator[].
- Pros: flexible, fast random access, good for storing sequences.
- Cons: inserting/removing in the middle is costly (O(n)).

STACK (built inside STL, it is a container adapter(built on another container)):
- Container adapter (usually built on vector or deque).
- Strict LIFO (Last In, First Out).
- Access ONLY the top element.
- Functions: push, pop, top, empty, size.
- Pros: perfect for problems needing "last in first out" (undo ops, recursion simulation, parsing).
- Cons: no random access, limited functionality, only top is visible.

WHEN TO USE:
- Use VECTOR if you need random access or to traverse/modify a sequence.
- Use STACK if you only care about pushing/popping in LIFO order.
*/
