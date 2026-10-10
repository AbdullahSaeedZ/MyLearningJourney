namespace _3__Functional_Approach;

// this is just enhancing the methods, by using extension methods, to attach the methods we created to particular types

public static class EnhancedFunctionalOperations
{
    // now any IEnumerable<Employee> will see this method
    public static IEnumerable<Employee> Filter(this IEnumerable<Employee> source, Func<Employee, bool> criteria)
    {
        foreach (var employee in source)
        {
            if (criteria(employee)) 
            {
                yield return employee;
            }
        }
    }

    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        if (source == null)
            return;
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        Console.WriteLine();
        foreach (var item in source)
            Console.WriteLine(item);
    }
}