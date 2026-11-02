namespace Shared;
using System.Linq;
using System.Collections.Generic;

public static class Extensions
{
    private static Random random = new Random();
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
        {
            if (typeof(T).IsValueType)
                Console.Write($" {item} "); // 1, 2, 3
            else
                Console.WriteLine(item);
        } 
    }

    // this way we keep deferred execution of enumerables while doing custom linq extension methods
    public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> source, int page = 1, int size = 10)
    {
        // basic checks
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (page < 0)
            page = 1;

        if (size < 0)
            size = 10;

        int offset = (page - 1) * size;
        return source.Skip(offset).Take(size);
    }
    
    // another way is to allow nulls
    public static IEnumerable<TSource> Paginate2<TSource>(this IEnumerable<TSource> source, int? page, int? size)
    {
        // basic checks
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (!page.HasValue)
            page = 1;

        if (!size.HasValue)
            size = 10;

        int offset = (page.Value - 1) * size.Value;
        return source.Skip(offset).Take(size.Value);
    }
    
    // allowing custom extensions with lambdas as predicate
    public static IEnumerable<TSource> WhereWithPaginate<TSource>(this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        int? page, int? size)
    {
        // basic checks
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        // reuse above method to do the checks and pagination
        IEnumerable<TSource> filteredSource = source.Where(predicate);
        return filteredSource.Paginate2(page, size);
    }
    
    // to get random item from a filtered collection
    public static TSource RandomItem<TSource>(this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        // basic checks
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        // reuse above method to do the checks and pagination
        IEnumerable<TSource> filteredSource = source.Where(predicate);
        return filteredSource.ElementAt(random.Next(0, filteredSource.Count()));
    }
    
}