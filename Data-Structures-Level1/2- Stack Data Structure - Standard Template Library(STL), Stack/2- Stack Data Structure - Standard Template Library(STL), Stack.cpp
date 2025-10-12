#include <iostream>
#include <stack> // include stack
using namespace std;

/*
STL (Standard Template Library) in C++:
--------------------------------------
- Ready-made library in C++ with data structures + algorithms.

Main Components:
1. Containers (store data):
   - Sequence: vector, deque, list
   - Associative: set, map
   - Unordered: unordered_set, unordered_map
   - Adapters: stack (LIFO), queue (FIFO), priority_queue

2. Algorithms (operations on containers):
   - sort, find, count, reverse, binary_search, etc.

3. Iterators (like smart pointers):
   - Used to traverse containers (begin, end, rbegin, rend).

Why use STL?
- Saves time (no need to reinvent data structures/algorithms).
- High performance (optimized, tested).
- Flexible (works with any data type via templates).
*/

// stack uses LIFO(Last In, First Out) ,it is like the gun bullets , you can use the top bullet (item) then shoot (pop) to use the other bullet.


int main()
{
    // create a stack of ints
    stack <int> stkNumbers;  // class template

    // push into stack
    stkNumbers.push(10);
    stkNumbers.push(20);
    stkNumbers.push(30);
    stkNumbers.push(40);
    stkNumbers.push(50);

    // we can access the element by getting the top and popping (cant access using index or whatever)
    // until the stack is empty
    cout << "count=" << stkNumbers.size() << endl;


    cout << "Numbers are:\n";

    while (!stkNumbers.empty()) {
        // print top element
        cout << stkNumbers.top() << "\n";

        // pop top element from stack to show another top item in next loop
        stkNumbers.pop();
    }

    

    system("pause>0");
    return 0;
}