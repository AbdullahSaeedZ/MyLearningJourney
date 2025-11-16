using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// Entities:
// 1- Entity (Strong Entity).
// 2- Weak Entity

// An entity can be either a living or non-living component.
// ex: living like a person, non-living like Course

// a simple way to make a decision whether this data should be an entity or not is to:
// ask yourself, do i need to store another data of this thing ? if yes then it is an entity 
// ex: a student will need data to be stored in database, then student is an entity


// it is called strong cuz it has a primary key
// ex: a student has ID attribute as the primary key
// represented in ERD as rectangle symbol

// it is called weak entity cuz it has no primary key which is a bad practice.
// ex: see dependent example in pdf, solved by adding ID key attribute for each dependent to reach Entity Integrity (every entity has a primary key)
// represented in ERD as double rectangle symbol



namespace _13___Entity__Strong__and_Weak_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
