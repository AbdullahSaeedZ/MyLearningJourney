#include <iostream>
using namespace std;

// multi level inheritance is when we declare classes, and each class has more detalis than the prevoius ones.
// below is an example: main class is person then we derived Employee which has more attributes, then we drived Developer class which has more than Employee class
// Multi level inheritance, NOT multiple inheritance, this is the concept.


// base class: Person  -  sub class: Employee
// base class: Employee  -  sub class: Developer

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


    clsEmployee(short ID, string FirstName, string LastName, string Email, string PhoneNumber, string Title, string Dept, float Salary)
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

    /*
    void Print() overriding the base class print function(in the sub class only).
    {
       we can access the print function of base class this way, using escape scope (baseClassName::)

        clsPerson::Print();

       can add any code here
    }
    */



    void Print()
    {

        //note that here in the sub class i need to use the getters to show values of ID, FirstName and so on.

        cout << "\nInfo\n" << endl;
        cout << "_________________________________" << endl;
        cout << "ID        : " << ID() << endl;
        cout << "First Name: " << FirstName() << endl;
        cout << "Last Name : " << LastName() << endl;
        cout << "Full Name : " << FullName() << endl;
        cout << "Email     : " << Email() << endl;
        cout << "Phone     : " << PhoneNumber() << endl;
        cout << "Title     : " << _Title << endl;
        cout << "Department: " << _Department << endl;
        cout << "Salary    : " << _Salary << endl;
        cout << "_________________________________\n" << endl;

    }
};

// another derived class from previous derived claas (this is called multi level inheritance)
class clsDeveloper : public clsEmployee
{
private:

    string _MainProgrammingLanguage = "";

public:

    clsDeveloper(short ID, string FirstName, string LastName, string Email, string PhoneNumber, string Title, string Dept, string MainLanguage, float Salary)
        : clsEmployee( ID,  FirstName,  LastName,  Email,  PhoneNumber,  Title,  Dept,  Salary)
    {
        _MainProgrammingLanguage = MainLanguage;
    }


    void setMainProgrammingLanguage(string Name)
    {
        _MainProgrammingLanguage = Name;
    }

    string MainProgramingLanguage()
    {
        return _MainProgrammingLanguage;
    }

    void Print()
    {
        cout << "\nInfo\n" << endl;
        cout << "_________________________________" << endl;
        cout << "ID        : " << ID() << endl;
        cout << "First Name: " << FirstName() << endl;
        cout << "Last Name : " << LastName() << endl;
        cout << "Full Name : " << FullName() << endl;
        cout << "Email     : " << Email() << endl;
        cout << "Phone     : " << PhoneNumber() << endl;
        cout << "Title     : " << Title() << endl;
        cout << "Department: " << Department() << endl;
        cout << "Salary    : " << Salary() << endl;
        cout << "Main Programming Language: " << _MainProgrammingLanguage << endl;
        cout << "_________________________________\n" << endl;
    }

};


int main()
{

    clsDeveloper Developer1(1, "Abdullah", "Alzahrani", "Top1@mail.com", "05432232", "Expert", "Development", "C++", 29000);

    Developer1.Print();


    return 0;
}