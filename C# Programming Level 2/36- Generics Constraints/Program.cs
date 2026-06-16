
namespace _36__Generics_Constraints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Constraints are used to limit the consumer from using certain data types
            // constraints can be used on classes or methods

            // if i use for example a class constrinat then no other data types will be allowed
            // before adding any constraint:
            Generic<int> numbers = new Generic<int>(); // <- int will be rejected after adding a constraint


            // after adding a class constraint:
            // only classes are allowed:
            Generic<Person> people = new Generic<Person>();
            people.Add(new Person("Abdullah", "Alzahrani"));
            people.PrintItems();


            // after adding the new() constraint:
            Generic<Person> students = new Generic<Person>(); // <- will only allow reference type, with only parameterless ctors
            students.Add(new Person("koko", "Alzahrani"));



        }
    }


    // implementing a constraint is done by addig -> where T : Constraint1, Constraint2, ....

    // since class is a reference type, the constraint Class will allow any reference type,
    // meaning strings will be allowed, but what if i want to reject strings ?
    // we add the constraint which allows us to only use classes that require a new statemet : new(), but it will allow only parameterless ctors

    // to allow parameterized ctors, we either remove the new() constraint, or just add a parameterless ctor in the class besides the parameterized ctor

    // much more on constraints availavle: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

    public class Generic<T> where T : class, new()
    {
        private T[] _items;
        public bool IsEmpty => _items == null || _items.Length == 0;
        public int Count => _items == null ? 0 : _items.Length;

        public void Add(T item)
        {
            if (_items == null)
            {
                _items = [item];
                return;
            }

            T[] temp = new T[_items.Length + 1];

            for (int i = 0; i < _items.Length; i++)
            {
                temp[i] = _items[i];
            }

            temp[temp.Length - 1] = item;
            _items = temp;

        }

        public void RemoveAt(int position)
        {
            if (_items == null || position < 0 || position >= _items.Length) return;

            if (_items.Length == 1)
            {
                _items = null;
                return;
            }

            T[] temp = new T[_items.Length - 1];

            int c = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (c == position) c++;
                temp[i] = _items[c++];
            }
            _items = temp;
        }

        public void PrintItems()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                Console.Write(_items[i]);
                if (i != _items.Length - 1) Console.Write(", ");
            }
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
