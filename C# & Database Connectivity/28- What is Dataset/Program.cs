
/*
 A dataset can be thought of as a container that holds one or more DataTable
objects, which in turn represent tables of data.

• DataSet is a disconnected architecture it represents the data in table
structure which means the data into rows and columns.

• Dataset is the local copy of your database which exists in the local
system.

• DataSet works like a real database with an entire set of data which
includes the constraints, relationship among tables, and so on. It will be
found in the namespace “System. Data”.

• In scenarios where you are working with a large amount of data, datasets
may not be the most efficient option. In such cases, using alternatives
like DataReader, which retrieves data in a forward-only and read-only
manner, can be more efficient as they minimize memory consumption and
provide faster access to data.
 

------- relying on Datasets and disconnected mode is not reliable and efficient especially with large databases
 */

// DataSet:
// - An in-memory, disconnected container for structured data.
// - Part of ADO.NET.
// - Can hold multiple DataTable objects.
// - Each DataTable contains:
//     - DataColumn (schema definition)
//     - DataRow (actual data)

// Key idea:
// - DataSet = container of DataTables (like a mini in-memory database).
// - Works independently after loading data from the database.

// Disconnected model:
// - Data is loaded into memory (RAM).
// - You can modify it offline.
// - Later, changes can be synchronized back to the database.

// Performance notes:
// - Heavier than DataReader.
// - More memory usage due to full in-memory storage.
// - Slower for large datasets because of load + sync overhead.

// Comparison:
// - DataSet → flexible, relational, supports multiple tables.
// - DataReader → fast, forward-only, read-only, minimal memory usage.

// Rule of thumb:
// - Need multiple tables, relations, offline edits → DataSet.
// - Need fast, read-only streaming of large data → DataReader.

// --------------------------------------------------  