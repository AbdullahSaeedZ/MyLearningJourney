#include <iostream>
using namespace std;


class node
{
public:
    
    int value;
    node* next;
};

void InsertAtBeginning(node*& head, int value)
{

    // Allocate memory to a new node
    node* new_node = new node();


    new_node->value = value;  // insert the data of new node
    new_node->next = head;  // the new node will point to address of old node (which is saved in head). (first it was null, cuz head was = null)


    head = new_node;   // now after we made the new node point to the old node in the linked list, we make the head point to the new node added.

}

// Print the linked list
void PrintList(node * head)

{
    while (head != NULL) {
        cout << head->value << " ";
        head = head->next;
    }
}

node* Find(node* head, int valueToFind)  // node * Find , to return pointer variable;
{
    while (head != NULL)
    {
        if (head->value = valueToFind)
            return head;

        head = head->next;
    }
    
    return NULL;
}


int main()
{
   

    node* head = NULL;

    InsertAtBeginning(head, 1); 
    InsertAtBeginning(head, 2); 
    InsertAtBeginning(head, 3); 
    InsertAtBeginning(head, 4); 
    InsertAtBeginning(head, 5); 

    PrintList(head);

    node* N1 = Find(head, 4);

    if (N1 != NULL)
        cout << "\nnode found" << endl;
    else
        cout << "\nnode was not found" << endl;

    return 0;
}

