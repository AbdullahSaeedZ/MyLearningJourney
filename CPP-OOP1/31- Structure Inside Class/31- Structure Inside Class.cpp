#include <iostream>
using namespace std;





class clsPerson {

    struct stAddress
    {
        string AddressLine1;
        string AddressLine2;
        string City;
        string Country;
    };

public:
    string FullName;
    stAddress Address;

    clsPerson()
    {
        FullName = "Abdullah Alzahrani";
        Address.AddressLine1 = "First Building";
        Address.AddressLine2 = "64 Street";
        Address.City = "Dammam";
        Address.Country = "SA";
    }

    void PrintAddress()
    {
        cout << "\nAddress:\n";
        cout << Address.AddressLine1 << endl;
        cout << Address.AddressLine2 << endl;
        cout << Address.City << endl;
        cout << Address.Country << endl;
    }

};

int main()

{

    clsPerson Person1;
    Person1.PrintAddress();

   
    return 0;
}