using System.Data;
using Microsoft.Data.SqlClient;
namespace DataLayer
{
    public class EmployeesData
    {
        private static readonly string connectionString = "Server=.;Database=C21_DB1;Integrated Security=true;TrustServerCertificate=True;";

        public static DataTable? GetAllEmployeesWithBonus()
        {
            DataTable? Employees = new DataTable();

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);

                string query = @"select *, 
                                case
	                                when Department = 'Sales' then
		                                case
			                                when PerformanceRating > 90 then Salary * 0.30
			                                when PerformanceRating between 75 and 90 then Salary * 0.25
			                                when PerformanceRating < 75 then Salary * 0.20
			                                else Salary * 0.15
		                                end
	                                when Department = 'HR' then
		                                case
			                                when PerformanceRating > 90 then Salary * 0.20
			                                when PerformanceRating between 75 and 90 then Salary * 0.15
			                                when PerformanceRating < 75 then Salary * 0.10
			                                else Salary * 0.05
		                                end
	                                else
		                                case
			                                when PerformanceRating > 90 then Salary * 0.15
				                                when PerformanceRating between 75 and 90 then Salary * 0.10
				                                when PerformanceRating < 75 then Salary * 0.07
				                                else Salary * 0.03
		                                end
                                end as Bonus
                                from Employees2;";
                using SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    Employees.Load(reader);
                else
                    Employees = null;
            }
            catch (Exception)
            {
                throw;
            }
            return Employees;
        }

        public static bool IncreaseEmployeeSalary(string employeeName, decimal newSalary)
        {
            int rowsAffected = 0;
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);

                string query = @"update Employees2
                                 set Salary = @newSalary
                                 where Name = @employeeName";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newSalary", newSalary);
                command.Parameters.AddWithValue("@employeeName", employeeName);

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected > 0;
        }

        // no percentage control, just for demo
        public static bool IncreaseAllSalaries()
        {
            int rowsAffected = 0;
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);

                string query = @"update Employees2
                                 set Salary =
                                 case 
	                                 when PerformanceRating > 90 then Salary * 1.15
	                                 when PerformanceRating between 75 and 90 then Salary * 1.10
	                                 when PerformanceRating between 50 and 49 then Salary * 1.05
	                                 else Salary
                                 end;";
                using SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected > 0;
        }

        public static DataTable? GetAllEmployees()
        {
            DataTable? Employees = new DataTable();

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);

                string query = @"select * from Employees2";
                using SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    Employees.Load(reader);
                else
                    Employees = null;
            }
            catch (Exception)
            {
                throw;
            }
            return Employees;
        }
    }
}