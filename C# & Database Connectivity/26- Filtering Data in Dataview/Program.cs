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


            Console.WriteLine("\n\nDataView without filtering");
            DataView View = Employees.DefaultView;
            for (int row = 0; row < View.Count; row++)
            {
                Console.WriteLine("{0} , {1} , {2} , {3} , {4} , {5} ,", View[row][0], View[row][1], View[row][4], View[row][3], View[row][4], View[row][5]);
            }


            Console.WriteLine("\n\nDataView of records where Country = KSA or USA");

            // this is how to filter:
            View.RowFilter = "Country = 'KSA' or Country = 'USA'";
            for (int row = 0; row < View.Count; row++)
            {
                Console.WriteLine("{0} , {1} , {2} , {3} , {4} , {5} ,", View[row][0], View[row][1], View[row][4], View[row][3], View[row][4], View[row][5]);
            }

        }
    }
}