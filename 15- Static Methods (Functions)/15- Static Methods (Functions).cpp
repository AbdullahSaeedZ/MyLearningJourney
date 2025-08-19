#include <iostream>
using namespace std;

// static function member is the same concept of static data member, it is shared on the level of the class not the object.
// i can call it from any object, and i can call this static function without creating any object, directly from the class.

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
    
    cout << clsA::Func1() << endl;
    
    // if we try calling Func2 which is not static, will not allow.
    
    return 0;
}

