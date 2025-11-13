using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Redundancy is duplicate data

/*
    Types of Redundancy:

    1) Direct Redundancy:
       - Storing the exact same data in multiple places with no real benefit.
       - Example: A student's address stored in both the Students table
         and the Registrations table.

    2) Derived Redundancy:
       - Storing data that can be calculated or inferred from other data.
       - Example: Storing "Age" when "DateOfBirth" already exists.

       *Note: Derived redundancy can sometimes be useful for performance,
              such as storing pre-calculated totals or summaries to avoid
              expensive calculations every time.
*/


// can be department id, name and location repeated in multiple records in the same table
// this causes :
// - more wasted space
// - data inconsistency
// - data corruption
// - missing or incomplete data
// hard to maintain, if i want to change department name i will have to change it in all employees records
// Redundancy can make it more difficult to maintain consistency within the database. If one copy of the data is updated, the other copies may become outdated, leading to inconsistencies and errors.



// solved by Normalization, which is reducing redundant data by separating those data in relational tables, see PDF important
// Normalization is the process of organizing data in a database in a way that reduces redundancy.
// Normalization improves data integrity.
// Normalization involves breaking down the data into smaller, more atomic pieces and linking them together through relationships, which can reduce the amount of redundant data and make it easier to manage and update the database.

// Constraints are Restrictions/Rules on Data.
// Enforcing data constraints, such as unique keys and foreign key relationships, can help prevent redundant data from being inserted into the database.



namespace _5___What_is_Redundancy_and_why_it_s_a_problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
