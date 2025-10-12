#include <iostream>
using namespace std;

// this is inserting new nodes in the beginning of the list:
// 
// those are the steps , first we have an empty list with empty head:
// head->NULL

// then we create new node to point to the empty head (head points to null) , then we update the head to make it point to the new head:
//   head
//    |
//    v
//  [1 | NULL]   points to null cuz its the last node and did that by pointing to head which was null, then updated head to point to node1.



// then we add another node to the list, we point the new node to the head (head points to Node1) this way we connect node2 with node1, then we update head to point to the newest node (node2)
//   head
//    |
//    v
//   [2 |Next] ->[1 | NULL]




// Create a node
class Node
{
public:
    int value;
    Node* next;
};

void InsertAtBeginning(Node*& head, int value)
{

    // Allocate memory to a new node
    Node* new_node = new Node();

    
    new_node->value = value;  // insert the data of new node
    new_node->next = head;  // the new node will point to address of old node (which is saved in head). (first it was null, cuz head was = null)

    
    head = new_node;   // now after we made the new node point to the old node in the linked list, we make the head point to the new node added.

}

// Print the linked list
void PrintList(Node* head)

{
    while (head != NULL) {
        cout << head->value << " ";
        head = head->next;
    }
}

int main()
{
    Node* head = NULL;

    InsertAtBeginning(head, 1); // head = null, became: (Node1)head->value=1 , (Node1)head->next= null.
    InsertAtBeginning(head, 2); //              became: (Node2)head->value=2 , (Node2)head->next= (Node1).
    InsertAtBeginning(head, 3); //              became: (Node3)head->value=3 , (Node3)head->next= (Node2).
    InsertAtBeginning(head, 4); //              became: (Node4)head->value=4 , (Node4)head->next= (Node3).
    InsertAtBeginning(head, 5); //              became: (Node5)head->value=5 , (Node5)head->next= (Node4).

    // all of above functions have created nodes in the memory, we access them through head->next which saves the address of old node, and this old node->next has the older node and so on till we reach null (end of list)
    PrintList(head);




    // consider deleteing nodes after finishing
    system("pause>0");

    return 0;

}