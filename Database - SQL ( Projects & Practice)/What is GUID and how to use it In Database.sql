-- What is GUID? and how to use it In Database?

/*
 * A GUID (Globally Unique Identifier), also known as UUID (Universally Unique Identifier), 
   is a 128-bit value that is used to uniquely identify objects or entities. 
   It is designed to be globally unique across all devices and systems.

 * A GUID consists of five groups of characters, typically represented as a 
   string of hexadecimal digits separated by hyphens. For example, a GUID may 
   look like this:  6F9619FF-8B86-D011-B42D-00C04FC964FF
 */

 /*
 * The uniqueness of a GUID is achieved by combining various components such 
 * as the MAC address of the network card, the current timestamp, and random 
 * bits. This combination ensures a very low probability of generating 
 * duplicate GUIDs.
 * * The chances of generating the same GUID twice are extremely small, even 
 * when multiple devices are generating GUIDs simultaneously. The sheer size 
 * of the 128-bit space allows for an astronomically large number of unique 
 * combinations, making collisions (two GUIDs being the same) highly unlikely.
 */


 -- lets say we have a table with exam questions and we need to shuffle the questions in every exam.
 -- we can use GUID by creating them using NewID() function:

 use HR_Database;

 select * from Employees;

 -- to make the table shorter, we take top 10 records in subquery then shuffle them:
 select top 10 * from Employees;


 -- each row will be assigned a GUID, then the ORDER BY will order the rows based on those GUIDS 
 -- which are randomly generated everytime we do the query which will result in shuffled records.
 select * from (select top 10 * from Employees) as random order by NEWID();




 -- run this to see how they are assigned random GUIDs everytime
  select NEWID(), * from (select top 10 * from Employees) as random order by NEWID();