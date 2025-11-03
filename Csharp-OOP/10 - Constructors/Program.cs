using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 
C# Constructor
In C#, a constructor is similar to a method that is invoked when an object of the class is created.

However, unlike methods, a constructor:

has the same name as that of the class
does not have any return type
Create a C# constructor
Here's how we create a constructor in C#

class clsPerson{
  
  // constructor
  clsPerson() {
    //code
  }

}

Here, clsPerson() is a constructor. It has the same name as its class.

Call a constructor

Once we create a constructor, we can call it using the new keyword. For example,

new clsPerson();
In C#, a constructor is called when we try to create an object of a class. For example,

clsPerson Person1 = new clsPerson();
Here, we are calling the clsPerson() constructor to create an object Person1.

Types of Constructors
There are the following types of constructors:

Parameterless Constructor
Parameterized Constructor
Default Constructor
 
 */


namespace _10___Constructors
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
        }
    }
}
