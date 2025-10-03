#pragma once

#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;


 //will create the queue class by composition with the dbl linked list class we created.
 //meaning that we will include the dblList class here then instantiate an object of it to be used inside the queue class.
 //reason of not using inheritance is that we dont want to expose all methods of dbl list in the queue objects.

 //===============================
 //Queue Class Design Explanation
 //===============================

 //Why Composition and not Inheritance:
 //1- Queue "has-a" doubly linked list, it is not "is-a" list.
 //2- We want to hide unnecessary methods of the list like InsertAtStart or DeleteLastNode 
 //   that could break the FIFO behavior of a queue.
 //3- Composition gives full control over which methods are exposed to the user.

 //If we used Inheritance:
 //- Public Inheritance: all list methods become accessible to the user → can break FIFO rules.
 //- Private Inheritance: methods are hidden from the user, but the queue still inherits all list functionality internally → less clear, harder to maintain.
 //Therefore, composition is cleaner and more explicit.

 //===============================
 //Summary of is-a vs has-a Relationships
 //===============================

 //1- is-a (Inheritance):
 //- Use when the new class "is a" type of another class.
 //- Example: Car is-a Vehicle → Car inherits basic features from Vehicle and adds its own.
 //- Strong coupling between classes, less flexible, harder to maintain.

 //2- has-a (Composition):
 //- Use when the new class "has a" or depends on an object of another class.
 //- Example: Queue has-a LinkedList → Queue uses a list internally to perform its operations.
 //- Example: Computer has-a Keyboard → Computer contains a Keyboard, but is not a Keyboard.
 //- More flexible, easier to maintain, easier code reuse without exposing all base class methods.

 //Golden Rule for deciding:
 //- Ask: "Is the new class a type of the other class?" → use is-a (inheritance)
 //- Ask: "Does the new class contain or depend on an object of the other class?" → use has-a (composition)

 //Note:
 //Sometimes both relationships could apply, but composition (has-a) is generally safer and more flexible.



template <class T>
class clsMyQueue
{
protected:
	
	clsDblLinkedList <T> _MyList;

public:

	void Push(T Item)
	{
		_MyList.InsertAtEnd(Item);
	}

	void Pop()
	{
		_MyList.DeleteFirstNode();
	}

	int Size()
	{
		return _MyList.Size();
	}

	bool IsEmpty()
	{
		return _MyList.IsEmpty();
	}

	T Front()
	{
		return _MyList.GetNodeValueByIndex(0);
	}

	T Back()
	{
		return _MyList.GetNodeValueByIndex(Size() - 1);
	}

	void PrintList()
	{
		_MyList.PrintList();
	}

};

