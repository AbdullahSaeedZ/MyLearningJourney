using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// An attribute exhibits the properties of an entity.
// Gender and Name are attributes of Student entity.
// represented with oval shape in an ER diagram.


// types: 
// Key attributes (oval symbol): uniquely identifies an entity from the an entity set,
// ex:like ID as primary key becomes key attribute.

// Composite attribute (oval symbol): attribute that is composed of several other attributes is known as a composite attribute.
// ex: name attribute consists of two attributes, first name and last name.

// Multi-valued attribute (double oval symbol): attribute that holds more than one value.
// ex: student has phone number 1 and phone number 2 both in one field, not a good practice, make separate fields for each.

// Derived attribute (dashed oval symbol): attribute that can be derived from other attributes of an entity.
// ex: can derive age from date birth.


namespace _14___Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
