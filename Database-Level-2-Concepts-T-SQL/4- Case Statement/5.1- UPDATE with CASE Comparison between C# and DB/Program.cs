using DataLayer;
using System.Data;
using System.Diagnostics;
namespace _5._1__UPDATE_Comparison_between_C__and_DB
{
    internal class Program
    {
        // this is just to compare execution performance between one employee at a time update with logic and eveything in C#
        // vs executing a single bulk update directly in the database
        static void Main(string[] args)
        {
            DataTable? employees = EmployeesData.GetAllEmployees();

            Console.WriteLine("Before Updating the Salaries:\n");
            PrintAllEmployees(employees);

            // small portion of the time elapsed will be caused by connection initialization in first time,
            // next attempt will be using the ready resources, 
            //-------------------------one employee at a time-------------------------------------
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IncreaseOneEmployeeAtATime(employees);
            sw.Stop();


            employees = EmployeesData.GetAllEmployees();
            Console.WriteLine("\n\nAfter Updating one employee at a time:");
            Console.WriteLine($"Time Taken: {sw.ElapsedMilliseconds}ms");
            PrintAllEmployees(employees);

            //-------------------------all at once using CASE statement-------------------------------------

            sw.Reset();
            sw.Start();
            EmployeesData.IncreaseAllSalaries();
            sw.Stop();

            employees = EmployeesData.GetAllEmployees();
            Console.WriteLine("\n\nAfter Updating in DB:");
            Console.WriteLine($"Time Taken: {sw.ElapsedMilliseconds}ms");
            PrintAllEmployees(employees);
        }


        public static void IncreaseOneEmployeeAtATime(DataTable? employees)
        {
            if (employees == null)
            {
                Console.WriteLine("No Data Available");
                return;
            }

            int performanceRating = 0;
            int salary = 0;
            double newSalary = 0;
            foreach (DataRow item in employees.Rows)
            {
                performanceRating = (int)item["PerformanceRating"];
                salary = (int)item["Salary"];

                if (performanceRating > 90)
                    newSalary = salary * 1.15;
                else if (performanceRating > 75 && performanceRating < 90)
                    newSalary = salary * 1.10;
                else if (performanceRating > 50 && performanceRating < 74)
                    newSalary = salary * 1.05;
                else
                    newSalary = salary;

                // see how many db calls!
                if (!EmployeesData.IncreaseEmployeeSalary((string)item["Name"], (int)newSalary))
                {
                    Console.WriteLine("error in IncreaseOneEmployeeAtATime");
                    return;
                }
            }
        }


        public static void PrintAllEmployees(DataTable? employees)
        {
            if (employees == null)
            {
                Console.WriteLine("No Data Available");
                return;
            }

            Console.WriteLine($"{"Name",-13}| {"Department",-12}| {"Salary",-12}| {"Performance Rating",-12}");
            Console.WriteLine("______________________________________________________________");
            foreach (DataRow item in employees.Rows)
            {
                Console.WriteLine($"{item["Name"],-13}| {item["Department"],-12}| {item["Salary"],-12}| {item["PerformanceRating"],-12}");
            }

        }

    }
}


