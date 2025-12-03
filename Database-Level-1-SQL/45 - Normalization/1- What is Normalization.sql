-- What is Normalization?

-- see pdf

/*
Normalization = organizing database tables to reduce redundancy
and improve data consistency.

Main idea:
- Break big messy tables into smaller logical tables.
- Remove repeated or duplicated data.
- Make the data clean and consistent.

Why do we normalize?
- To avoid data anomalies (duplicate or inconsistent data).
- To make updates easier.
- To improve query efficiency.

Simple examples:
1) Bad table (not normalized):
   Student(ID, Name, Course1, Course2, Course3)
   -> Courses repeated in columns = redundancy.

2) Good normalized design:
   Students(ID, Name)
   Courses(CourseID, CourseName)
   Enrollments(EnrollID, StudentID, CourseID)
   -> No duplicates, easier to update.

3) Bad data consistency example:
   TotalItems = 100 but itemsAmount = 120
   -> Normalization helps avoid this mismatch.

Normalization uses rules called "Normal Forms":
1NF → no repeating groups
2NF → remove partial dependencies
3NF → remove non-key dependencies
and more in next lessons


Goal:
- Cleaner structure
- No duplicated data
- Reliable and consistent database
*/





/*
Data Consistency = the data does not contradict itself.
Example:
- Every foreign key value must exist in the parent table.
- Totals must match their detailed items.
- No impossible values (e.g., negative salaries).
Consistent data = reliable, accurate, and logically correct.
*/

