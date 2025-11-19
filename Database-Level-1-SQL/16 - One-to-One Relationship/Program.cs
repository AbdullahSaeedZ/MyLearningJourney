using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// one to one relationship
// When a single element of an entity is associated with a single element of another entity, it is called a one-to-one relationship

// Student and ID-Card relationship has a one-to-one relation nature
// meaning, a student can have MAXINMUM one ID-Card, and the ID-Card can contain info of MAXIMUM one student

// this is how we express it , 
// Student -------|has|-----> 1 ID-Card
// Student 1 <-------|has|----- ID-Card

// one-to-one relation nature
// // Student 1<-------|has|----->1 ID-Card


// another example
// Traveler -------|set|-----> 1 Seat
// Traveler 1 <-------|set|----- Seat

// one-to-one relation nature
// // Traveler 1<-------|set|----->1 Seat


// see pdf for more examples


namespace _16___One_to_One_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
