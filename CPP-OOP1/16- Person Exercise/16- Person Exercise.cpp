#include <iostream>
using namespace std;


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





int main()
{
    
    clsPerson Abdullah(100, "Abdullah", "Alzahrani", "MyMail@gmail.com", "05435435353");

    Abdullah.Print();

    Abdullah.SendEmail("The Project", "hi, any updates on the project?");
    Abdullah.SendSMS("Call Me ASAP");

    cout << Abdullah.LastName() << endl;

    Abdullah.setFirstName("koko");
    cout << Abdullah.FirstName() << endl;
    

    
    return 0;
}

