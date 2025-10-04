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
		tempArr = nullptr;
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

	T GetItemValueByIndex(int Index)
	{
		return arr[Index];
	}

	void Reverse()
	{
		tempArr = new T[_Size];

		for (int i = 0; i < _Size; i++)
		{
			tempArr[i] = arr[(_Size - 1) - i];
		}

		delete[] arr;
		arr = tempArr;
	}

	void Clear()
	{
		_Size = 0;
		delete[] arr;
		arr = new T[0];
	}

	void DeleteItemByIndex(int Index)
	{
		if (Index < 0 || Index >= _Size)
			throw out_of_range("Index out of range!");

		tempArr = new T[_Size - 1];
		for (int i = 0, j = 0; i < _Size; i++)
		{
			if (i == Index) // if we reach item to be deleted , skip it
				continue;

			tempArr[j++] = arr[i];
		}

		delete[] arr;
		arr = tempArr;
		_Size--;
	}

	void DeleteItemAtFirst()
	{
		
		DeleteItemByIndex(0);
	}

	void DeleteItemAtEnd()
	{
		DeleteItemByIndex(_Size - 1);
	}

	int FindByValue(const T& Value)
	{
		for (int i = 0; i < _Size; i++)
		{
			if (arr[i] == Value)
				return i;
		}

		return -1;
	}

	void DeleteItemByValue(const T& Value)
	{
		DeleteItemByIndex(FindByValue(Value));
	}

	void PrintItems()
	{
		for (int i = 0; i < _Size; i++)
		{
			cout << arr[i] << " ";
		}
	}




};

