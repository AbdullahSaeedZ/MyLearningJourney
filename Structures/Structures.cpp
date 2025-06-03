#include <iostream>
using namespace std;

// a structure is when we create like a data type such as the int or float when creating variables, we create the structure as the following:
struct MemberEducation {

    string Major;  // inside a structure we create variables to be assigned and filled later 
    string Degree;
    bool IsGraduated;

};

struct car {
    
    string CarName;
    short int CarModel, CarPrice;

};

// we can put structures inside structures as we wish 
struct FamilyMember {

    string Name;
    short int Age;
    char Gender;
    bool Employed;
    car CarInfo;
    MemberEducation Education;

};

int main()
{
    // now we create variables using the structure we made earlier then assgin values

    FamilyMember FirstSon;
    FirstSon.Name = "Abdullah";
    FirstSon.Age = 27;
    FirstSon.Gender = 'M';
    FirstSon.Employed = false;
    FirstSon.Education.Degree = "BS";
    FirstSon.Education.IsGraduated = false;
    FirstSon.Education.Major = "E-commerce";
    FirstSon.CarInfo.CarName = "Elantra";
    FirstSon.CarInfo.CarModel = 2018;
    FirstSon.CarInfo.CarPrice = 75000;

    FamilyMember SecondSon;
    SecondSon.Name = "Fawaz";
    SecondSon.Age = 24;
    SecondSon.Gender = 'M';
    SecondSon.Employed = false;
    SecondSon.Education.Major = "CS";
    SecondSon.Education.Degree = "BS";
    SecondSon.Education.IsGraduated = false;
    SecondSon.CarInfo.CarName = "Optima";
    SecondSon.CarInfo.CarModel = 2012;
    SecondSon.CarInfo.CarPrice = 50000;

    cout << "the first son in our family is: " << FirstSon.Name << " and the second son is: " << SecondSon.Name << endl;
    cout << "Abdullah`s education details are: " << FirstSon.Education.Major << " with " << FirstSon.Education.Degree << " degree" << endl;


    return 0;
}

