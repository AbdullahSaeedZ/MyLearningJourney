#include <iostream>
using namespace std;

// This is how memory is typically organized for programs at low level:
// Most languages work on top of this model, but only C++ gives us direct control and access to it.

// when mentioning memory, it is the RAM memory, and for the program it is divided into 4 segments:
// 
// 1- Code segment (Text): stores source code / instructions.  Takes a small, fixed portion of memory because it's only the program's executable code
// 
// 2- Data segment: stores static/global variables for the whole program lifetime.  This also takes a relatively small and fixed area in memory.
// 
// 3- the stack segment: stores local variables/functions/pointers. once program runs, the system will calculate size then use needed space in memory, and that size cant be changed
// so the pointers are used here as an escape from this situation to the last layer to access the whole memory and use more space.
// 
// 4- Heap segment: the remaining dynamically managed RAM space.
// Used for dynamic allocation of variables, objects, arrays, etc.
// The program can request and release memory as needed (e.g., using new/delete in C++).
// Example: if RAM is 16GB, the heap can grow to use as much of the available RAM as allowed by the OS.

// example: in stack layer there is a pointer stored, then next line of code we say pointer = new int; then this new int will be stored in the heap layer.
// Example:
// A pointer variable itself is stored in the stack.
// When you do: pointer = new int;
// The pointer value (address of new int stored in pointer) is in the stack, but the new int value is allocated in the heap.
// the delete will free the heap from that new allocation

int main()
{
    





    return 0;
}

