#pragma once

#include <iostream>
using namespace std;

template <class T>
class clsDynamicArray
{
protected:

	int _Size;
	T* tempArr;

public:

	T* arr;

	clsDynamicArray(int Size = 0)
	{
		if (Size < 0)
			Size = 0;

		_Size = Size;
		arr = new T[_Size];
	}

	~clsDynamicArray()
	{
		delete[] arr;
	}

	void SetItem(int Index, const T& Value)
	{
		if (Index >= _Size || Index < 0)
			throw out_of_range("Index out of range!");

		arr[Index] = Value;
	}

	bool IsEmpty()
	{
		return (_Size == 0);
	}

	int Size()
	{
		return _Size;
	}

	void ReSize(int NewSize)
	{
		if (NewSize < 0)
			throw out_of_range("Size out of range!");

		tempArr = new T[NewSize];
		
		if (NewSize < _Size)
			_Size = NewSize;

		for (int i = 0; i < _Size; i++)
		{
			tempArr[i] = arr[i];
		}
		_Size = NewSize;
	
		delete[] arr; // free linked items with arr in heap
		arr = tempArr; // link arr to memory pointed by tempArr
	}

	void PrintItems()
	{
		for (int i = 0; i < _Size; i++)
		{
			cout << arr[i] << " ";
		}
	}




};

