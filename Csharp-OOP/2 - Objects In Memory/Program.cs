using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// all objects created from one class, will share same methods in the heap, but the data members will not be shared and will be saved in memory in their own spaces.
// thats because methods have no data , only performing certain tasks, unlike data members

//Function Members are shared to all objects in memory and has one memory space for them.
//Every Object has it's own space in memory that holds only Data Members.


namespace Objects_In_Memory
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
