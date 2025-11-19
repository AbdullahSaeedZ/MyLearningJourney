using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// one-to-many: when single element of an entity is associated with more than one element of another entity
// ex: a customer can place MANY orders, but an order is placed by 1 customer

// this is how we express it , 
// Customer -------|place|-----> Many Order
// Customer 1 <-------|place|----- Order

// one-to-many relation nature
// // Customer 1<-------|place|----->Many Order


// many-to-one: when more than one element of an entity is related a single element of another entity
// ex: a project is worked on by MANY employees, but an employee works on 1 project

// this is how we express it , 
// employee -------|work on|-----> 1 project
// employee  Many <-------|work on|----- project

// many-to-one relation nature
// // employee  Many<-------|work on|----->1 project


// also can have self relation here
// ex: employee 1 -----|manage|--
//         |                    |
//     many ____________________|

// one employee (manager) manages many employees


//many-to-one and one-to-many can be the same thing, it depends on where you see the relation
// ex:              employee  Many<-------|work on|----->1 project
// is the same as   project  1<-------|work on|----->Many employee


// relations type is determined based on business requirements, in our example, busniss require that
// the project is worked on by many employees, but each employee works on one project
// another business might say i need project to be worked on by many employees, and employees work on many project, and so on.


namespace _17___One_to_Many_and_Many_to_One_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
