using System.Reflection;
using System.Runtime.Remoting;

namespace TestProject
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // how to reference to a lib at run time, it is like adding a reference by right clicking on project then add a ref
            // this is a simple process, we can later use a fileDialoge to load the dll from anywhere to a specific folder for plug-ins or whatever
            string path = @"C:\Users\asz14\Desktop\ExternalAssembly.dll";

            // load the assembly into the app (RAM) at run time
            Assembly dllFile = Assembly.LoadFile(path);



            // we can get all class types available in the dll:
            Type[] types = dllFile.GetTypes();
            foreach (Type classType in types)
            {
                Console.WriteLine(classType.FullName);
            }



            // we can create instances at run time, without knowing the names of classes in compile time:
            Console.WriteLine("\n\nChoose which class to instantiate from?");
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"[{i}] {types[i].Name}");
            }

            int typeIndexChosen = Convert.ToInt32(Console.ReadLine());
            object userObj = Activator.CreateInstance(types[typeIndexChosen]);



            // lets invoke the printing method of chosen class:
            Console.WriteLine("\n\nChoose which method to invoke?");
            MethodInfo[] method = types[typeIndexChosen].GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            for (int i = 0; i < method.Length; i++)
            {
                Console.WriteLine($"[{i}] {method[i].Name}");
            }

            int methodIndexChosen = Convert.ToInt32(Console.ReadLine());
            method[methodIndexChosen].Invoke(userObj, null); 

            // no handling if methods with parameters were chosen, can do later

        }
    }
}
