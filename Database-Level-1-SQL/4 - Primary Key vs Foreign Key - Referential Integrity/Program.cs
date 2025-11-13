using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// A primary key is a column or set of columns in a relational database table that uniquely identifies each row or record in the table.
// Primary Key is a unique identifier for each record and serves as a reference point for other tables that have a relationship with the table in question.
// Each table in a relational database must have a primary key, and it should be a non-null value that is unique and stable over time.

// example table of employees, each record has ID number, in this case the ID is a primary key cuz it is not repeated, each employee has his own unique ID number.
// meaning we cant have two employees with same ID number.

// a primary key:
// - must be unique (not repeated)
// - must not be null at all 
// - better to be in numbers not string
// - must be stable, not changed, other tables and data will be linked to it

// in theory, we can make for example the id + first name + last name as primary key, which is unique
// but this is too long and kind of hard to deal with, so better to stick with simple or short primary key such as ID number

// Primary key is better to be a number not a string, when searching, better search by ID than search by Department name for example.




// A foreign key, on the other hand, is a column or set of columns in a table that refers to the primary key of another table.
// Foreign Key establishes a relationship between two tables, allowing data to be shared and linked between them.

// foreign key is what connects relations of tables
// in the pdf, Departments table has ID primary key, this primary key becomes a foreign key in the Employee table.
// so the departmentID is a foreign key cuz it is a reference to the primary key of another table.
// Value in the foreign key column must exist in the primary key column of the related table.


/*
    Referential Integrity:
    - A rule in relational databases that keeps relationships between tables valid.
    - It ensures that a foreign key value must always point to an existing primary key value.
    - Meaning: you CANNOT insert a foreign key value that doesn't exist in the parent table.
    - It also prevents deleting a primary key row if there are still foreign key rows depending on it,
      unless cascading rules allow it.
    - Purpose: prevent broken links, orphan records, and inconsistent relationships.
*/


// In summary, a primary key uniquely identifies a record in a table, while a foreign key establishes a relationship between two tables by referencing the primary key of another table.


namespace _4___Primary_Key_vs_Foreign_Key___Referential_Integrity
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
