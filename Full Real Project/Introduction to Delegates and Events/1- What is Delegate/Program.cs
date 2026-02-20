using System;



// Delegate = يفوض 
// Delegate is just a pointer but for Methods


namespace Introduction_to_Delegates_and_Events
{

    // Delegate can point to a method through the method signature, but the signature here is a bit different than signature in method overloading.
    // signature in Overloading is Method name + Parameters list
    // signature in Delegates is Return type + Parameters list

    // Delegate is a reference type (like classes), we define it then we create instances of it
    // Delegate keyword + Return Type + Delegate name + parameters list
    delegate string delName(string word);


    internal class Program
    {
        static void Main(string[] args)
        {
            // we create the instance, cuz delegate is a reference type
            // then pass a method name, so the delegate point to a method
            delName translator = new delName(EnglishToArabic);
            // delName translator = new delName(EnglishToFrench);      can pass any method with the same signature



            // till this point, the delegate is pointing to a method, but how to use the method ??
            // to use the method we have two ways:
            string result = translator.Invoke("hello"); // delegate point to a method that takes a parameter, so this way we pass the parameter and run the method
            string result2 = translator("hello"); // or this way.

            Console.WriteLine(result);
            Console.WriteLine(result2);


        }

        public static string EnglishToFrench(string input)
        {
            return "bonjo";
        }

        public static string EnglishToChinese(string input)
        {
            return "nehaaw";
        }

        public static string EnglishToArabic(string input)
        {
            return "hla";
        }
    }

}
