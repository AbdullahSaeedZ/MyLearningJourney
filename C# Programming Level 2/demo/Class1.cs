using System.Reflection;

namespace DemoNamepace
{
    public class DemoClass
    {
        public static void Trace()
        {
            Console.WriteLine("\n\nTracing Assemblies...");
            Console.WriteLine($"Assembly where the method was defined and executed: {Assembly.GetExecutingAssembly()}");
            Console.WriteLine($"Assembly where the entry point is: {Assembly.GetEntryAssembly()}");
            Console.WriteLine($"Assembly where the method was called: {Assembly.GetCallingAssembly()}");
        }


        public static void MoreMetadata()
        {
            Type demoClassType = typeof(DemoClass);
            Assembly demoAssembly = demoClassType.Assembly;
            Console.WriteLine($"Assembly Full Name: {demoAssembly.FullName}");
            Console.WriteLine($"Assembly Location: {demoAssembly.Location}");

            // this AssemblyName class give us more details on assembly metadata, see the class definition
            AssemblyName assemblyName = demoAssembly.GetName();
            Console.WriteLine($"Assembly Name: {assemblyName.Name}");
            Console.WriteLine($"Assembly Version: {assemblyName.Version}");
            Console.WriteLine($"Assembly Total Key Tokens Length: {assemblyName.GetPublicKeyToken().Length}"); // will be 0 cuz no key
            Console.WriteLine($"Assembly Code Base (location of assembly): {assemblyName.CodeBase}");

            // we can even see details of any microsoft dll:
            Console.WriteLine($"DateTime Assembly Name: {typeof(DateTime).Assembly.GetName().CodeBase}");
        }

    }
}
