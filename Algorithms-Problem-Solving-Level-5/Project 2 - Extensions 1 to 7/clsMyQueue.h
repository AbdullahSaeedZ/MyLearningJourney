#pragma once

#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;


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


	T GetItemValueByIndex(int Index)
	{
		return _MyList.GetNodeValueByIndex(Index);
	}

	void Reverse()
	{
		_MyList.Reverse();
	}

	void UpdateItemValueByIndex(int Index, const T& NewValue)
	{
		_MyList.UpdateNodeValueByIndex(Index, NewValue);
	}

	void InsertItemAfterIndex(int Index, const T& Value)
	{
		_MyList.InsertAfter(Index, Value);
	}

	void InsertItemAtFront(const T& Value)
	{
		_MyList.InsertAtBeginning(Value);
	}

	void InsertItemAtBack(const T& Value)
	{
		_MyList.InsertAtEnd(Value);
	}

	void Clear()
	{
		_MyList.Clear();
	}






};

