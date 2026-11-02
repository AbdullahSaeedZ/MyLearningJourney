using Shared;
namespace _1__Custom_LINQ_Extension;

class Program
{
    static void Main(string[] args)
    {
        // check Extensions class
        
        IEnumerable<Employee> list = Repository.Employees;

        IEnumerable<Employee> page2x4 = list.Paginate(2, 4);
        page2x4.Print("page #2  [4 emps]");
        
        IEnumerable<Employee> page1Default = list.Paginate();
        page1Default.Print("page #1 (Default) [10 emps]");
        
        IEnumerable<Employee> page1Nulls = list.Paginate2(null, 5);
        page1Nulls.Print("page #1 (null)  [5 emps]");
        
        IEnumerable<Employee> page1x4EmpsWithInsurance = list.WhereWithPaginate(x => x.HasHealthInsurance, 1, 4);
        page1x4EmpsWithInsurance.Print("page #1  [4 emps] With Insurance Only");
        
        Employee filteredRandomEmployee = list.RandomItem(x => x.HasPensionPlan);
        Console.WriteLine("\n\nfiltered random employee");
        Console.WriteLine(filteredRandomEmployee);
        
        
        


    }
}