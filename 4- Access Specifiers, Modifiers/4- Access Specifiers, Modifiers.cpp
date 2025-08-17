#include <iostream>
using namespace std;

// Access Specifiers(or Access Modifiers): is the concept of who has access to the members declared inside the class.
// 
// there are 3 types of access Specifiers:
// 1- Private: Accessible only inside the class and by the class members. outside the class in main for example, it is not accessible.
// 2- Protected: Accessible by members inside the class and any other classes that will inherit, but not accessible outside the class like in main.
// 3- Public: Accessible to anyone, by inheritance, class members, and outside the class like in main.

// this concept is called Encapsulation: it organizes and controls access to the code members.
// الهدف مو "سيكيورتي" بالمعنى الأمني، إنما تنظيم وإدارة الوصول (encapsulation).


class clsPerson
{
private: // Only Inside Members Access, No Inheritance Access, No Outside Class Access  

    int x = 20;
    int Function1()
    {
        return 10;
    }

protected: // Only Inside Members Access and Inheritance Access, No Outside Class Access

    int z = 10;
    int Function2()
    {
        return 30;
    }

public: // Access to All

    string FirstName;
    string LastName;

    string FullName()
    {
        return FirstName + " " + LastName;
    }
    int Function3()
    {
        return Function1() + x + z;
    }
};




int main()
{
    

    clsPerson Person1;

    Person1.FirstName = "Abdullah";
    Person1.LastName = "Alzahrani";

    cout << Person1.FullName() << endl;
    cout << Person1.Function3() << endl;


    return 0;
}