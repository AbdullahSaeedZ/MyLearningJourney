/*
================================================================================
LESSON 0: PROJECTION OPERATIONS — THE HIGH-LEVEL OVERVIEW
================================================================================

1. THE PROBLEM
--------------------------------------------------------------------------------
Domain entities are large and heavy (e.g., an Employee with 20+ properties:
Id, SSN, Salary, Address, MedicalRecords).

Passing full entities everywhere causes:
- Memory Waste: Holding unneeded data in RAM.
- Over-fetching: Exposing sensitive data (SSN, Salary) to APIs or UI screens.
- Incompatible Shapes: Callers often need calculated or combined values 
  (FullName, Tax) that do not exist on the base entity.


2. THE SOLUTION & FORMAL DEFINITION
--------------------------------------------------------------------------------
Source: Microsoft .NET Documentation

"Projection refers to the operation of transforming an object into a new form
that often consists only of those properties that will be subsequently used."

SQL Analogy:
  SELECT FirstName, Salary * 0.10 AS Tax FROM Employees;
  (Instead of pulling every single table column via SELECT *)
  returning another form of result, from a source of info


3. PREREQUISITE: WHAT IS A DTO?
--------------------------------------------------------------------------------
DTO = Data Transfer Object.

- What it is: A plain class/record containing ONLY properties (no logic, no methods).
- Why it exists: An envelope to transport exactly the data needed between 
  layers (e.g., Database -> UI/API) without exposing internal entity models.

+------------------------------------+           +----------------------------+
| Full Entity (Employee)             |           | DTO (EmployeeDto)          |
+------------------------------------+           +----------------------------+
| - Id: 101                          |           |                            |
| - FirstName: "Sara"                | --------> | - FullName: "Sara Omar"    |
| - LastName: "Omar"                 |  Project  | - Salary: 5000             |
| - SSN: "123-45-XXXX"  (Hidden)     |           |                            |
| - PasswordHash: "..." (Hidden)     |           +----------------------------+
+------------------------------------+


4. THE 3 TARGET OUTPUT SHAPES
--------------------------------------------------------------------------------
Every projection method produces one of three shapes:
1. Scalar Value:   A single primitive or calculated value (string, int, decimal).
2. Custom DTO:     A dedicated, strongly typed model (class / record).
3. Anonymous Type: A temporary, inline compiler-generated shape (new { ... }).


5. THE 3 PROJECTION METHODS (ROADMAP)
--------------------------------------------------------------------------------

[ METHOD 1: .Select() ] — 1-to-1 Element Transformation
 ------- Maps each input element to exactly one output shape -------
Cardinality: N In -> N Out

  Input:     [ Employee 1 ]       [ Employee 2 ]
                   |                    |
  Tool:        .Select()            .Select()
                   |                    |
  Output:    [ Result 1 ]         [ Result 2 ]
             (Can produce Scalar, DTO, or Anonymous Type)

--------------------------------------------------------------------------------
[ METHOD 2: .SelectMany() ] — 1-to-Many Flattening
------- Unpacks nested child collections and flattens them into a single stream ------- 
Cardinality: N In -> M Out

  Input:     [ Emp 1: {C#, SQL} ]     [ Emp 2: {Linux} ]
                     \                      /
  Tool:               \---- .SelectMany() -/
                               |
  Output:            [ C#,   SQL,   Linux ]

--------------------------------------------------------------------------------
[ METHOD 3: .Zip() ] — 2-to-1 Pairwise Merge
------- Combines two separate sequences pair-by-pair based on their matching index ------- 
Cardinality: (Sequence A + Sequence B) -> 1 Combined Sequence

  List A:    [ "Sara" ]            [ "Sami" ]
                 \                    /
  Tool:           \----- .Zip() -----/
                 /                    \
  List B:    [ "IT"   ]            [ "HR"   ]
                 |                    |
  Output:    [ "Sara: IT" ]        [ "Sami: HR" ]

================================================================================
UPCOMING LESSON TRACKS:
- Lesson 1: .Select() Deep Dive (Scalar, DTO, Anonymous Types, Indexed Overload)
- Lesson 2: .SelectMany() Deep Dive (Flattening Collections, Parent-Child Tracking)
- Lesson 3: .Zip() Deep Dive (Pairwise Merging, Unequal Lengths, Tuples)
================================================================================
*/