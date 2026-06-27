namespace _70__Multithreading___Parameterized_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // the thread constructor is expecting a delegate of a void return type parameter,
            // we can assign a parameterized method to the thread in the Start() method, but it is a long process that requires objects and casting,
            // we can pass a method with parameters using anonymous methods in the ctor
            Thread thread1 = new Thread(() => Method1("UI Tasks", 10));
            Thread thread2 = new Thread(() => Method1("Audio Tasks", 10));
            thread1.Start();
            thread2.Start();

        }

        public static void Method1(string threadName, int iteration)
        {
            for (int i = 0; i <= iteration; i++)
            {
                Console.WriteLine($"thread: {threadName}, value: {i}");
                Thread.Sleep(200);
            }
        }

    }

}
