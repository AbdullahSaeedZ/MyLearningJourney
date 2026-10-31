namespace Sets.Shared;

public static class Extension
{
    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\n{title}\n");
        Console.ForegroundColor = defaultColor;

        foreach (T item in source)
        {
            Console.WriteLine($"{item}");
        }
    }
}