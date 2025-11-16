using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// constraints = validation rules or limits or conditions or قيود
// constraints are rules or conditions that are applied to the data to ensure its integrity and consistency.
// constraints can be applied on individuals columns or the entire table.


// common types of constraints:

// 1- Primary Key Constraint: This constraint ensures that a column or a set of
// columns uniquely identifies each row in a table. This constraint helps to
// enforce data integrity and ensure that there are no duplicate rows in the table.

// 2- Foreign Key Constraint: This constraint establishes a relationship between two
// tables based on a key field. The foreign key constraint ensures that data in one
// table matches data in another table, and it helps to maintain referential integrity

// 3- Unique Constraint: This constraint ensures that the data in a column or set of
// columns is unique across all rows in the table. This constraint helps to enforce
// data integrity and prevent duplicate values from being inserted into the table.
// ex: employees have ID as primary key, but their phone numbers as unique constraints to not be duplicates.

// 4- Not Null Constraint: This constraint ensures that a column or set of
// columns cannot contain null (empty) values. This constraint helps to ensure
// that the data is complete and accurate, and it can help prevent errors in queries and calculations
// ex: first name = not null constraint (mandatory to have value), middle name = no problem to allow null (optional) 

// 5- Check Constraint: This constraint ensures that the data in a column or set
// of columns meets a specified condition. This constraint helps to enforce data integrity and prevent invalid data 
// ex: age field to have check constraint to make minimum value allowed is 18 years old 

// IMPORTANT!!!!
// Difference between Primary key and Unique constraints ?
// Primary key is a unique constraint, both prevent duplicates, but the primary key dose not allow null value,
// while unique key allows a null value


namespace _7___What_is_Constraint_and_Why_it_s_Important
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
