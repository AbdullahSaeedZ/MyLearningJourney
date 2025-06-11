#include <iostream>
using namespace std;


struct stInfo {

    string FirstName;
    string LastName;
    int Age;
    string Phone;

};

void ReadInfo(stInfo& Persons)
{
    cout << "Enter your first name: " << endl;
    cin >> Persons.FirstName;
    cout << "Enter your last name: " << endl;
    cin >> Persons.LastName;
    cout << "Enter your Age: " << endl;
    cin >> Persons.Age;
    cout << "Enter your phone number: " << endl;
    cin >> Persons.Phone;
}

void PrintUser(stInfo Persons)
{
    
    cout << "*****************************\n" << endl;
    cout << "First name: " << Persons.FirstName << endl;
    cout << "Last name: " << Persons.LastName << endl;
    cout << "Age: " << Persons.Age << endl;
    cout << "phone number: " << Persons.Phone << endl;
    cout << "*****************************" << endl << endl;
}

void ReadUsers(stInfo Persons[100], int& Length)
{
    cout << "How many Persons ?" << endl;
    cin >> Length;
    cout << endl;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "\n\nEnter info of Person " << Counter + 1 << " :" << endl;
        ReadInfo(Persons[Counter]);
    }


}

void PrintUsersInfo(stInfo Persons[2], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "\nPerson " << Counter + 1 << " Info :" << endl;
        PrintUser(Persons[Counter]);

    }
}

int main()
{
    stInfo Persons[100];
    int Length = 0;

    ReadUsers(Persons, Length);
    PrintUsersInfo(Persons, Length);



    return 0;
}



// i first did it like below, but above is better for saperating functions responsability.


//#include <iostream>
//using namespace std;
//
//struct stCardInfo
//{
//	string FirstName;
//	string LastName;
//	short int Age;
//	int Phone;
//
//};
//
//void  ReadInputs(stCardInfo Persons[100], int& Length)
//{
//	cout << "How many info cards do you want to print? (1 - 100)" << endl;
//	cin >> Length;
//	cout << endl;
//	
//
//	for (int Counter = 0; Counter < Length; Counter++)
//	{
//		cout << "Person Number " << Counter + 1 << " Info:" << endl;
//		cout << "**************************" << endl;
//		cout << "Enter first name: " << endl;
//		cin >> Persons[Counter].FirstName;
//		cout << "Enter last name: " << endl;
//		cin >> Persons[Counter].LastName;
//		cout << "Enter age: " << endl;
//		cin >> Persons[Counter].Age;
//		cout << "Enter phone number:" << endl;
//		cin >> Persons[Counter].Phone;
//		cout << "**************************" << endl;
//
//	}
//}
//
//void PrintCards(stCardInfo Persons[100], int Length)
//{
//	for (int Counter = 0; Counter < Length; Counter++)
//	{
//		cout << "Person Number " << Counter + 1 << " Info:" << endl;
//		cout << "**************************" << endl;
//		cout << "First Name: " << Persons[Counter].FirstName << endl;
//		cout << "Last Name: " << Persons[Counter].LastName << endl;
//		cout << "Age: " << Persons[Counter].Age << endl;
//		cout << "Phone Number:" << Persons[Counter].Phone << endl;
//		cout << "**************************" << endl;
//
//	}
//}
//
//int main()
//{
//	stCardInfo Persons[100];
//	int	Length = 0;
//
//	ReadInputs(Persons, Length);
//	PrintCards(Persons, Length);
//
//	return 0;
//}
//
