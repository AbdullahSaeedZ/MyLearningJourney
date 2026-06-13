using System.Reflection;

namespace Test
{
    // will do a simple example of how to make custom attributes, then act like an external app that will consume them by using reflection

    // creating a custom attribute, and defining the usage:
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DescriptionAttribute : Attribute
    {
        // this property can be used by reflection user
        public string Description { get; set; }

        public DescriptionAttribute(string Description)
        {
            this.Description = Description;
        }
    }




    // class to be annotated with attributes to be consumed by another app or framework or whatever
    [Description("this is class description1")]
    [Description("this is class description2")]
    public class TestClass
    {
        //[Description("this property is just for testing the attribute")]  <- will reject, cuz i didnt specify properties in Attribute Usage
        public int Number { get; set; }

        [Description("this is method description")]
        public void method1()
        {

        }
    }

  
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestClass);

            // getting class-level attributes:
            object[] classAttributes = type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            foreach (DescriptionAttribute attribute in classAttributes)
            {
                Console.WriteLine($"class custom attribute message: {attribute.Description}");
            }


            // getting method-level attributes:
            MethodInfo method = type.GetMethod("method1");
            object[] methodAttributes = method.GetCustomAttributes(typeof(DescriptionAttribute), false);
            foreach (DescriptionAttribute attribute in methodAttributes)
            {
                Console.WriteLine($"method custom attribute message: {attribute.Description}");
            }
        }
    }
}
