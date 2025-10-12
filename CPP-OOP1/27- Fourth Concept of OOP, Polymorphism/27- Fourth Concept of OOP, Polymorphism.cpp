#include <iostream>
using namespace std;

// تعدد الاشكال
// Polymorphism
// Poly = many, Morphism = forms → means "many forms".
// It gives us one interface, but different behaviors.

// ----------------------------------------------------
// Compile-time Polymorphism (decided by compiler)
// ----------------------------------------------------

// 1- Function overloading: 
// Same function name but different parameters (type / number / order).
// Compiler decides which one to use at compile time.
// ex: instead of 4 different Sum functions, we write them all as Sum with different parameters.

// 2- Operator overloading:
// Using the same operator for different types.
// ex: '+' can add 2 ints, or concatenate 2 strings.


// ----------------------------------------------------
// Run-time Polymorphism (decided while program runs)
// ----------------------------------------------------

// 1- Function overriding: 
// Derived class writes a function with the SAME signature as base class.
// - Without 'virtual' → base function is hidden, not real polymorphism. <- important.
// - With 'virtual' in base → true overriding, runtime polymorphism works.

// 2- Virtual functions:
// Keyword 'virtual' on the base class print function tells compiler: "decide later at runtime".
// ex: 
//     Base* p = new Student();
//     p->print();  // will call Student’s print() at runtime, not Base.



int main()
{
    




    return 0;
}

