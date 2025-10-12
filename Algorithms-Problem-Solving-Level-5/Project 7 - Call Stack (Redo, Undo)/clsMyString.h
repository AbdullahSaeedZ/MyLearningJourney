#pragma once

#include <iostream>
#include <stack>
using namespace std;

class clsMyString
{

protected:

	stack<string> Stack;
	stack<string> RedoStack;
	

public:

	void setValue(string Value)
	{
		Stack.push(Value);
	}

	string getValue()
	{
		return (Stack.empty()) ? " " : Stack.top();
	}

	__declspec(property(get = getValue, put = setValue)) string Value;

	void Undo()
	{
		if (!Stack.empty())
		{
			RedoStack.push(Stack.top());
			Stack.pop();
		}
	}

	void Redo()
	{
		if (!Stack.empty())
		{
			Stack.push(RedoStack.top());
			RedoStack.pop();
		}
	}


};

