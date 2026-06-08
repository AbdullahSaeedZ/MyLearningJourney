namespace _19__Attributes___Custom_Attribute
{
    /*
     In C#, a custom attribute is a user-defined metadata that you can apply to elements in your code, 
     such as classes, methods, properties, or parameters. Attributes provide a way to add declarative information to your code, 
     which can be used by the runtime, tools, or other code to perform specific actions or make decisions.

     To define a custom attribute, you create a class that inherits from the System.Attribute class or one of its derived classes.
     The attribute class can then be applied to various elements in your code using square brackets.

     ======== will be explained in REFLECTION lessons ========

     You can then use reflection or other mechanisms to access and utilize the information provided by these custom attributes at runtime.
     Custom attributes are often used for various purposes such as code generation, documentation, or influencing the behavior of frameworks and libraries.
     
     What is a custom Attribute?
     1. The Problem & Idea:
     An Attribute is just a "label" or "metadata" placed on top of a class, method, or property.
     By default, the Compiler just embeds this label into the compiled code (Assembly) and does nothing else.
     * 2. Why the Runtime/CPU Ignores it Initially:
     The CPU or Runtime doesn't inherently know what your custom label means. 
     If there is no execution logic tied to it, the Runtime will just skip it as if it doesn't exist.
     * 3. The Missing Link (The Consumer):
     For an Attribute to actually DO something, another external entity is required.
     This entity could be an external library, a framework (like ASP.NET or EF Core), 
     or your own custom code utilizing a feature called "Reflection".
     * 4. The Action:
     This external entity actively scans the code. It tells the Runtime: 
     "If you find this specific label, execute this logic. If it's missing, throw an error or change behavior!"
     */


    // where the attribute is allowed to be used, bool to allow to be used on same element mmultiple times
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }


        public MyCustomAttribute(string description)
        {
            Description = description;
        }
    }


    [MyCustom("This is a class attribute")] // can write the attribute without the last word if it is Attribute
    class MyClass
    {
        [MyCustom("This is a method attribute")]
        public void MyMethod()
        {
            // Method implementation
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
