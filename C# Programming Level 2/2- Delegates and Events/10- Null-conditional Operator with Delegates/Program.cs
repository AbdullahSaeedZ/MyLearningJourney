namespace MyConsoleApp
{
    internal class Program
    {
        public static event Action<int> OnPersonSelected;

        private static void Main(string[] args)
        {
            // there are two issues of invoking an event with the normal way:
            // OnPersonSelected.Invoke(5);  // un comment and run to see the nullReferenceException

            // first is to invoke an event with no methods subscribed, meaning the delegate is null
            // second is Race Condition issue that happens in multithreading apps,
            // where one thread invokes an event, and in the same time another thread unsubscribe a method from that event which will cause null reference exception


            // to avoid this both situations, we use Null-Conditional operator (?)
            // which will avoid invoking null delegates, check DVLD where i used events
            OnPersonSelected?.Invoke(5);

            // this will run without using the null operator, cuz there is aleardy a subscribed method
            OnPersonSelected += PrintPersonID;
            OnPersonSelected.Invoke(5);


            // old way of doing it, was to use if statement with local delegate like this:
            Action<int> Handler = OnPersonSelected;
            if (Handler != null)
                Handler(5); // reason is that even if another thread unsubscribes the method we are calling from the original event (OnPersonSelected), the local event (Handler) is still pointing to that method

        }

        public static void PrintPersonID(int ID)
        {
            Console.WriteLine("Person ID is: " + ID);
        }

    }
}