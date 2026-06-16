using System.Collections;

namespace _37___Generics___Built_in_Generics_and_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Microsoft provides comprehensive generics class to use such as List<> and Dictionary< , >
            // List<> is same as Victor<> in C++

            // built-in generics are in the System.Collections.Generics
            List<Person> people = new List<Person>();
            people.Add(new Person("Abdullah", "Alzahrani"));
            people.Add(3); // <- type-safety will prevent other types than the declared


            // Microsoft also providdes collections, which are using base object that are not type-safe, meaning they can take multiple datatypes at once
            // one example is 
            // the are in System.Collections

            // No type-safety to control the data types
            ArrayList arr = new ArrayList();
            arr.Add(new Person("koko", "Alzahrani")); 
            arr.Add(new { Fname = "koko", Lname = "Alzahrani" });
            arr.Add(5);
            arr.Add("text");
        }
    }

    public class Person
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public Person(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;
        }

        public override string ToString()
        {
            return $"{Fname} {Lname}";
        }
    }

}
