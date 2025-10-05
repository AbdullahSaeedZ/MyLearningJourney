#pragma once

#include <iostream>
#include "clsDynamicArray.h"
using namespace std;

template <class T>
class clsQueueArr
{
protected:

	clsDynamicArray<T> _MyArray;

public:


	void Push(const T& Item)
	{
		_MyArray.InsertAtBeginning(Item);
	}

	void Pop()
	{
		_MyArray.DeleteItemAtEnd();
	}

	int Size()
	{
		return _MyArray.Size();
	}

	bool IsEmpty()
	{
		return _MyArray.IsEmpty();
	}

	T Front()
	{
		return _MyArray.GetItemValueByIndex(_MyArray.Size() - 1);
	}

	T Back()
	{
		return _MyArray.GetItemValueByIndex(0);
	}

	void PrintList()
	{
		_MyArray.PrintItems();
	}

	void UpdateItemByIndex(int Index, const T& Item)
	{
		_MyArray.SetItem(Index, Item);
	}

	void InsertAtFront(const T& Item)
	{
		_MyArray.InsertAtEnd(Item);
	}

	void InsertAtBack(const T& Item)
	{
		_MyArray.InsertAtBeginning(Item);
	}

	void InsertAfter(int Index, const T& Item)
	{
		_MyArray.InsertAfterIndex(Index, Item);
	}

	void Reverse()
	{
		_MyArray.Reverse();
	}

	T GetItemByIndex(int Index)
	{
		return _MyArray.GetItemValueByIndex(Index);
	}

	void Clear()
	{
		_MyArray.Clear();
	}
};

