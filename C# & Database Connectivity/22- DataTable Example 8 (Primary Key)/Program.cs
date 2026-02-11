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

            // define the columns
            Employees.Columns.Add("ID", typeof(int));
            Employees.Columns.Add("FirstName", typeof(string));
            Employees.Columns.Add("LastName", typeof(string));
            Employees.Columns.Add("Country", typeof(string));
            Employees.Columns.Add("Salary", typeof(double));
            Employees.Columns.Add("Date", typeof(DateTime));

            // assign ID column as PK:
            DataColumn[] PKs = new DataColumn[1];  // PK can consist of many columns , thats why we make an array for them with their number in [];
            PKs[0] = Employees.Columns["ID"];     // add the needed columns to be PK.
            Employees.PrimaryKey = PKs;          // the PrimaryKey is an array of DataColumn, which means it takes only an array.


            // a short way:
            // Employees.PrimaryKey = new DataColumn[] { Employees.Columns["ID"] };



            // now we add the records
            Employees.Rows.Add(1, "Abdullah", "Alzahrani", "KSA", 24000, DateTime.Now);
            Employees.Rows.Add(1, "Fawaz", "Alzahrani", "KSA", 24054, DateTime.Now);     // add this row with duplicate ID number, will throw exception
            Employees.Rows.Add(3, "koko", "Alkoko", "Egypt", 22500, DateTime.Now);
            Employees.Rows.Add(4, "fofo", "Alkfoo", "Lebanon", 5300, DateTime.Now);
            Employees.Rows.Add(5, "dodo", "Aldooo", "USA", 2300, DateTime.Now);

            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", "ID", "FirstName", "LastName", "Country", "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }



        }
    }
}