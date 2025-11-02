using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// class is a data type , to be useful we need to create an object from it to use the class methods and data members.
// class is also a data structure, we organize data in it



namespace _1___Class___Object
{


    class clsPerson
    {
        // called fields (variable or data members)
        // fields - variables to store data
        public string firstName;
        public string lastName;

        // cuz fields are on the heap, the CLR gives it initial values.
        public int age;        // given 0 as initial value
        public bool isActive;  // given false as initial value
        public clsPerson p;    // given null as initial value




        private string _name;
        // property is a method to reach a privet data member
        // this is a set&get property for the private memebr _name
        public string name  //note there is no brackets, not like a method declaration
        {
            get { return _name; }
            set { _name = value; }
        }

        // or short property
        private string familyName { set; get; }

        // methods
        public string fullName()
        {
            return firstName + " " + lastName;
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {

            // declare a reference variable, then create an object in the memory using new keyword 
            clsPerson person1 = new clsPerson();
            person1.firstName = "Abdullah";
            person1.lastName = "Alzahrani";
            Console.WriteLine(person1.fullName());

            clsPerson person2; // this is a reference variable with no value stored, no null nothing , cuz it is a local variable of Main, it it was on the class level then it will be given null as initial value.
            person2 = new clsPerson();
            person2.firstName = "fawaz";
            person2.lastName = "Alzahrani";
            Console.WriteLine(person2.fullName());
        }
    }
}
