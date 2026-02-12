using System;
using System.Data;


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

            // now we add the records
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


            Console.WriteLine("\n\nDataView:");

            // each DataTable created, a Default View will be created along, 

            DataView view = Employees.DefaultView;
            for (int row = 0; row < view.Count; row++)
            {
                // DataView holds references (indexes) to rows, not the data itself.
                Console.WriteLine("{0} , {1} , {2} , {3} , {4} , {5}", view[row][0], view[row][1], view[row][2], view[row][3], view[row][4], view[row][5]);
            }


            // or:
            foreach(DataRowView row in view)
            {
                Console.WriteLine("{0} , {1} , {2} , {3} , {4} , {5}", row["ID"], row["FirstName"], row["LastName"], row["Country"], row["Salary"], row["Date"]);
            }



        }
    }
}