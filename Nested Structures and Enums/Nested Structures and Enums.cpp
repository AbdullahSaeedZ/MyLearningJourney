#include <iostream>
using namespace std;

// nested structures means a structure is used inside a structure.
// when naming enums, start with en then name it , same with structures start with st, this is a better practice.

enum enColor {Blue, Red, Green, Yellow};
enum enGender {Male, Female};
enum enMartialStatus {Married, Single};

struct stAdress {

    string HouseNumber;
    string Street;
    string POBox;
    string ZipCode;
};

struct stContactInfo {

    short int Phone;
    string Email;
    stAdress Adress; // we nested stAdress inside the contact info structure cuz i need the adress of a person to be inside his contact info.
};

struct stPerson {
    
    string FirstName;
    string LastName;
    string Age;
    stContactInfo ContactInfo;

    enMartialStatus Status;
    enGender Gender;
    enColor FavColor;
};


int main()
{
    // now we create a normal variable but with the structure of stPerson, then we fill baed on the structure members we created erlier.
    stPerson Person1;

    Person1.FirstName = "Abdullah";
    Person1.LastName = "Alzahrani";
    Person1.Age = "27";
    Person1.ContactInfo.Adress.HouseNumber = "2423";
    Person1.ContactInfo.Adress.Street = "68 street";
    Person1.ContactInfo.Email = "Asz@gmail.com";
    Person1.ContactInfo.Phone = 0543254235435;

    Person1.FavColor = enColor::Blue;
    Person1.Gender = enGender::Male;
    Person1.Status = enMartialStatus::Single;

    //now we print whatever info we want from the what we created above, consider it a detailed card of a person and we choose what to print from that card.

    cout << Person1.ContactInfo.Adress.HouseNumber << endl;


    return 0;
}

