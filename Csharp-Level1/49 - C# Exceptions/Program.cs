using System;


// When executing C# code, different errors can occur: coding errors made by the programmer, errors due to wrong input, or other unforeseeable things.

// When an error occurs, C# will normally stop and generate an error message. The technical term for this is: C# will throw an exception (throw an error).


namespace _49___C__Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Exception is a super class that has sub classes inside special for handling exceptions



            // try running the code that might throw exception
            try
            {
                //BadMethod();  un comment to run this example
            }
            // handle exception when happens
            catch (Exception obj) // use Exception class if we want to specify certain exceptions handling by its methods, or we can use its sub classes to catch certain exceptions rather than all exceptions.
            {
                // send email to support team , or show message or any thing 

                Console.WriteLine(obj.Message);


            }





            // this multiple exception handling, if we have big code block to try, we want to handle certain exceptions that might be thrown
            try
            {
                //BadMethod(); suppose this is a correct method and part of big code block
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (DivideByZeroException obj)  // so we specify what type of exceptions, using sub classes inherited from super class Exception
            {

                Console.WriteLine(obj.Message);

            }
            catch (IndexOutOfRangeException obj)
            {

                Console.WriteLine(obj.Message);

            }
            catch (Exception obj) // here we say that if all specific exceptions didnt catch, then we put the super class in the end as a general exception handler just in case(cant put it on top then follow it with its sub class cuz super has them all)
            {

                Console.WriteLine(obj.Message);

            }


            // there are a lot of ways to handle , this is a short brief 




        }

        static void BadMethod()
        {
            int x = 5, y = 0;
            Console.WriteLine(x / y);
        }


    }
}
