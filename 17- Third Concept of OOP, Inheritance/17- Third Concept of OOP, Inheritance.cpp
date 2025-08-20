#include <iostream>
using namespace std;


// Inheritance: Inheritance is one in which a new class is created that inherits the properties of the already exist class.
// It supports the concept of code reusability and reduces the length of the code in object-oriented programming.
// sub class will have its members + main class members.
// instead of copying manually all the functions and the code from one class to another, just inherit it.
// main class is called Super Class / Base Class, the inherited class is called Sub Class / Derived Class.

// any changes or new features added to the base class, will be added to the sub class



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

    clsPerson() // default constructor, just to handle inheritance for the moment (better handling in next lessons).
    {

    }

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

    // No Code!
    // all code inherited from the base class
    // data members are also inherited, but as empty data members, will have separate values for each class.
    // those private data members that was created in base class, cant be dealt with by the sub class unless we create getter and setter in the base class
    // , or make them protected not private to be able to deal access them (not the base class data members values) without getters and setters




    // so in this sub class just add what is needed (the purpose of creating a sub class)
private:

    string _Title;
    string _Department;
    float _Salary;

public:

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

    clsPerson Abdullah(100, "Abdullah", "Alzahrani", "MyMail@gmail.com", "05435435353");

    Abdullah.Print();

    Abdullah.SendEmail("The Project", "hi, any updates on the project?");
    Abdullah.SendSMS("Call Me ASAP");



    clsEmployee koko;

    // i can access all inherited members of the base class
    koko.setFirstName("koko");
    koko.setLastName("Alzahrani");
    koko.setPhoneNumber("02223423");
    koko.SendSMS("Hi, this is sent from a sub class using base class methods!");
    koko.Print();

    // and i can also use the members of the sub class
    koko.setDepartment("Maintenance");
    cout << "\n" << koko.Department() << endl;


    // this is just to show that sub class has its own data memebrs values not the same values of inherited variables
    Abdullah.Print();


    return 0;
}