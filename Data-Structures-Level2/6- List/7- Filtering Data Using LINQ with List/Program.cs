namespace _7__Filtering_Data_Using_LINQ_with_List;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        // filtering with LINQ Where function:
        Console.WriteLine("Even Numbers:\n" + string.Join(", ",  numbers.Where(number => number % 2 == 0)) );
        Console.WriteLine("Odd Numbers:\n" + string.Join(", ",  numbers.Where(number => number % 2 != 0)));
        Console.WriteLine("Numbers greater than 5:\n" + string.Join(", ",  numbers.Where(number => number > 5)));
        Console.WriteLine("Numbers between 3 and 8:\n" + string.Join(", ",  numbers.Where(number => number >= 3 && number <= 8)));
        
        // using an overload of Where (value, index)
        Console.WriteLine("Every second Numbers:\n" + string.Join(", ",  numbers.Where((number, index) => index % 2 != 0)));
    }
}