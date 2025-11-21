using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// see pdf

// Associative Entities: a relation between two entities that becomes an entity related with another entity

// ex: Student ---------|Enrolled|----- Course
//                          |
//                          |
//                          |
//                        Teach
//                          |
//                          |
//                          |
//                       Teacher


// a teacher will teach a student that is enrolled in a course,
// he cant teach student who are not enrolled in courses.

// Enrolled relationship is now an associative entity, presented by a diamond inside a square symbol

namespace _23___Aggregation_and_Associative_Entities
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
