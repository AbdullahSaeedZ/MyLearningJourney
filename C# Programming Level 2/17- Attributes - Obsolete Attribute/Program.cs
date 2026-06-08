using System.Data.SqlClient;

namespace _17__Attributes___Obsolete_Attribute
{
    public class Test
    {

        [Obsolete("this is the message to be shown in the warning")]
        public void OldMethodNoCompilerError()
        {

        }

        [Obsolete("this is the message to be shown in the warning", true)] // the ture arg will prevent the method from being compiled and will give error
        public void OldMethodWithCompilerError()
        {

        }

        public void NewMethod()
        {

        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            // this is an example from microsoft where they tagged the ADO.NET classes from the old lib System.Data.SqlClient as depreceated
            // see the green line and the message that will appear when hovering
            SqlConnection depreceatedClass;


            // and this is the obsolete method i made above:
            Test test1 = new Test();

            test1.OldMethodNoCompilerError(); // will still run, but it is obsolete and warning will remain
            test1.OldMethodWithCompilerError(); // the ture arg will prevent the method from being compiled and will give error
            test1.NewMethod();

        }
    }
}
