#include <iostream>
using namespace std;

// Create a node
class Node
{
public:
    int value;
    Node* next;
};

void InsertAtEnd(Node*& head, int Value) {

    Node* new_node = new Node();

    new_node->value = Value;
    new_node->next = NULL;

    if (head == NULL) {
        head = new_node;
        return;
    }

    Node* LastNode = head;
    while (LastNode->next != NULL)
    {
        LastNode = LastNode->next;
    }

    LastNode->next = new_node;
    return;
}


// Delete Last Node in Linked List (Based on the provided function logic)
// =================================================================

// Suppose the list is: Head → [1] → [2] → [3] → NULL
// Goal: delete the last node [3]

// Initial Setup:
// Node* Current = head; // Current starts at [1]
// Node* Prev = head;    // Prev also starts at [1]
// -----------------------------------------------------------------

// Step 1: Check if list is empty (head == NULL)
// if (head == NULL) return; // If true, the list is empty, nothing to do.
// -----------------------------------------------------------------

// Step 2: Handle special case - only one node exists
// if (Current->next == NULL) // If [1]->next is NULL, then [1] is the only node.
// {
//     head = NULL;        // Set Head to NULL.
//     delete Current;     // Delete the single node [1].
//     return;
// }
// -----------------------------------------------------------------

// Step 3: Traverse to find the second-to-last (Prev) and last (Current) nodes
// We use two pointers: Prev tracks the node before Current.
// while (Current != NULL && Current->next != NULL)
// {
//     Prev = Current;         // Prev moves to the current node (e.g., from [1] to [2]).
//     Current = Current->next; // Current moves to the next node (e.g., from [2] to [3]).
// }
// The loop stops when Current is at [3] and Current->next is NULL.
// Now: Prev points to node [2], and Current points to node [3].
// -----------------------------------------------------------------

// Step 4: Remove the node (Break the link)
// Prev->next = NULL; // Make node [2] point to NULL instead of [3]. The link is broken.
// -----------------------------------------------------------------

// Step 5: Delete the last node from memory
// delete Current; // Delete node [3] (which Current is pointing to).

void DeleteLastNode(Node*& head)
{
    Node* Current = head, * Prev = head;

    if (head == NULL)
    {
        return;
    }

    if (Current->next == NULL) 
    {
        head = NULL;
        delete Current;//free from memory
        return;
    }

    // Find the key to be deleted
    while (Current != NULL && Current->next != NULL) 
    {
        Prev = Current;
        Current = Current->next;
    }

    // Remove the node
    Prev->next = NULL;
    delete Current;//free from memory
}



void PrintList(Node* head)

{
    cout << "\n";
    while (head != NULL)
    {
        cout << head->value << " ";
        head = head->next;
    }
}

int main()
{
    Node* head = NULL;

    InsertAtEnd(head, 1);
    InsertAtEnd(head, 2);
    InsertAtEnd(head, 3);
    InsertAtEnd(head, 4);
    InsertAtEnd(head, 5);
    InsertAtEnd(head, 6);
    PrintList(head);


    DeleteLastNode(head);


    PrintList(head);

    system("pause>0");

}