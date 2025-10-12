#include <iostream>
using namespace std;

// A static member function belongs to the class itself, not to any specific object.
// - It can be called directly using the class name (without creating an object).
// - It can also be called from an object, but it’s still the same single function shared by all objects.
// - A static function can only access other static members (data or functions) of the class.
//   It cannot access non-static members, because those require a specific object instance.

class clsA
{
public:
    static int Func1()
    {
        return 10;
    }

    int Func2()
    {
        return 20;
    }
};

int main()
{
    cout << clsA::Func1() << endl;  // valid: call static function directly from class

    // clsA::Func2();  // invalid: cannot call a non-static function without an object

    return 0;
}