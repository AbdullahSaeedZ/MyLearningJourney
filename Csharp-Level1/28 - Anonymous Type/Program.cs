using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28___Anonymous_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //you dont specify any type here , automatically will be specified
            // student is a reference variable and refere to new object created in heap with the Read-only data members we assigned.
            // compiler will create a hidden class with those members we gave him, but only for reading , no other members types or editing on them.
            var student = new { Id = 20, FirstName = "Abdullah", LastName = "Alzahrani" };


            Console.WriteLine("\nExample1:\n");
            Console.WriteLine(student.Id); //output: 20
            Console.WriteLine(student.FirstName); //output: Abdullah
            Console.WriteLine(student.LastName); //output: Alzahrani

            //You can print the whole object members in one line like this:
            Console.WriteLine(student);


            //anonymous types are read-only
            //you cannot change the values of properties as they are read-only.

            // student.Id = 2;//Error: cannot chage value
            // student.FirstName = "Ali";//Error: cannot chage value


            //An anonymous type's property can include another anonymous type.
            var student2 = new
            {
                Id = 20,
                FirstName = "Abdullah",
                LastName = "Alzahrani",
                Address = new { Id = 1, City = "DM", Country = "KSA" }
            };

            Console.WriteLine("\nExample2:\n");
            Console.WriteLine(student2.Id);
            Console.WriteLine(student2.FirstName);
            Console.WriteLine(student2.LastName);

            Console.WriteLine(student2.Address.Id);
            Console.WriteLine(student2.Address.City);
            Console.WriteLine(student2.Address.Country);
            Console.WriteLine(student2.Address);

        }
    }
}
