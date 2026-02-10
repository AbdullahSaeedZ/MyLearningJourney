
/*
 
        +--------------------------------+
        |  DataSet (group of dataTables) |
        |--------------------------------|
        | DataTable1  <- holds table 1   | ---> |DataView1|  (filtered/sorted view of DataTable1)
        | DataTable2  <- holds table 2   | ---> |DataView2|  (filtered/sorted view of DataTable2)
        | DataTable3  <- holds table 3   | ---> |DataView3|  (filtered/sorted view of DataTable3)
        +--------------------------------+
                     ^
                     |
        +-----------------------------+
        |        DataAdapter          |
        |-----------------------------|
        | Fills DataTables from DB    |
        +-----------------------------+



*/

// DataTable represents an in-memory table of data (like a database table or spreadsheet).
// It is part of ADO.NET and stores data in rows and columns.

// Each column has a defined data type (int, string, DateTime, etc.) for type safety.
// Rows represent records; columns represent fields.
// Supports primary keys and constraints and relations to enforce data integrity.
// Data can be added, read, updated, and deleted using rows and column access.
// Commonly used for data binding with UI controls (GridView, ComboBox, etc.).
// Allows filtering, sorting, and basic aggregations (sum, count, average).
// Can be serialized (XML or binary) to save or transfer data.

// dataTables allow us to work with data offline then schinccronize with DB later any time to reflect changes
// but this is a slow process, we rarely use it, most of the time we deal with DB and fetch data with Data readers.
/*
DataTables: act like in-memory tables. You can manipulate, filter, sort, and update data offline.
Later, you can push changes back to the database. Flexible, but slower because it keeps a full copy in memory and tracks changes.

DataReaders: provide a forward-only, read-only stream of data from the database. Extremely fast, minimal memory overhead, but you can’t modify data directly or go backwards.
So the choice is: DataTables for offline or disconnected scenarios, DataReader for fast, read-only operations.

DataAdapter takes data from DB and put it in DataTables then close connection and e do whatever offline.
DataReader takes data from DB and allow us to do read-only and forward-only operations while connection is open, then connection closes with the reader. 
 */



// In-memory means the data is stored in RAM.
// The data exists only while the program is running (runtime).
// DataTable is created and used in RAM, not on disk or in a database.
// When the application closes, the DataTable data is lost.
// Database = persistent storage (disk).
// DataTable = temporary working data in memory (RAM).




// Data Binding means connecting a data source (e.g., DataTable)
// to a UI control (e.g., DataGridView, ListView, ComboBox).

// It allows loading and displaying data in the UI with a single line of code.

// Example: binding a DataTable to a DataGridView automatically displays all rows and columns.

// The same concept applies when binding a DataTable to a ListView or ComboBox (CBCountries).

// Data Binding handles synchronization between the data source and the UI control.
