using System;
using System.Data;
using System.Linq;


namespace _15__DataTable_Example_1__Create_Offline_Data_Table_and_ListData_
{
    internal class Program
    {


        static void Main(string[] args)
        {
            DataTable Employees = new DataTable();

            // we can create a column object to put all constraints then add it separately to the table.
            // following will make ID as PK:
            DataColumn IDcolumn = new DataColumn();
            IDcolumn.DataType = typeof(int);
            IDcolumn.ColumnName = "ID";
            IDcolumn.AllowDBNull = false;
            IDcolumn.AutoIncrement = true;
            IDcolumn.AutoIncrementSeed = 1;
            IDcolumn.AutoIncrementStep = 1;
            IDcolumn.Unique = true;
            IDcolumn.Caption = "EmpID"; // this is like a nickname
            IDcolumn.ReadOnly = true;

            Employees.Columns.Add(IDcolumn);

            // define the columns
            Employees.Columns.Add("FirstName", typeof(string));
            Employees.Columns.Add("LastName", typeof(string));
            Employees.Columns.Add("Salary", typeof(double));
            Employees.Columns.Add("Date", typeof(DateTime));
            // Employees.Columns.Add("Email", typeof(string)).AllowDBNull = false;     we can add constraints this way


            // now we add the records
            // use null to indicate that this field will be auto incremented
            Employees.Rows.Add(null, "Abdullah", "Alzahrani", 24000, DateTime.Now);
            Employees.Rows.Add(null, "Fawaz", "Alzahrani", 24054, DateTime.Now);
            Employees.Rows.Add(null, "koko", "Alkoko", 22000, DateTime.Now);

            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | ", "ID", "FirstName", "LastName",  "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} |", record["ID"], record["FirstName"], record["LastName"],  record["Salary"], record["Date"]);
            }


         

        }
    }
}