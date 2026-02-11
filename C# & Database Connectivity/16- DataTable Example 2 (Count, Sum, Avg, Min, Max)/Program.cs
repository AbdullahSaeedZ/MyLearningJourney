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
            Employees.Columns.Add("Salary", typeof(double));
            Employees.Columns.Add("Date", typeof(DateTime));

            // now we add the recoeds
            Employees.Rows.Add(1, "Abdullah", "Alzahrani", 24000, DateTime.Now);
            Employees.Rows.Add(2, "Fawaz", "Alzahrani", 24054, DateTime.Now);
            Employees.Rows.Add(3, "koko", "Alkoko", 22000, DateTime.Now);

            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", "ID", "FirstName", "LastName", "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", record["ID"], record["FirstName"], record["LastName"], record["Salary"], record["Date"]);
                // Console.WriteLine($" {record[0]}   {record[1]}   {record[2]}   {record[3]}  {record[4]}");   can use index, but use column name for better readability
            }


            // To use aggregate functions, we use the Compute method provided by DataTable (ADO.NET)
            // DataTable.Compute( the function ,  filters or where clause)

            Console.WriteLine("\n\ncount of Employees: " + Employees.Rows.Count);
            Console.WriteLine("sum of Salaries: " + (double)Employees.Compute("sum(Salary)", ""));
            Console.WriteLine("average of Salaries: " + (double)Employees.Compute("avg(Salary)", ""));
            Console.WriteLine("min of Salaries: " + (double)Employees.Compute("min(Salary)", ""));
            Console.WriteLine("max of Salaries: " + (double)Employees.Compute("max(Salary)", ""));



        }
    }
}