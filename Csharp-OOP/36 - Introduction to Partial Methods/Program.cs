using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// partial methods can only be used inside partial classes


namespace _36___Introduction_to_Partial_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person person1 = new Person();
            person1.age = 25;
            person1.birthday();

        }
    }
}
