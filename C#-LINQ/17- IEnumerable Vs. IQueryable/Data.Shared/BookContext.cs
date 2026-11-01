
using Microsoft.EntityFrameworkCore;
namespace Data.Shared;

/*
 * BookContext:
 * 1. Inherits from DbContext so EF Core can manage the database connection and map queries to SQL.
 * 2. Instantiating this class creates our active gateway to interact with the database in code.
 * 3. 'DbSet<Book> Books' acts as the database table entry point for LINQ queries.
 * 4. 'OnConfiguring' configures the SQL Server provider and connection parameters.
 * will be explained in depth in EF core course
 */

// sql script to create the db and table will be provided in the same solution

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD") ?? "Missing_Password";
        optionsBuilder.UseSqlServer(
            $"Server=localhost,1433;Database=bookstore;User Id=sa;Password={password};TrustServerCertificate=True;"
        );
    }
}