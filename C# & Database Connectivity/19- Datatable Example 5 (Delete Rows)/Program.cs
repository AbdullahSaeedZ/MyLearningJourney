using System;
using System.Data;
using System.Linq;
using System.Reflection;

// check documentation for more info 
// https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/datarow-deletion


namespace _15__DataTable_Example_1__Create_Offline_Data_Table_and_ListData_
{
    internal class Program
    {


        static void Main(string[] args)
        {
            DataTable Employees = new DataTable();

            // define the columns
            Employees.Columns.Add("ID", typeof(int));
            Employees.Columns.Add("FirstName", typeof(string));
            Employees.Columns.Add("LastName", typeof(string));
            Employees.Columns.Add("Country", typeof(string));
            Employees.Columns.Add("Salary", typeof(double));
            Employees.Columns.Add("Date", typeof(DateTime));

            // now we add the recoeds
            Employees.Rows.Add(1, "Abdullah", "Alzahrani", "KSA", 24000, DateTime.Now);
            Employees.Rows.Add(2, "Fawaz", "Alzahrani", "KSA", 24054, DateTime.Now);
            Employees.Rows.Add(3, "koko", "Alkoko", "Egypt", 22500, DateTime.Now);
            Employees.Rows.Add(4, "fofo", "Alkfoo", "Lebanon", 5300, DateTime.Now);
            Employees.Rows.Add(5, "dodo", "Aldooo", "USA", 2300, DateTime.Now);

            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", "ID", "FirstName", "LastName", "Country", "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }

            // see docs for other deleting methods
            // get the rows in one array then loop to delete each one:
            // .Select method will return references of the DataTable rows, and will save it in the rowsToDelete, then since we use the reference to access original row, we delete it:
            DataRow[] rowsToDelete = Employees.Select("ID = 4 or ID = 5");
            foreach(DataRow row in rowsToDelete)
            {
                // row.Delete() does NOT remove the row from the DataTable immediately
                // it just marks the rows state as Deleted and wont show up in foreach loops,  row.RowState = Deleted;
                // the row still exists in memory and will be processed as deleted (real deletion) when using DataAdapter.Update() to delete from DB, then DataTable.AcceptChanges() to delete from Table in memory

                row.Delete(); 
            }

            // summary:
            // row.Delete(); to mark as Delete then (in same order):
            // DataAdapter.Update() → reflects changes on the database.
            // DataTable.AcceptChanges() → reflects changes and make the deletion in memory only(DataTable itself).

            Console.WriteLine("\n\nAfter Deleting ID 4 and 5");

            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", "ID", "FirstName", "LastName", "Country", "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }


        }
    }
}