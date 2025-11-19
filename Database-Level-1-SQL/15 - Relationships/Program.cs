using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// after defining entities, we have to define relationships between them.

// ex: two entities, Student and Course, we ask is there a relation of the two?
// yes, a student enrolls in a course and the course has enrolled students, then we identify a Enrollment as relation of the two

// another ex: student and ID Card entities, relation is "has", student has an ID-Card, and ID-Card has student info

// another ex: customer and order entities, relation can be "place", customer places an order, an order is placed by a customer

// another ex: in a library, member and books, a member "borrows" a book.

// also can have more than one relationship between two entitis, 
// ex: Employee and Project entities, one relation is "Work on" and another one is "Manage"



// Self Referencing Relationship: one entity that has relation with itself:
// ex: Employee entity with Manage relation with same Employee entity,
// explanation is an employee manages other employees , see pdf for clear example



// nature of relationships are explained in next lessons

namespace _15___Relationships
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
