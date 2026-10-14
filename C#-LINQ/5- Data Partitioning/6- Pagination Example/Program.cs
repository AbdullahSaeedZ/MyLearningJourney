using DataPartitioning.Shared;

namespace _6__Pagination_Example;

class Program
{
    static void Main(string[] args)
    {
        const int recordsPerPage = 10;

        var employees = Repository.LoadEmployees();
        var totalRecords = employees.Count();
        var totalPages = (int)Math.Ceiling((decimal)totalRecords / recordsPerPage);

        var userNextPage = 1; // starting with page number 1
        do
        {
            var recordsToShow = employees.Paginate(userNextPage, recordsPerPage); // <- this is the pagination extension method in extensions class
            
            Console.WriteLine("\n\n");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Total Records: {totalRecords}");
            Console.WriteLine($"Records Shown: {recordsToShow.Count}");
            Console.WriteLine($"Current Page: {userNextPage}");
            Console.WriteLine(new string('-', 40));
            
            foreach (Employee empRecord in recordsToShow) 
            {
                Console.WriteLine(empRecord);
            }
            Console.WriteLine(new string('-', 40));

            Console.Write("Pages: ");
            for (int i = 1; i <= totalPages; i++)
            {
                if (i == userNextPage)
                {
                    Console.Write($"--[{i}]-- ");
                    continue;
                }
                Console.Write($"[{i}] ");
            }

            Console.WriteLine("\nEnter Page Number (press any other key to exit)");
            if (int.TryParse(Console.ReadLine(), out int input))
                userNextPage = input;
            else
                userNextPage = -1;
            
        } while (userNextPage <= totalPages && userNextPage >= 1);
       

    }
}