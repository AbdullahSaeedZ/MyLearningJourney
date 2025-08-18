#include <iostream>
using namespace std;

// Encapsulation: grouping all functions and data variables into one place (a class),
// based on the object they belong to.
//
// Abstraction: exposing only the necessary methods of a class to the user 
// and hiding the implementation details and data members.
//
// In short: Abstraction = hiding unnecessary details, showing only what is essential.
// In simple terms, abstraction “displays” only the relevant attributes of objects and “hides” the unnecessary details.

// Abstraction = تعني التجريد , ف انا اجرد التفاصيل الغير ضروريه

class CoffeeMachine {
private:
    void BoilWater() 
    {
        // Complex code to boil water
        cout << "Boiling water..." << endl;
    }

    void Brew()
    {
        // Brew coffee beans
        cout << "Brewing coffee..." << endl;
    }

    void Pour()
    {
        // Pour into cup
        cout << "Pouring coffee into cup..." << endl;
    }

public:

    void MakeCoffee() 
    {
        BoilWater();
        Brew();
        Pour();
    }

};

int main()
{

    CoffeeMachine machine;
    machine.MakeCoffee();  // Easy and clear

    return 0;
}