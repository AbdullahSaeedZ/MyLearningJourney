internal class Program
{
    // =========================================================================
    // INTRO & DEFINITIONS:
    // A Pure Function must satisfy two core rules:
    // 1. Deterministic: Given the same arguments, it ALWAYS returns the same output.
    // 2. No Side Effects: It cannot mutate state outside its own scope 
    //    (e.g., global state, parameters passed by reference, external I/O, DB, network).
    //
    // An Impure Function violates either of these rules by mutating external 
    // state, modifying incoming arguments in-place, or relying on nondeterministic 
    // sources (e.g., DateTime.Now, Random, file system, network calls).
    // =========================================================================

    private static List<int> _numbers = new List<int>() { 1, 2 };

    public static void Main(string[] args)
    {
        Console.WriteLine("Impure Functions");

        AddInt1(3);
        Print(_numbers); // Mutated external state, which can unexpectedly impact other operations that use this state.

        int x = 2;
        AddInt2(ref x);
        Print(_numbers); // Produced side effects: mutated caller's parameter 'x' via 'ref' and modified external state '_numbers'.

        AddInt3();
        Print(_numbers); // Side effect and nondeterministic: pulled a random value and mutated external state.

        Console.WriteLine("Pure Functions");

        Print(AddInt4(_numbers, 4)); // Returns a brand new instance; '_numbers' remains completely untouched.
    }

    static void AddInt1(int n)
    {
        // Mutates (modifies) an external source (shared state); therefore, it is impure.
        _numbers.Add(n);
    }

    static void AddInt2(ref int n)
    {
        // Mutates both the caller's variable (side effect on parameter) and external state (_numbers).
        // Passing by ref and altering it causes unintended side effects for the caller; therefore, it is impure.
        n++;
        _numbers.Add(n);
    }

    static void AddInt3()
    {
        // INTERACTION WITH OUTSIDE WORLD / NONDETERMINISTIC BEHAVIOR:
        // Reads from a nondeterministic source (Random) where output cannot be predicted,
        // and mutates external state. Because it violates both purity rules, it is impure.
        _numbers.Add(new Random().Next());
    }

    // This is a pure function:
    // 1. Causes no side effects (does not mutate external state or callers' data).
    // 2. Does not mutate inputs (creates and works on a local copy).
    // 3. Deterministic with no external dependencies (same inputs will always produce identical output).
    static List<int> AddInt4(List<int> numbers, int num)
    {
        List<int> newNumbers = new List<int>(numbers);
        newNumbers.Add(num);
        return newNumbers;
    }

    static void Print(List<int> numbers)
    {
        Console.WriteLine("{ " + string.Join(", ", numbers) + " }");
    }
}