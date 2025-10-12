#pragma once

#include <iostream>
#include "clsMyQueue.h"
using namespace std;

// stack class has the vry similar methods of the queue class we madre erlier, so just inherit then modify to fit our goal.

template <class T>
class clsStack : public clsMyQueue<T>
{

public:


	void Pop() //override the base class pop method
	{
		clsMyQueue <T>::_MyList.DeleteLastNode();
	}

	

	T Top()
	{
		return clsMyQueue <T>::Back();
	}

	T Bottom()
	{
		return clsMyQueue <T>::Front();
	}


	void InsertAtTop(const T& Value)
	{
		clsMyQueue<T>::InsertItemAtBack(Value);
	}

	void InsertAtBottom(const T& Value)
	{
		clsMyQueue<T>::InsertItemAtFront(Value);
	}

};

