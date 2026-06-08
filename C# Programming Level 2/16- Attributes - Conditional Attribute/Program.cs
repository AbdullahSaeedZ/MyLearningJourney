#define TEST_RELEASE

using System.Diagnostics;

namespace _16__Attributes___Conditional_Attribute
{
    //  [Conditional("DEBUG")]  
    // conditional attribute is a directive to the compiler to include or exclude a method when compilation based on symbols given (like arguments given to the attribute)
    // it is useful when i need to do some tracing or logging when im developing, but when app is released i dont want those methods to run
    // maybe after releasing the app, bugs will show up and i need to run the app in debug mode to do tracing and logging to fix.

    // ========================================================================

    // [Conditional("CUSTOM_SYMBOL")]
    // It allows us to include or exclude entire blocks of development tools, 
    // advanced logging, or experimental features for specific build targets (e.g., QA_BUILD, BETA_RELEASE).
    //
    // CRITICAL WARNING: Never use this for User Authorization or Security Features (like VIP access for certain releases)!
    // The method itself STILL EXISTS in the compiled DLL; the compiler just removes the CALL SITES.
    // Anyone with a decompiler can see the code. Use it ONLY for environment-specific code orchestration.

    // when i need to release multiple versions of my app, and i need certain features for a test or beta release, i can use a conditional attribute with a custom symbol
    // then tag the beta feature methods with the attribute, and put #define CUSTOM_SYMBOL on top of the page to tell the compiler to run those methods,
    // and remove or comment out the define statement to exclude the tagged methods
    // mode is irrelevant here

    // for larger code bases or separate dlls better to use another way to define the symbole which is to go to Project > properties > build > general compilation symbols




    // ========================================================================
    // WHY [Conditional] ONLY WORKS WITH VOID METHODS:
    // ========================================================================
    // 1. PREVENTS BROKEN CODE (Compilation Safety): 
    //    If a conditional method returned a value (e.g., int), and the compiler 
    //    removed its call site during a specific build, any variable capturing 
    //    that return value would become undefined, breaking the entire pipeline.
    //
    // 2. SIDE-EFFECT FREE (Fire & Forget):
    //    Methods returning 'void' guarantee that their removal will NOT affect 
    //    the state or logic of the subsequent code lines.
    //
    // 3. ALTERNATIVE FOR RETURN VALUES:
    //    If you absolutely need conditional logic that returns a value, you must 
    //    use preprocessor directives (#if / #else / #endif) to explicitly provide 
    //    a fallback value when the symbol is missing.
    public class Test
    {

        [Conditional("DEBUG")]  // this will make the compiler execute this method only in debug mode, in release mode it will be ignored
        public void DebugMethod()
        {
            Console.WriteLine("this is the debug method excecuted.");
        }

        public void NormalMethod()
        {
            Console.WriteLine("this is the normal method excecuted.");
        }

        [Conditional("TEST_RELEASE")]
        public void CustomSymbolMethod()
        {
            Console.WriteLine("this is the extra method excecuted for VIP release.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Test test1 = new Test();

            // built-in debug symbol
            test1.DebugMethod(); // will be called only in debug mode
            test1.NormalMethod(); // will be called in all modes

            // custom symbol
            test1.CustomSymbolMethod();
        }
    }
}
