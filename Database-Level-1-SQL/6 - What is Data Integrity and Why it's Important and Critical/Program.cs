using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// data migration = moving data from old system to a new one

// Data integrity (سلامة البيانات) = accuracy, consistency, and reliability of data over its entire life cycle from creation, updating and to deletion
// in other word, it is ensuring that data is complete, correct and accurate.
// we enforce it when we design the data base


// several factors that can impact data integrity, including human error, hardware or software failure, security breaches, and data transfer errors

// to maintain data integrity, it is important to establish appropriate policies and procedures, and to implement appropriate technologies, such as encryption, backups, and access controls.


// types of data integrity that organizations need to consider:

// Entity integrity: This ensures that each row or record in a table is unique and
// can be uniquely identified. This is typically achieved through the use of primary keys.

// Referential integrity: This ensures that relationships between tables are
// maintained and that there are no orphaned records(doesnt belong to a relational table). This is typically achieved through the use of foreign key

// Domain integrity (Validation): This ensures that data is within acceptable ranges or values.
// For example, a date field should only contain valid dates, and a numeric field should only contain valid numbers.


// Business integrity: This ensures that data meets business rules and
// requirements. For example, a bank might have rules around minimum and maximum
// account balances, or a hospital might have rules around patient data confidentiality.




//  Maintaining data integrity is critical for organizations that rely on accurate and trustworthy data to make informed decisions. Without data
// integrity, organizations risk making decisions based on incomplete,
// inaccurate, or unreliable data, which can lead to poor outcomes, financial losses, and damage to reputation.

// To maintain data integrity we use Constraints





namespace _6___What_is_Data_Integrity_and_Why_it_s_Important_and_Critical
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
