//In C++, a union is a user - defined data type that allows you to use the same memory location for different types of data.
// Unlike structures, where each member has its own memory space, members of a union share the same memory space.

#include <iostream>

union MyUnion
{
    int intValue;
    float floatValue;
    char charValue;
};

int main() 
{
    MyUnion myUnion;

    myUnion.intValue = 42;
    std::cout << "Integer value: " << myUnion.intValue << std::endl;

    myUnion.floatValue = 3.14f;
    std::cout << "Float value: " << myUnion.floatValue << std::endl;

    myUnion.charValue = 'A'; 
    std::cout << "Char value: " << myUnion.charValue << std::endl; // since we assigned a value to char, if we try to print the float value, the value will show some random numbers, cuz value of char has overriden float value.

    // last saved value was in the char member, if i call the float member we will have runtime error, cuz union has one memory location and i last saved the char value.

    return 0;
}


/*
In this example, MyUnion is a union that can store an integer, a float, or a character.When you assign a value to one of the members, it modifies the shared memory space,
and accessing another member will give you the interpretation of that data based on its type.

Keep in mind that unions have some limitations and should be used with caution because they can lead to undefined behavior if not used properly.
When one member of the union is accessed, you should be careful about which member was last assigned a value.Also, 
the size of a union is determined by the size of its largest member.

Undefined Behavior :
When you use a union, it's important to be mindful of which member was last assigned a value. 
Accessing a member that wasn't the last one written to results in undefined behavior.This is because the union shares the same memory space for all its members.
If you read from a member that was not the last one written to, the value might not make sense for that type.

Careful Member Access :
If you assign a value to one member of the union and then access another member, you might get unexpected results.
For example, if you store an integer and then read it as a floating - point number, the interpretation of the bits will be different.

Size Determined by Largest Member :
The size of a union is determined by the size of its largest member.
This means that if you have a union with an int, a float, and a char, the size of the union will be the size of the float since it's the largest member.
This can lead to inefficient memory usage if you're not careful with the design of your union.
*/
