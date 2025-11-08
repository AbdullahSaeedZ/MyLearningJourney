using System;



using MyLibrary;





namespace _40___protected_internal
{

    class Student : Person   //  inheritance works from another assembly because Person is public, if Person was internal then we couldnt access it here
    {
        public void Test()
        {
            Speak();   //  allowed because of protected internal, same if it was only protected
        }
    }

    class Human
    {

        public void method()
        {
            // not inheriting Person, so i cant reach the speak method, even though the class is public, but the method is protected internal
          //  Speak(); 
        }

    }

    public class Class1
    {
        internal void main(string[] args)
        {

            Student s = new Student();
            s.Test();
            s.greet(); // this is accessible cuz method is public and class is public 
         // s.Speak() // cant access it, eventhough the base class is public in the other assembly, but the method itself is protected internal
            

        }


    }
}
