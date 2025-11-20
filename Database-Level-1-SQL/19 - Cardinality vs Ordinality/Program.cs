using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Cardinality refers to the maximum number of times an instance in one entity can relate to instances of another entity

// ex:
// many-to-one relation nature
// employee  Many<-------|work on|----->1 project
// many and  1 are cardinality
// basically it is the question of What is the maximum number


// is the minimum number of times an instance in one entity can be associated with an instance in the related entity. (in other words It specify if it’s
// (optional if 0 / mandatory, at least 1 / required or not).

// ex:
// in the same many-to-one relation nature, we can define ordinality which is the minimum:
// employee  0<-------|work on|----->0 project
// minimum is zero employees to work on project, and the project minimum employee to work on is zero
// 0 and 0  are the ordinality
// basically it is the question of What is the minimum number

// another example:
//  Customer -------|place|----->0 Order
//  Customer 1 <-------|place by|----- Order
// a customer can have minimum 0 orders, but an order atleast must be placed by 1 customers
// cuz orders cant be created unless a customer places an order !
// Ordinality here is 1 - 0, which is the minimum



// in ERD`s they are expressed this way (min, max) which is (Ordinality, Cardinality)
// ex: 
//   Customer (1, 1) <-------|place|-----> (0, M) Order
// cardinality = one to many
// Ordinality = 1 - 0

// see next lesson to see the common symbols of them.


namespace _19___Cardinality_vs_Ordinality
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
