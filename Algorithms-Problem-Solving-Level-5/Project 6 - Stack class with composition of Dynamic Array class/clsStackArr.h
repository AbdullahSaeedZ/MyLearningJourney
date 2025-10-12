#pragma once

#include <iostream>
#include "clsQueueArr.h"
using namespace std;

template <class T>
class clsStackArr : public clsQueueArr<T>
{

public:

	void Push(const T &Value)
	{
		clsQueueArr<T>::InsertAtFront(Value);
	}

	T Top()
	{
		return clsQueueArr<T>::GetItemByIndex(clsQueueArr<T>::Size() - 1);
	}

	T Bottom()
	{
		return clsQueueArr<T>::Back();
	}

	void UpdateItemValueByIndex(int Index, const T& Value)
	{
		clsQueueArr<T>::UpdateItemByIndex(Index, Value);
	}

	void InsertAtTop(const T& Value)
	{
		clsQueueArr<T>::InsertAtFront(Value);
	}

	void InsertAtBottom(const T& Value)
	{
		clsQueueArr<T>::InsertAtBack(Value);
	}

};

