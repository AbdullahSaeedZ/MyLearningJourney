using System;
using System.Linq;
using System.Reflection;

/*
===============================================================================
BEGINNER GUIDE: WHAT IS A PROGRAMMING PARADIGM?
===============================================================================

Think of a "Paradigm" simply as a MINDSET or an APPROACH to organizing code, 
   handling data, and controlling how logic runs.
   
   The real differences between them:
     - Procedural: Data lives in plain variables; standalone functions modify 
       that data step-by-step from top to bottom.
     - Object-Oriented (OOP): Data and logic are bundled together inside classes 
       so an object protects its own state and exposes methods to change it.
     - Declarative: You describe WHAT result you want (like a query or filter), 
       leaving the manual looping steps to the underlying engine.
     - Dynamic: Types are not verified at compile time; the runtime determines 
       what a variable is and whether a method exists only when the line executes.
     - Event-Driven: Execution is not sequential; code waits idle in the background 
       and only fires when an external trigger or signal occurs.
     - Metaprogramming: Code that treats other code as data—inspecting, analyzing, 
       or generating types, methods, and metadata while running.

Let's break down the diagram with simple, non-overwhelming examples.

   +---------------------------------------------+
   |            PROGRAMMING PARADIGMS            |
   +---------------------------------------------+
     |
     +---> [ 1. IMPERATIVE ]
     |     "Tell the computer HOW to do it step by step."
     |     |
     |     +--------+--------+
     |     |                 |
     |     v                 v
     |  Procedural          OOP
     |  (Recipe steps)   (Objects & state)
     |
     |
     |
     |
     +---> [ 2. DECLARATIVE ]
     |     "Tell the computer WHAT you want, not the steps."
     |     |
     |     +--------+--------+
     |     |                 |
     |     v                 v
     |  Functional         Logic
     |  (Formulas/LINQ)  (Rules & SQL)
     |
     |
     |
     +---> [ 3. DYNAMIC ]
     |     "Wait until RUNTIME to check types."
     |     (Python, PHP, C# dynamic)
     |
     |
     +---> [ 4. EVENT-DRIVEN ]
     |     "Wait for a trigger/event to happen, then react."
     |     (Events, delegates, handlers)
     |
     |
     +---> [ 5. GENERIC ]
     |     "Write code that works safely on ANY data type."
     |     (List<T>, reusable algorithms)
     |
     |
     +---> [ 6. METAPROGRAMMING ]
           "Code that inspects, generates, or reads code."
           (Reflection, Attributes, source generators)
           
           
-------------------------------------------------------------------------------
   WHY C#? (GENERAL-PURPOSE & MULTI-PARADIGM)
   -------------------------------------------------------------------------------
   C# is classified as a GENERAL-PURPOSE language: it isn't restricted to a single
   niche (like SQL for queries or HTML for markup). You can build web backends,
   desktop software, mobile apps, games, and cloud microservices with it.
   
   It succeeds at this because it is MULTI-PARADIGM. Rather than locking you into
   one dogma, C# allows you to blend paradigms depending on the problem at hand.
   As practical evidence of this flexibility, every single paradigm mapped above
   is implemented with a concise, working C# example below.
   ===============================================================================
*/

namespace ParadigmsIntro
{
    // =========================================================================
    // METAPROGRAMMING HELPER: Custom Attribute (Tag)
    // A tag placed above a class so other code can inspect it at runtime.
    // =========================================================================
    [AttributeUsage(AttributeTargets.Class)]
    public class DeveloperInfoAttribute : Attribute
    {
        public string Author { get; }
        public DeveloperInfoAttribute(string author) => Author = author;
    }

    // =========================================================================
    // EVENT-DRIVEN HELPER: An Alarm Clock
    // Instead of constantly checking "is it time yet?", it fires an event signal.
    // =========================================================================
    public class AlarmClock
    {
        // The event: a broadcaster that others can listen to
        public event Action OnAlarmRinging;

        public void Trigger()
        {
            Console.WriteLine("[Event-Driven] Alarm is ringing!");
            // Fire the notification to all listeners
            OnAlarmRinging?.Invoke();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== PROGRAMMING PARADIGMS ===\n");

            // -----------------------------------------------------------------
            // 1. PROCEDURAL PROGRAMMING (From the diagram under "Imperative")
            // What it means: Code is just a list of procedures (functions) and steps.
            // Data sits in variables, and functions do work on that data.
            // -----------------------------------------------------------------
            int userScore = 85;
            PrintGradeProcedural(userScore);


            // -----------------------------------------------------------------
            // 2. OBJECT-ORIENTED PROGRAMMING (OOP)
            // What it means: Instead of loose variables and loose functions, we bundle
            // data (name, score) and actions (PrintGrade) together into one "Student" box.
            // -----------------------------------------------------------------
            Student student = new Student("Fahad", 92);
            student.PrintReport();


            // -----------------------------------------------------------------
            // 3. DECLARATIVE PROGRAMMING
            // What it means: You state WHAT you want, not the manual loop details.
            // Notice: No manual for-loop, no counters, no index variables.
            // -----------------------------------------------------------------
            int[] allScores = { 40, 75, 90, 60, 85 };

            // We declare: "Give me scores that are 70 or higher"
            var passingScores = allScores.Where(s => s >= 70);

            Console.Write("[Declarative] Passing scores: ");
            foreach (var s in passingScores) Console.Write($"{s} ");
            Console.WriteLine("\n");


            // -----------------------------------------------------------------
            // 4. FUNCTIONAL PROGRAMMING (A branch of Declarative)
            // What it means: Math-style functions. You give an input, you get an output.
            // It does not change any outside variable.
            // -----------------------------------------------------------------
            int baseNumber = 5;
            int squaredResult = Square(baseNumber); // Pure input -> output
            Console.WriteLine($"[Functional] Square of {baseNumber} is {squaredResult}");


            // -----------------------------------------------------------------
            // 5. GENERIC PROGRAMMING
            // What it means: Writing one piece of logic that works with ANY type:
            // integers, text, or custom objects, without rewriting the function.
            // -----------------------------------------------------------------
            DisplayBox<int>(100);
            DisplayBox<string>("Generics work for text too!");


            // -----------------------------------------------------------------
            // 6. DYNAMIC PROGRAMMING
            // What it means: Skipping strict compiler type-checking until the program
            // actually runs (like Python or JavaScript).
            // -----------------------------------------------------------------
            dynamic flexibleItem = "I am text right now";
            Console.WriteLine($"[Dynamic] Length: {flexibleItem.Length}");
            flexibleItem = 999; // Changed into a number at runtime
            Console.WriteLine($"[Dynamic] Now I am a number: {flexibleItem}");


            // -----------------------------------------------------------------
            // 7. EVENT-DRIVEN PROGRAMMING
            // What it means: Instead of code running top-to-bottom sequentially,
            // code waits in the background and REACTS when an event happens.
            // -----------------------------------------------------------------
            AlarmClock clock = new AlarmClock();

            // We subscribe to the event: "When the alarm rings, do this action"
            clock.OnAlarmRinging += () => Console.WriteLine("[Event-Driven] Reaction: Wake up and turn off the alarm!");

            // Trigger the event
            clock.Trigger();


            // -----------------------------------------------------------------
            // 8. METAPROGRAMMING / REFLECTION
            // What it means: "Code inspecting code". Your program looks at its own
            // classes, methods, or tags (attributes) while it is running.
            // -----------------------------------------------------------------
            Type studentType = typeof(Student);
            var devInfo = studentType.GetCustomAttribute<DeveloperInfoAttribute>();

            Console.WriteLine($"[Metaprogramming] Inspected Student Class -> Author: {devInfo?.Author}");
        }

        // --- PROCEDURAL HELPER ---
        // Just a standalone procedure. It takes data in and runs steps.
        public static void PrintGradeProcedural(int score)
        {
            if (score >= 90) Console.WriteLine("[Procedural] Grade: A");
            else if (score >= 80) Console.WriteLine("[Procedural] Grade: B");
            else Console.WriteLine("[Procedural] Grade: C or below");
        }

        // --- FUNCTIONAL HELPER ---
        // Takes an input, returns an output. Does not touch or change anything outside.
        public static int Square(int n)
        {
            return n * n;
        }

        // --- GENERIC HELPER ---
        // The `<T>` stands for "Any Type".
        public static void DisplayBox<T>(T item)
        {
            Console.WriteLine($"[Generic] Box contains: {item}");
        }
    }

    // --- OOP MODEL ---
    // Data and behavior packaged into one single entity.
    // Notice the [DeveloperInfo] tag added for the Metaprogramming example above.
    [DeveloperInfo("Abu Fahad")]
    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Student(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public void PrintReport()
        {
            Console.WriteLine($"[OOP] Student: {Name}, Score: {Score}");
        }
    }
}