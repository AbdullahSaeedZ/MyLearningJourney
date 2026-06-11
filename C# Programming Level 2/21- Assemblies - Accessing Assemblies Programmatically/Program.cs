using System.Reflection;
using DemoNamepace;

namespace TestNamespace
{
    // last lesson we accessed the assembly by using ildasm tool to disassemble and look at the IL code and saw metadata of the assembly
    // now we will access the assembly programmatically using reflection (will be explained in details in next lessons)

    // reflection is ability of program to see and access his assemblies and all their info, it is like a mirror reflecting to the program so it can see and access more info 

    internal class Program
    {
        static void Main(string[] args)
        {
            // using the centeral class of reflection lib, to capture the assembly in a container then we can access its metadata then see all info:
            Type typeOfClass = typeof(Test);  // <- we give it the class needed, then it will return an upcasted object to Type class (explained next in type lesson)

            // once we have the type of Test class, we can access its info like:
            Console.WriteLine(typeOfClass.FullName); // info of the class


            // now since we have a type object with its info, we can access the assembly where the type is defined:
            Console.WriteLine($"accessing the assembly info from the Type reference variable: {typeOfClass.Assembly.FullName}");

            // =============== Another way is to use the Assembly class to skip creating a Type variable
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"accessing the assembly info from the Assembly object: {assembly.FullName}");  // will give same output of above code

            // another example is, i want to see info of the assembly where the DateTime struct is defined:
            Console.WriteLine($"\naccessing assembly of DateTime struct: {typeof(DateTime).Assembly.FullName}");


            // ================================= +++++ practice on multiple assemblies +++++ =============================== \\

            // getting general info about assemblies, see implementation
            DemoClass.Trace();

            // ================================= +++++ More info from metadata +++++ =============================== \\

            DemoClass.MoreMetadata();






            Console.ReadKey();
        }
    }

    public class Test
    {


    }
}
