using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30___Implementing_Multiple_Interfaces
{

    public interface IPerson
    {
       string  firstName { get; set; }
       string  lastName { get; set; }

        void introduce();

        void print();

        string to_string();
    }


    public interface ICommunicate
    {
        void callPhone();

        void sendEmail(string title, string body);
        void sendSMS(string title, string body);
        void sendFax(string title, string body);
    }

    // multiple inheritance is not allowed in C#
    // but we can do multiple inheritance with interfaces (or in better words, implement multiple interfaces):

    public abstract class Person : IPerson , ICommunicate
    {
        // Iperson interface terms
        public string firstName { get; set; }
        public string lastName { get; set; }

        public void introduce()
        {
            Console.WriteLine($"my name is {firstName} {lastName}");
        }

        public void print()
        {
            Console.WriteLine("print method");
        }
        public string to_string()
        {
            return "this is a string text";
        }


        // Icommunicate interface terms
        public void callPhone()
        {
            Console.WriteLine( "call started");
        }

        public void sendEmail(string title, string body)
        {
            Console.WriteLine("mail sent");
            Console.WriteLine(title);
            Console.WriteLine(body);
        }
        public void sendSMS(string title, string body)
        {
            Console.WriteLine("SMS sent");
            Console.WriteLine(title);
            Console.WriteLine(body);
        }
        public void sendFax(string title, string body)
        {
            Console.WriteLine("Fax sent");
            Console.WriteLine(title);
            Console.WriteLine(body);
        }

        // from this abstract class to sub class
        public abstract void sayGoodbye();
    }



    public class Employee : Person
    {

        public int ID { get; set; }

        // overriding the abstract method
        public override void sayGoodbye()
        {
            Console.WriteLine("goodbye");
        }
    }


    internal class Program

    {
        static void Main(string[] args)
        {

            Employee emp1 = new Employee();

            emp1.ID = 100;
            emp1.firstName = "abood";
            emp1.lastName = "alzahrani";
            emp1.sendFax("hello", "this is fax text");
            emp1.print();
            emp1.introduce();
            emp1.callPhone();
            emp1.sayGoodbye();
        }
    }
}
