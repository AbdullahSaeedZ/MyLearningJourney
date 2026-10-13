namespace _6__Pagination_Example;

public static class Extensions
{
    public static List<T> Paginate<T>(this IEnumerable<T> source, int page, int size) where T : class
    {
        if (page <= 0) page = 1;
        if (size <= 0) size = 10;
        
        // page 3 and size 10, means records from 20 to 30
        var offset = size * (page - 1); // 10 * (3 - 1) 
        return source.Skip(offset).Take(size).ToList();
    }
}