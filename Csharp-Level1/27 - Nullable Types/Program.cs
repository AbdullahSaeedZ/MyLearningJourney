using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27___Nullable_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //As you know, a value type cannot be assigned a null value. For example, int i = null will give you a compile time error.
            //C# 2.0 introduced nullable types that allow you to assign null to value type variables. You can declare nullable types using Nullable<t> where T is a type.

            // Nullable<T> can be assigned any value
            // in our example , Nullable<int> can be any value
            // from -2147483648 to 2147483647, or a null value.


            // int i = null; error
            Nullable<int> i = null;
            // or 
            int? age = null;

            // Nullable types are only for value types (e.g., int, float). Reference types are already nullable
            // null means absence of value , not 0


        }
    }
}
