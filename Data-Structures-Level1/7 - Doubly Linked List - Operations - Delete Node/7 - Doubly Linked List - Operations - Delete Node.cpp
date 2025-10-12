#include <iostream>
using namespace std;

class Node
{
public:
    int value;
    Node* next;
    Node* prev;
};

void InsertAtBeginning(Node*& head, int value) {


    /*
        1-Create a new node with the desired value.
        2-Set the next pointer of the new node to the current head of the list.
        3-Set the previous pointer of the current head to the new node.
        4-Set the new node as the new head of the list.
    */

    Node* newNode = new Node();
    newNode->value = value;
    newNode->next = head;
    newNode->prev = NULL;

    if (head != NULL) {
        head->prev = newNode;
    }
    head = newNode;
}

Node* Find(Node* head, int Value)
{

    while (head != NULL) {

        if (head->value == Value)
            return head;


        head = head->next;
    }

    return NULL;


}

void DeleteNode(Node*& head, Node*& NodeToDelete) {


    /*
        1-Set the next pointer of the previous node to the next pointer of the current node.
        2-Set the previous pointer of the next node to the previous pointer of the current node.
        3-Delete the current node.
    */
    if (head == NULL || NodeToDelete == NULL)  
    {
        return;
    }
    if (head == NodeToDelete)  // if it is the only node available
    {
        head = NodeToDelete->next; // will be head = null;
    }
    if (NodeToDelete->next != NULL) // if not last node
    {
        NodeToDelete->next->prev = NodeToDelete->prev;   
    }
    if (NodeToDelete->prev != NULL) // if not first node 
    {
        NodeToDelete->prev->next = NodeToDelete->next;
    }
    delete NodeToDelete;
}

void PrintNodeDetails(Node* head)
{

    if (head->prev != NULL)
        cout << head->prev->value;
    else
        cout << "NULL";

    cout << " <--> " << head->value << " <--> ";

    if (head->next != NULL)
        cout << head->next->value << "\n";
    else
        cout << "NULL";

}

// Print the linked list
void PrintListDetails(Node* head)

{
    cout << "\n\n";
    while (head != NULL) {
        PrintNodeDetails(head);
        head = head->next;
    }
}


// Print the linked list
void PrintList(Node* head)

{
    cout << "NULL <--> ";
    while (head != NULL) {
        cout << head->value << " <--> ";
        head = head->next;
    }
    cout << "NULL";

}

int main()
{
    Node* head = NULL;

    InsertAtBeginning(head, 5);
    InsertAtBeginning(head, 4);
    InsertAtBeginning(head, 3);
    InsertAtBeginning(head, 2);
    InsertAtBeginning(head, 1);

    cout << "\nLinked List Contenet:\n";
    PrintList(head);
    PrintListDetails(head);

    //Traverse the list to find the node to be deleted.
    Node* N1 = Find(head, 4);

    DeleteNode(head, N1);

    cout << "\n\n\nLinked List Contenet after delete:\n";
    PrintList(head);
    PrintListDetails(head);
    system("pause>0");

}