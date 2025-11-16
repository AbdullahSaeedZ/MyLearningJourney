using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ERD = Entity Relationship Diagram
// ERD is a structural design of the database
// ERD is an approach of making conceptual design of the data base
// it is the blueprint of the data base
// it acts as framework created with symbols to define relationships of database entities


// Main principal components of ERD (see pdf):

// Entities that will be tables. ex: Student , Teachers
// relations between those entities. teachers teach students
// attributes for each entity. student attributes: age, name, ID ... 


// ER Model = Entity-Relationship Model
// represent the structure of the database with help of a diagram
// ER Modelling is a systematic process to design a database as it would require you to analyze all data requirements before implementing your database.


// Example of identifying requirements:

/*
identifying required data in a system:

1) Understand the Domain
   - Know what the system is supposed to do.
   - Example: clothing store, reservation app, hospital system, etc.

2) Identify the Stakeholders
   - Ask who will use the system.
   - What data do they use daily?
   - Who interacts with whom?

3) Identify the Main Entities
   - Extract the core entities from the client's description.
   - Examples: Customer, Order, Product, Invoice, Employee …

4) Identify the Attributes for Each Entity
   - Define what information needs to be stored for each entity.
   - Examples:
       Customer → Name, Phone, Address
       Product → Name, Price, Category
       Order   → Date, TotalAmount

5) Identify the Relationships (explained in next lessons)
   - Determine the type of relationships between entities.
   - Examples:
       Customer ↔ Orders (One to Many)
       Orders ↔ Products (Many to Many)
*/


namespace _10___What_is_ERD_and_Why
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
