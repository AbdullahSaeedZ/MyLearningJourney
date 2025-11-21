using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Generalization is the process of extracting common properties from a set of entities and create a generalized entity from it.
// It is a bottom-up approach in which two or more entities can be generalized to a higher level entity if they have some attributes in common.

// Generalization is to create a general entity to group attributes that are shared (general) of different entites.
// it reduces data redundancy

// ex: Student and Employee entities share general attributes like name and birth date,
// so we create a general entity called person with those general attributes then we link student and employee entities to this general entity
// we use generalization relation to link, with triangle symbol pointing to the general entity,
// see pdf for clear example, it is kind of similar to OOP inheritance concept


namespace _24___Generalization
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
