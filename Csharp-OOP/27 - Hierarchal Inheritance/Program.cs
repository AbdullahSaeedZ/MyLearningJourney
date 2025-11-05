using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27___Hierarchal_Inheritance
{
    public class Person
    {

        public int age { get; set; }
        public string name { get; set; }

        public virtual void Info()
        {
            Console.WriteLine($"hi my name is {name}, im {age} years old");
        }

    }






    public class User : Person
    {

        public string username { get; set; }
        public string password { get; set; }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"my username is {username}, password is {password}");
        }

    }

    public class Employee : Person
    {

        public int ID { get; set; }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"my id is {ID}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            user1.name = "Abdullah";
            user1.age = 11;
            user1.username = "ab";
            user1.password = "1234";
            user1.Info();

            Console.WriteLine("\n\n");

            Employee employee1 = new Employee();
            employee1.name = "koko";
            employee1.age = 22;
            employee1.ID = 100;
            employee1.Info();



        }
    }
}
