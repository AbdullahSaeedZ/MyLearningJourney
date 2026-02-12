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

            // table 1
            Employees.Columns.Add("ID", typeof(int));
            Employees.Columns.Add("FirstName", typeof(string));
            Employees.Columns.Add("LastName", typeof(string));
            Employees.Columns.Add("Country", typeof(string));
            Employees.Columns.Add("Salary", typeof(double));
            Employees.Columns.Add("Date", typeof(DateTime));

            Employees.Rows.Add(1, "Abdullah", "Alzahrani", "KSA", 24000, DateTime.Now);
            Employees.Rows.Add(2, "Fawaz", "Alzahrani", "KSA", 24054, DateTime.Now);
            Employees.Rows.Add(3, "koko", "Alkoko", "Egypt", 22500, DateTime.Now);


            // table 2:
            DataTable Departments = new DataTable();
            Departments.Columns.Add("ID", typeof(int));
            Departments.Columns.Add("Name", typeof(string));

            Departments.Rows.Add(1, "IT");
            Departments.Rows.Add(2, "Marketing");
            Departments.Rows.Add(3, "HR");



            // printing Tables separately:

            Console.WriteLine("Employees List:");
            Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", "ID", "FirstName", "LastName", "Country", "Salary", "Date");
            foreach (DataRow record in Employees.Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }

            Console.WriteLine("\n\n Departments List:");
            Console.WriteLine("{0, -2} | {1, -10} ", "ID", "Name");
            foreach (DataRow record in Departments.Rows)
            {
                Console.WriteLine("{0, -2} | {1, -10}", record["ID"], record["Name"]);
            }

            // --------------------------------- Data sets:

            // creating the dataSet and adding the dataTables:
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(Employees);
            dataSet.Tables.Add(Departments);

            // now we access the dataSet and print the records of table 1 using index (next lesson for accessing tables using names)
            Console.WriteLine("\n\nDataSet: Employees List:");
            foreach (DataRow record in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(" {0, -2} | {1, -10} | {2, -10} | {3, -10} | {4, -10} | {5, -10}", record["ID"], record["FirstName"], record["LastName"], record["Country"], record["Salary"], record["Date"]);
            }

            Console.WriteLine("\n\nDataSet: Departments List:");
            foreach (DataRow record in dataSet.Tables[1].Rows)
            {
                Console.WriteLine("{0, -2} | {1, -10}", record["ID"], record["Name"]);
            }

        }
    }
}
