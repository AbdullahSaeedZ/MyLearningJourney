/*
====================================================================================================
                        LINQ AGGREGATION - Aggregate() Explained Simply
====================================================================================================

1. THE CORE IDEA:
   Imagine you are walking down a street collecting items into a backpack:
   - Your backpack is the ACCUMULATOR (the container holding your current running result).
   - Every step you take, you pick up a new item from the road (the NEXT element).
   - You combine what is already in your backpack with the new item.
   - At the end of the road, whatever is left in your backpack is your final answer.

   That is all `Aggregate()` does. It takes a list of items and reduces them down to one single value.

   The 3 Parameters / Steps:
   1. The Seed:
      What you put inside your backpack before you start walking. 
      If you start counting numbers, your seed is usually 0. If you start building a word, it might be "".
   
   2. The Accumulator Function (func):
      The rule that tells you how to update your backpack at every step.
      Example: (currentBackpack, nextItem) => currentBackpack + nextItem;
   
   3. The Result Selector:
      An optional final polish. Once you reach the end of the road, do you want to transform what is 
      inside your backpack before handing it over? 
      Example: Backpack holds a full Question object, but you only want to hand back its Title text.

   Visual Step-by-Step (Finding the Longest Question):
   
     Start: Backpack has Q1 (Length 14)
     Step 1: Check Q2 (Length 13). Is Q2 longer? No. Backpack keeps Q1.
     Step 2: Check Q3 (Length 43). Is Q3 longer? Yes. Backpack now holds Q3.
     Finish: Backpack holds Q3.
     Result Selector: Extracts just Q3.Title.ToUpper().

2. THE 3 OVERLOADS:
   ┌──────────┬─────────────────────────────┬────────────────────────────────────────────────────────┐
   │ Overload │ What You Pass In            │ How It Works                                           │
   ├──────────┼─────────────────────────────┼────────────────────────────────────────────────────────┤
   │ 1        │ (func)                      │ Takes item 0 as the starting backpack (seed) value.    │
   │ 2        │ (seed, func)                │ You choose the starting backpack value.                │
   │ 3        │ (seed, func, resultSelector)│ You choose the starting value AND a final step to run. │
   └──────────┴─────────────────────────────┴────────────────────────────────────────────────────────┘

3. HOW IT WORKS INTERNALLY:
   - Immediate execution: It loops through the entire collection immediately.
   - Overload 1 crashes if the collection is empty because it cannot pick element 0 as the seed.
   - Overloads 2 and 3 are safe on empty collections; they simply return the seed (or transformed seed).
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Aggregate.Shared;

namespace _1__Aggregate_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =========================================================================
            // Overload 1: Aggregate(func)
            // No seed provided. 
            // It puts "Ali" into the backpack first, then loops through the rest.
            // =========================================================================
            string[] names = new string[] { "Ali", "Salem", "Abeer", "Reem", "Jalal" };
            
            // old way to join strings (to aggregate them):
            var old = string.Join(", ", names);
            Console.WriteLine($"old way: {old}");

            // using aggregate:
            string commaSeparatedNames = names.Aggregate((namesAccumulated, name) =>
            {
                // we define how to aggregate, by concatenation in this case
                return $"{namesAccumulated}, {name}";
            });

            Console.WriteLine("--- Overload 1: Joining Strings ---");
            Console.WriteLine(commaSeparatedNames); // Ali,Salem,Abeer,Reem,Jalal

            Console.WriteLine();
            
            Console.WriteLine("--- Overload 1: visualized ---");
            // to visualize it step by step:
            string commaSeparatedNames1 = names.Aggregate((namesAccumulated, name) =>
            {
                Console.WriteLine($"{namesAccumulated}, {name}");
                return $"{namesAccumulated}, {name}";
            });

            
            
            // =========================================================================
            // Overload 2: Aggregate(seed, func)
            // Explicit seed provided: 0.
            // The backpack starts at 0, and we add every number into it one by one.
            // =========================================================================
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            // old way of adding sum:
            int sum = 0; // this is the seed (the initial value, same purpose in the aggregate function)
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"\n\nold way: {sum}");
            
            // using aggregate:
            int totalSum = numbers.Aggregate(0, (numbersAccumulated, nextNumber) =>
            {
                // we define how to aggregate, by adding in this case
                return numbersAccumulated + nextNumber;
            });

            Console.WriteLine("--- Overload 2: Running Total with Seed (0) ---");
            Console.WriteLine($"Total: {totalSum}"); // 15

            
            
            // =========================================================================
            // Overload 3: Aggregate(seed, func, resultSelector)
            // Backpack starts with the first question.
            // The function keeps whichever question has the longer title.
            // The resultSelector runs once at the very end to do anything which is extracting only the Title in our case.
            // =========================================================================
            List<Question> quiz = QuestionBank.All;
            
            // old way to get question with the longest title length:
            Question questionWtihLongestTitle = quiz[0]; // as initial value to compare with the rest and see length
            foreach (Question question in quiz)
            {
                if (question.Title.Length > questionWtihLongestTitle.Title.Length)
                    questionWtihLongestTitle = question;
            }

            // then only using title of the question, same as what the selector does in aggregate function
            Console.WriteLine($"\n\nlongest question title: {questionWtihLongestTitle.Title}");
            Console.WriteLine();
            
            // doing the same with aggregate:
            string longestTitleFormatted = quiz.Aggregate(
                quiz[0],                                              // 1. Starting Seed (initial value)
                ( currentQuestion, nextQuestion) => nextQuestion.Title.Length > currentQuestion.Title.Length ? nextQuestion : currentQuestion // compare and return the one with longest title length
                ,(finalWinner) => finalWinner.Title       // 3. Final transformation on exit
            );

            Console.WriteLine("\n--- Overload 3: Longest Title with Result Selector ---");
            Console.WriteLine($"Longest Title: {longestTitleFormatted}");
        }
    }
}