namespace _3._1__Exception_thrown_and_handled_in_C_
{
    using System;
    using Microsoft.Data.SqlClient;

    class Program
    {
        private static readonly string connectionString = "Server=.;Database=C21_DB1;Integrated Security=true;TrustServerCertificate=True;";

        static void Main()
        {
            // Test 1: Successful update (positive quantity)
            Console.WriteLine("--- Test 1: Valid Quantity ---");
            UpdateProductStock(1, 50);

            // Test 2: Triggering the custom THROW error (negative quantity)
            Console.WriteLine("\n--- Test 2: Negative Quantity (Will Catch) ---");
            UpdateProductStock(1, -5);
        }

        static void UpdateProductStock(int productId, int newStockQty)
        {
            string sql = @"
            BEGIN TRY
                IF @NewStockQty < 0
                    THROW 51000, 'Stock Quantity Cannot Be Negative.', 1;

                UPDATE Products
                SET StockQuantity = @NewStockQty
                WHERE ProductID = @ProductID;
            END TRY
            BEGIN CATCH
                THROW;
            END CATCH
        ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@NewStockQty", newStockQty);
                command.Parameters.AddWithValue("@ProductID", productId);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Stock updated successfully.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error Number: " + ex.Number);
                    Console.WriteLine("Error Message: " + ex.Message);
                }
            }
        }
    }
}
