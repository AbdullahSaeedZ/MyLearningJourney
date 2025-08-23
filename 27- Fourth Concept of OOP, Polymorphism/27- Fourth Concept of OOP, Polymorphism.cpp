#include <iostream>
using namespace std;

// تعدد الاشكال
// Polymorphism: word Poly means "Many" and word Morphism means "Form" so it means "Many Forms", the ability to take more than one form.
// Polymorphism allows us to create CONSISTENT code.

// Polymorphism can be done through: 
// 
// 1- Function overloading (Compile-time Polymorphism): when we have two or more functions with the SAME name, but different parameters in number, type, and order.
// ex: instead of having 4 Sum functions of different parameters that we call separately, we unify them under one name.

// 2- Function overriding (Run-time Polymorphism): two functions with same name and parameters, the newer function cancels the old function.
// ex: class Person has print functions, then sub class Student has the same print function, the student function overrides the base class print function.
// 2- Function overriding: happens when a derived class defines a function with the SAME signature as the base class.
//    - Without 'virtual': it's just HIDING, not real polymorphism.
//    - With 'virtual' in the base: it's true OVERRIDING and part of runtime polymorphism.


// 3- Virtual functions (Run-time Polymorphism): when using pointers in upcasting, once we call print function, the pointer will know which print function to call through the virtual function.
// Virtual keyword lets the program decide at runtime which function to run.
// Ex: Base* p = new Student(); p->print(); calls Student’s print().

// 4- Operator overloading: when operators do more than one thing.
// ex: we use addition operator to add 2 int variables, and we can use the same operator to add two string variables (concatenation) 



int main()
{
    




    return 0;
}

