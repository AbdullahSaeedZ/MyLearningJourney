#pragma once

#include <iostream>
using namespace std;

template <class T>
class clsDblLinkedList
{

protected:

	int _Size = 0;

public:

	class Node
	{
	public:
		T _Value;
		Node* Next;
		Node* Prev;
	};

	Node* Head = NULL;
	

	void InsertAtBeginning(T Value)
	{
		Node* New_Node = new Node();
		New_Node->_Value = Value;
		New_Node->Next = Head;
		New_Node->Prev = NULL;

		if (Head != NULL)
			Head->Prev = New_Node;


		Head = New_Node;
		++_Size;
	}

	void PrintList()
	{
		Node* Current = Head;

		while (Current != NULL)
		{
			cout << Current->_Value << " ";
			Current = Current->Next;
		}

	}

	Node* Find(T Value)
	{
		Node* Current = Head;

		while (Current != NULL)
		{
			if (Current->_Value == Value)
				return Current;

			Current = Current->Next;
		}

		return NULL;
	}

	void InsertAfter(Node* Current, T Value)
	{
		if (Current == NULL)
			return;

		Node* New_Node = new Node();
		New_Node->_Value = Value;
		New_Node->Next = Current->Next;
		New_Node->Prev = Current;

		if (Current->Next != NULL)
			Current->Next->Prev = New_Node;

		Current->Next = New_Node;
		++_Size;
	}

	void InsertAtEnd(T Value)
	{
		Node* New_Node = new Node();
		New_Node->_Value = Value;
		New_Node->Next = NULL;

		if (Head == NULL)
		{
			New_Node->Prev = NULL;
			Head = New_Node;
		}
		else
		{
			Node* Last_Node = Head;

			while (Last_Node->Next != NULL)
			{
				Last_Node = Last_Node->Next;
			}

			Last_Node->Next = New_Node;
			New_Node->Prev = Last_Node;
		}

		++_Size;
	}

	void DeleteNode(Node*& NodeToDelete)
	{
		if (NodeToDelete == NULL || Head == NULL)
			return;

		if (Head == NodeToDelete)
		{
			Head = Head->Next;
		}

		if (NodeToDelete->Next != NULL)
		{
			NodeToDelete->Next->Prev = NodeToDelete->Prev;
		}

		if (NodeToDelete->Prev != NULL)
		{
			NodeToDelete->Prev->Next = NodeToDelete->Next;
		}


		delete NodeToDelete;
		--_Size;
	}

	void DeleteFirstNode()
	{
		if (Head == NULL)
			return;

		Node* First_Node = Head;
		Head = Head->Next;

		if (Head != NULL)
			Head->Prev = NULL;

		delete First_Node;
		--_Size;
	}

	void DeleteLastNode()
	{
		if (Head == NULL)
			return;
	
		if (Head->Next == NULL)
		{
			delete Head;
			Head = NULL;
			--_Size;
			return;
		}

		Node* Last_Node = Head;
		while (Last_Node->Next != NULL)
		{
			Last_Node = Last_Node->Next;
		}

		Last_Node->Prev->Next = NULL;

		delete Last_Node;
		--_Size;
	}

	int Size()
	{
		return _Size;
	}

	bool IsEmpty()
	{
		return !_Size;
	}

	void Clear()
	{
		while (_Size > 0)
		{
			DeleteFirstNode();
		}
	}

	void Reverse()
	{
		if (Head == nullptr || Head->Next == nullptr)
			return;

		Node* Current = Head;
		Node* Temp = nullptr;

		while (Current != nullptr)
		{
			Temp = Current->Prev; // move the temp

			Current->Prev = Current->Next;
			Current->Next = Temp;

			Current = Current->Prev; // move the current
		}

		Head = Temp->Prev; // head now point to the last node which is first in the reversed list
	}

};

