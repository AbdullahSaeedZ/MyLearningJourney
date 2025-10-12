#include <iostream>
using namespace std;

// the parameterized constructor in the base class, will take the parameters values and store them directly in its private data members.
// but the issue is, when we declared a sub class and then we inherited those data members and the same constructor.
// in the sub class, how will we save those parameters values when we dont have direct access and dont have those private members declared in the sub class?
// in result, when declaring an object of a sub class, it will not allow to enter the constructor values.

// solution is to make a constructor in the sub class that allows us to pass those values to the base constructor then to those data members we inherited.
// this will be done by using Initializer list.

// base class
class clsPerson
{
private:

    short _ID = 0;
    string _FirstName = "";
    string _LastName = "";
    string _Email = "";
    string _PhoneNumber = "";


public:

    clsPerson(short ID, string FirstName, string LastName, string Email, string PhoneNumber)
    {
        _ID = ID;
        _FirstName = FirstName;
        _LastName = LastName;
        _Email = Email;
        _PhoneNumber = PhoneNumber;
    }

    //Read-Only property
    short ID()
    {
        return _ID;
    }


    void setFirstName(string Name)
    {
        _FirstName = Name;
    }

    string FirstName()
    {
        return _FirstName;
    }

    void setLastName(string Name)
    {
        _LastName = Name;
    }

    string LastName()
    {
        return _LastName;
    }

    void setEmail(string Email)
    {
        _Email = Email;
    }

    string Email()
    {
        return _Email;
    }

    void setPhoneNumber(string Number)
    {
        _PhoneNumber = Number;
    }

    string PhoneNumber()
    {
        return _PhoneNumber;
    }

    string FullName()
    {
        return _FirstName + " " + _LastName;
    }



    void Print()
    {

        cout << "\nInfo\n" << endl;
        cout << "_________________________________" << endl;
        cout << "ID        : " << _ID << endl;
        cout << "First Name: " << _FirstName << endl;
        cout << "Last Name : " << _LastName << endl;
        cout << "Full Name : " << FullName() << endl;
        cout << "Email     : " << _Email << endl;
        cout << "Phone     : " << _PhoneNumber << endl;
        cout << "_________________________________\n" << endl;

    }

    void SendEmail(string Subject, string Body)
    {
        cout << "The following message has been sent successfully to: " << _Email << endl;
        cout << "Subject: " << Subject << endl;
        cout << "Body: " << Body << "\n" << endl;
    }

    void SendSMS(string Message)
    {
        cout << "The following message has been sent successfully to: " << _PhoneNumber << endl;
        cout << Message << "\n" << endl;
    }



    ~clsPerson()
    {
        cout << "\n\nEnd of program, object destructed!" << endl;
    }
};

// sub class
class clsEmployee : public clsPerson
{
private:

    string _Title;
    string _Department;
    float _Salary;

public:


    // using initializing list to pass values to base constructor, and we can add as much parameters as we need.

    clsEmployee(short ID, string FirstName, string LastName, string Email, string PhoneNumber, /*sub class parameters*/ string Title, string Dept, float Salary)
        : clsPerson(ID, FirstName, LastName, Email, PhoneNumber)
    {
        _Title = Title;
        _Department = Dept;
        _Salary = Salary;
    }


    void setSalary(float Number)
    {
        _Salary = Number;
    }

    float Salary()
    {
        return _Salary;
    }

    void setTitle(string Title)
    {
        _Title = Title;
    }

    string Title()
    {
        return _Title;
    }

    void setDepartment(string Dept)
    {
        _Department = Dept;
    }

    string Department()
    {
        return _Department;
    }

};


int main()
{

    clsEmployee koko(200, "koko", "Alzahrani", "Emp@mail.com", "023232432", "Leader", "Network", 23000);

    koko.Print();

 


    return 0;
}