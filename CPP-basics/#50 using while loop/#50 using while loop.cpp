#include <iostream>
using namespace std;

void ReadPin(int& Pin)
{
	cout << "Please Enter you PIN Code to check your balance: " << endl;
	cin >> Pin;


	int Counter = 1;

	
		while (Counter != 3 && Pin != 1234)
		{
			cout << "Wrong! enter PIN again: " << endl;
			cin >> Pin;
			Counter++;
		}
	

	if (Counter == 3 && Pin != 1234)
	{
		cout << "Card is blocked!!" << endl;
	}
	else
	{
		cout << "Your Balance is: 7500" << endl;
	}


	
}



int main()
{
	int PIN;
	ReadPin(PIN);

	


	return 0;
}

