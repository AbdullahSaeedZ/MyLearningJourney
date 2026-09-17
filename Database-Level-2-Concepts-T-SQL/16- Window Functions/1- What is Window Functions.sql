# /*

# WINDOW FUNCTIONS

Problem:

Sometimes we need to calculate a value using multiple related
rows, while still keeping the original rows in the result.

For example, suppose we have this Sales table:

+----------+------+
| Employee | Sale |
+----------+------+
| Ahmed    | 100  |
| Ahmed    | 200  |
| Ahmed    | 300  |
| Mohamed  | 150  |
| Mohamed  | 250  |
+----------+------+

Suppose we want to know the total sales for each employee.

Using GROUP BY:

SELECT Employee, SUM(Sale)
FROM Sales
GROUP BY Employee;

The result would be:

+----------+-----------+
| Employee | SUM(Sale) |
+----------+-----------+
| Ahmed    | 600       |
| Mohamed  | 400       |
+----------+-----------+

This works, but there is a problem:

The individual sales are no longer present.

We lost:

Ahmed   | 100
Ahmed   | 200
Ahmed   | 300
Mohamed | 150
Mohamed | 250

because GROUP BY combines the rows into one row per group.

---

## CORE IDEA

A Window Function allows us to perform a calculation across
multiple related rows WITHOUT combining those rows.

In other words:

"Calculate something using related rows while keeping
the current row."

For example:

SELECT
Employee,
Sale,
SUM(Sale) OVER(PARTITION BY Employee) AS TotalSales
FROM Sales;

Result:

+----------+------+------------+
| Employee | Sale | TotalSales |
+----------+------+------------+
| Ahmed    | 100  | 600        |
| Ahmed    | 200  | 600        |
| Ahmed    | 300  | 600        |
| Mohamed  | 150  | 400        |
| Mohamed  | 250  | 400        |
+----------+------+------------+

Notice that every original row is still present.

The Window Function simply adds a calculated value to each row.

---

## HOW IT WORKS

The general syntax is:

FUNCTION() OVER(...)

The OVER() clause defines the "window" of rows that the
function should operate on.

For example:

SUM(Sale) OVER(PARTITION BY Employee)

PARTITION BY divides the rows into separate windows based
on Employee.

It does NOT combine the rows like GROUP BY does.

For the current row:

Ahmed | 200

The window is:

+----------+------+
| Employee | Sale |
+----------+------+
| Ahmed    | 100  |
| Ahmed    | 200  |
| Ahmed    | 300  |
+----------+------+

So SQL Server calculates:

100 + 200 + 300 = 600

The current row becomes:

Ahmed | 200 | 600

For:

Mohamed | 150

The window is:

+----------+------+
| Employee | Sale |
+----------+------+
| Mohamed  | 150  |
| Mohamed  | 250  |
+----------+------+

So SQL Server calculates:

150 + 250 = 400

The current row becomes:

Mohamed | 150 | 400

---

## WINDOW FUNCTIONS VS GROUP BY

GROUP BY:

+-----------------------------+
| Combines rows into groups   |
| and reduces the result rows |
+-----------------------------+

Window Function:

+--------------------------------------+
| Calculates across related rows      |
| while keeping the original rows     |
+--------------------------------------+

GROUP BY:

SELECT Employee, SUM(Sale)
FROM Sales
GROUP BY Employee;

Result:

+----------+-----------+
| Employee | SUM(Sale) |
+----------+-----------+
| Ahmed    | 600       |
| Mohamed  | 400       |
+----------+-----------+

Window Function:

SELECT
Employee,
Sale,
SUM(Sale) OVER(PARTITION BY Employee) AS TotalSales
FROM Sales;

Result:

+----------+------+------------+
| Employee | Sale | TotalSales |
+----------+------+------------+
| Ahmed    | 100  | 600        |
| Ahmed    | 200  | 600        |
| Ahmed    | 300  | 600        |
| Mohamed  | 150  | 400        |
| Mohamed  | 250  | 400        |
+----------+------+------------+

The key difference:

GROUP BY
-> Combines rows and reduces the number of rows.

Window Function
-> Calculates across rows without reducing the number of rows.

---

## WINDOW FUNCTIONS ARE NOT LIMITED TO SUM

-- Aggregate functions are a part of Window Functions

Common Window Functions include:

SUM(...)
AVG(...)
COUNT(...)
MIN(...)
MAX(...)
ROW_NUMBER(...)
RANK(...)
DENSE_RANK(...)

For example:

SELECT
Name,
Salary,
ROW_NUMBER() OVER(ORDER BY Salary DESC) AS RowNum
FROM Employees;

Result:

+----------+--------+--------+
| Name     | Salary | RowNum |
+----------+--------+--------+
| Ahmed    | 10000  | 1      |
| Mohamed  | 8000   | 2      |
| Ali      | 6000   | 3      |
+----------+--------+--------+

Every employee remains in the result.

The Window Function only adds the calculated row number.

Another example:

SELECT
Name,
Salary,
AVG(Salary) OVER() AS AverageSalary
FROM Employees;

Result:

+----------+--------+---------------+
| Name     | Salary | AverageSalary |
+----------+--------+---------------+
| Ahmed    | 10000  | 8000          |
| Mohamed  | 8000   | 8000          |
| Ali      | 6000   | 8000          |
+----------+--------+---------------+

AVG(Salary) OVER() calculates the average across all rows
because no PARTITION BY was specified.

---

## SIMPLE WAY TO REMEMBER IT

GROUP BY:

"Group the rows."

Window Function:

"Look across the rows while keeping them."

The main purpose of Window Functions is to calculate values
based on other rows without losing the detail of the
original result set.
*/
