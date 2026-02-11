using System;
using System.Data;
using System.Linq;

// sorting in DataTable is slow cuz it has to reorder the original table in the memory by deleting and adding rows manually
// sorting in DataView is faster cuz it will just point to the original rows indexes in different order to sort

// DataTable holds the original data.
// The order of rows is fixed based on insertion and does NOT change when sorting.

// DataView is a view layer on top of the DataTable.
// It acts like a lens that shows the same data in a different order.

// Sorting does NOT move or reorder rows inside the DataTable.
// Sorting only rearranges indexes that point to the original rows.

// If you want to actually change the physical order of rows in DataTable.Rows:
// 1) Create a new DataTable and insert rows in the desired order
// OR
// 2) Clear the table and reinsert rows in the new order

// Otherwise, the original row order in the DataTable always remains unchanged.


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

            // now we add the recoقds
            Employees.Rows.Add(1, "Abdullah", "Alzahrani", "KSA", 24000, DateTime.Now);
            Employees.Rows.Add(2, "Fawaz", "Alzahrani", "KSA", 24054, DateTime.Now);
            Employees.Rows.Add(3, "koko", "Alkoko", "Egypt", 22500, DateTime.Now);
            Employees.Rows.Add(4, "fofo", "Alkfoo", "Lebanon", 5300, DateTime.Now);
            Employees.Rows.Add(5, "dodo", "Aldooo", "USA", 2300, DateTime.Now);

            //-----------------------------------------------------------------------------------------
            // Normal Table

            Console.WriteLine("Employees List:\n");
            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", "ID", "FirstName", "LastName", "Country", "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }


          

            // sort by ID Desc:
            Employees.DefaultView.Sort = "ID desc";
            Employees = Employees.DefaultView.ToTable();

            Console.WriteLine("\nEmployees List sorted by ID Desc:\n");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }


            /*
               Employees is the name of the original table
               DefaultView is not a table—it's just a view
               ToTable() creates a new DataTable
               The variable Employees now points to that new table
               The original table disappears because it no longer has any reference pointing to it (By garbage Collector)
            */


            // sort by FirstName asc:
            Employees.DefaultView.Sort = "FirstName asc";
            Employees = Employees.DefaultView.ToTable();

            Console.WriteLine("\nEmployees List sorted by FirstName asc:\n");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }

        }
    }
}