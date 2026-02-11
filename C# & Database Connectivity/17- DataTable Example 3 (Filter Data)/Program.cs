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


            // To use aggregate functions, we use the Compute method provided by DataTable (ADO.NET)
            // DataTable.Compute( the function ,  filters or where clause)

            // applying filters with aggregate functions:
            Console.WriteLine("\n\ncount of Employees: " + Employees.Rows.Count);
            Console.WriteLine("sum of Salaries: " + (double)Employees.Compute("sum(Salary)", "Country = 'KSA' or Country = 'USA'"));
            Console.WriteLine("average of Salaries: " + (double)Employees.Compute("avg(Salary)", "Salary <= 22500"));
            Console.WriteLine("min of Salaries: " + (double)Employees.Compute("min(Salary)", "Country <> 'USA'"));
            Console.WriteLine("max of Salaries: " + (double)Employees.Compute("max(Salary)", ""));

            Console.WriteLine();
            Console.WriteLine();

            // fetching rows with conditions:
            DataRow[] FilteredRows = Employees.Select("Country = 'KSA'");

            foreach (DataRow record in FilteredRows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }



        }
    }
}