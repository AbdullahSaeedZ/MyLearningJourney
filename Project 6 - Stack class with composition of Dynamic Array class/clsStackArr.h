#pragma once

#include <iostream>
#include "clsDynamicArray.h"
using namespace std;

template <class T>
class clsStackArr : public clsDynamicArray<T>
{

public:

	void Push(const T &Value)
	{
		clsDynamicArray<T>::InsertAtEnd(Value);
	}

	void Pop()
	{
		clsDynamicArray<T>::DeleteItemAtEnd();
	}

	T Top()
	{
		return clsDynamicArray<T>::GetItemValueByIndex(clsDynamicArray<T>::_Size - 1);
	}

	T Bottom()
	{
		return clsDynamicArray<T>::GetItemValueByIndex(0);
	}

	void UpdateItemValueByIndex(int Index, const T& Value)
	{
		clsDynamicArray<T>::SetItem(Index, Value);
	}

	void InsertAtTop(const T& Value)
	{
		clsDynamicArray<T>::InsertAtEnd(Value);
	}

	void InsertAtBottom(const T& Value)
	{
		clsDynamicArray<T>::InsertAtBeginning(Value);
	}

};

