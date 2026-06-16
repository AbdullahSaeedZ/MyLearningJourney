namespace _35__Generics___Generics_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // with ints
            Generic<int> myItems = new Generic<int>();

            Console.WriteLine("\n=============== int example: ==============");
            Console.WriteLine($"is empty: {myItems.IsEmpty}");
            Console.WriteLine($"count: {myItems.Count}");

            Console.WriteLine("\n======= after adding");
            myItems.Add(1); 
            myItems.Add(2); 
            myItems.Add(3); 

            Console.WriteLine($"count: {myItems.Count}");
            Console.WriteLine($"values:");
            myItems.PrintItems();

            Console.WriteLine("\n\n======== after removing");
            myItems.RemoveAt(0); 

            Console.WriteLine($"count: {myItems.Count}");
            Console.WriteLine($"values:");
            myItems.PrintItems();



            // with strings:
            Generic<string> myItems1 = new Generic<string>();

            Console.WriteLine("\n\n\n=============== string example: ==============");
            Console.WriteLine($"is empty: {myItems1.IsEmpty}");
            Console.WriteLine($"count: {myItems1.Count}");

            Console.WriteLine("\n======= after adding");
            myItems1.Add("abdullah"); 
            myItems1.Add("Ali"); 
            myItems1.Add("Fahad"); 

            Console.WriteLine($"count: {myItems1.Count}");
            Console.WriteLine($"values:");
            myItems1.PrintItems();

            Console.WriteLine("\n\n======== after removing");
            myItems1.RemoveAt(0);

            Console.WriteLine($"count: {myItems1.Count}");
            Console.WriteLine($"values:");
            myItems1.PrintItems();
        }
    }


    // a generic class to simulate a simple generic Generic
    public class Generic<T> 
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

            temp[temp.Length -1] = item;
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
}
