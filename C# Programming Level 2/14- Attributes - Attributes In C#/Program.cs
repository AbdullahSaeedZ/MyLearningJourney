using System.Diagnostics;

namespace _14__Attributes___Attributes_In_C_
{
    // Attributes are used to give meta data (additional information) to code elements (classes, functinos and so on)
    // they are like instructions for the compiler to do certain things

    // Attributes enhance code readability, provide addtional data (meta data), enable frameworks to understand and process code more effectively based on attributes given
    // 
    // they are widely used in areas like serialization, documentation, testing, and more


    [Serializable] // to tell compiler that objects of this class can be serialized
    internal class Program
    {
        [Obsolete("this method is obsolete")]
        public void ObsoleteMethod()
        {

        }

        [Conditional("DEBUG")] // Conditional attributes will be explained in next lessons
        public void DebugMethod()
        {

        }


        static void Main(string[] args)
        {

        }
    }
}
