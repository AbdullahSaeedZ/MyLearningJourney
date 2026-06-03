namespace _3._1__Named_Functions_vs_Lambda_Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             =====================================  Named Functions vs. Lambda Expressions ================================
            Let's talk about when to use named functions and when to use lambda expressions, and also touch on the performance aspect.

            Named Functions:
            1.Readability and Reusability:
            Use named functions when the logic is complex or when the operation needs to be reused in multiple places. Named functions can enhance code readability and maintainability.
            */
            int Square(int num)
            {
                return num * num;
            }

            // Usage:
            int result = Square(5);
            Console.WriteLine("Square of number: " + result);


            // 2 .Clear Intent:
            // If the function's purpose is clear from its name, using a named function is often a good choice. It makes your code self-documenting.
            // Lambda Expressions:
            // Conciseness:
            // Use lambda expressions for short, simple operations, especially when the logic is straightforward and doesn't need a separate named function. They shine in scenarios where brevity is essential.

            // Lambda expression for squaring a number
            Func<int, int> square = (int num) => num * num;

            //Usage:
            int result1 = square(5);
            Console.WriteLine("Square of number: " + result1);


            // Inline Usage: If the function is used inline, for example, in LINQ queries or event handling, lambda expressions can be more convenient.
            // Using lambda in LINQ
            //      var evenNumbers = numbers.Where(n => n % 2 == 0);


            // Using lambda in event handling
            //      button.Click += (sender, e) => Console.WriteLine("Button clicked!");

            /*
            Performance Considerations:
            In terms of performance, the difference between named functions and lambda expressions is usually negligible. Both can be optimized by the compiler. 
            The choice between them should primarily be based on readability, maintainability, reusabilty, and code organization.

            In simple cases, using a lambda expression with the Func<int, int> type is concise and suitable for a simple operation like squaring a number.
            If your logic becomes more complex or you need to reuse the operation in multiple places, declaring a separate method might make your code more modular and maintainable.
            Ultimately, for performance considerations, the difference between these two approaches is likely to be minimal. Choose the one that fits best with your coding style and the overall structure of your program.

            */
        }
    }
}
