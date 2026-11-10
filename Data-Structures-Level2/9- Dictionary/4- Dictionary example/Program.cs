namespace _4__Dictionary_example;

class Program
{
    static void Main(string[] args)
    {
        string fruits = @"Apple  Banana Orange Grape Apple Banana Apple Orange
                          Banana Grape Orange Apple Banana Apple Orange Grape Banana
                          Apple Orange Apple Banana Grape  Orange";

        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        string[] fruitsItems = fruits.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        
        foreach (string item in fruitsItems)
        {
            if (dictionary.ContainsKey(item))
                dictionary[item]++;
            else
            {
                dictionary.Add(item, 1);
            }
        }
        foreach (KeyValuePair<string, int> pair in dictionary)
        {
            Console.WriteLine($"fruit: {pair.Key}, count: {pair.Value}");
        }

        // using LINQ:

        Console.WriteLine("\n\n using LINQ:");
        
        Dictionary<string, int> dictionary1 =                             // define the key    ,     define the value
            fruitsItems.GroupBy(item => item).ToDictionary(g => g.Key, v => v.Count()); 
        
        foreach (KeyValuePair<string, int> pair in dictionary1)
        {
            Console.WriteLine($"fruit: {pair.Key}, count: {pair.Value}");
        }
        
        
    }
}