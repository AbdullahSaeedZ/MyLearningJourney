using System;

namespace _24___Numbers_Datatypes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            byte b1 = 255; // max of bye (unsigned)
            //byte b2 = -128; // compile time error, cant have minus value

            sbyte sb1 = 127; // max of singed byte 
            sbyte sb2 = -128; // max of singed byte

            // we can the following properties to see max and min of a data type
            Console.WriteLine("Byte:");
            Console.WriteLine("min = {0} , max = {1} ", Byte.MinValue, Byte.MaxValue); 

            Console.WriteLine("sByte:");
            Console.WriteLine("min = {0} , max = {1} ", SByte.MinValue, SByte.MaxValue);


            short s1 = 32767;
            short s2 = -32768;
           // short s3 = 40000; // compiler error, cant cast from big to small (big value stored in small data type) (type safe), unlike C++ :(

            ushort us1 = 65535;

            Console.WriteLine("short:");
            Console.WriteLine("min = {0} , max = {1} ", Int16.MinValue, Int16.MaxValue); // int16 is the .net CTS data types
            Console.WriteLine("ushort:");
            Console.WriteLine("min = {0} , max = {1} ", UInt16.MinValue, UInt16.MaxValue);


            int i = 2147483647;
            int k = -2147483648;

            //  int k = 4294967295; //Compile-time error: Cannot implicitly convert type 'uint' to 'int'.

            uint ui1 = 4294967295;
            // uint ui2 = -1; //Compile-time error: Constant value '-1' cannot be converted to a 'uint'

            Console.WriteLine("\nInt:");
            Console.WriteLine("Min={0} , Max={1}", Int32.MinValue, Int32.MaxValue);

            Console.WriteLine("\nUInt:");
            Console.WriteLine("Min={0} , Max={1}", UInt32.MinValue, UInt32.MaxValue);

            //Long
            long l1 = -9223372036854775808;
            long l2 = 9223372036854775807;

            ulong ul1 = 18223372036854775808ul; // notice the suffix
            ulong ul2 = 18223372036854775808UL;

            Console.WriteLine("\nLong:");
            Console.WriteLine("Min={0} , Max={1}", Int64.MinValue, Int64.MaxValue);

            Console.WriteLine("\nULong:");
            Console.WriteLine("Min={0} , Max={1}", UInt64.MinValue, UInt64.MaxValue);


            //Float
            float f1 = 123456.5F;
            float f2 = 1.123456f;

            Console.WriteLine("\nFloat:");
            Console.WriteLine("Min={0} , Max={1}", float.MinValue, float.MaxValue);  // using the C# data types, C# or .Net all same , in the end will be converted to .NET CTS


            //double
            double d1 = 12345678912345.5d;
            double d2 = 1.123456789123456d;

            Console.WriteLine("\nDouble:");
            Console.WriteLine("Min={0} , Max={1}", double.MinValue, double.MaxValue);



            //Decimal
            //The decimal type has more precision and a smaller range
            //than both float and double,
            //and so it is appropriate for financial and monetary calculations.
            decimal d3 = 123456789123456789123456789.5m;
            decimal d4 = 1.1234567891345679123456789123m;

            Console.WriteLine("\nDecimal:");
            Console.WriteLine("Min={0} , Max={1}", decimal.MinValue, decimal.MaxValue);


            //Scientific Notation
            //Use e or E to indicate the power of 10 
            //as exponent part of scientific notation with float, double or decimal.

            double d = 0.12e2; // means 0.12 × 10² = 12  , just move the point based on number after e

            Console.WriteLine(d);  // 12;

            float f = 123.45e-2f;
            Console.WriteLine(f);  // 1.2345

            decimal m = 1.2e6m;
            Console.WriteLine(m);// 1200000



            //hex & Binary
            int hex = 0x2F;   // hex starts with prefix 0x then then a hex number
            int binary = 0b_0010_1111;

            Console.WriteLine(hex);
            Console.WriteLine(binary);



        }
    }
}
