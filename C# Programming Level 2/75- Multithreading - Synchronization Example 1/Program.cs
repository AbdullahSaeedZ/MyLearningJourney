namespace _73__Multithreading___Race_Condition_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // multi-threading
            Wallet wallet1 = new Wallet("Fahad", 50);

            Console.WriteLine("\n\nusing parallel programming (Race Condition):");
            Console.WriteLine($"Balance: {wallet1.Bitcoins}");

            Thread t1 = new Thread(() => wallet1.Withdraw(40));
            Thread t2 = new Thread(() => wallet1.Withdraw(30));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"withdrew 40");
            Console.WriteLine($"withdrew 30");
            Console.WriteLine(wallet1);

            // check race condition example lesson to understand the issue we had



        }
    }

    class Wallet
    {
        // Every single object created in C# (.NET) has a hidden, internal property 
        // built into it by the runtime called a 'SyncBlock'. 

        // When we instantiate this empty object, we are creating a lightweight token 
        // that exists purely so the .NET runtime can use its SyncBlock to flag whether 
        // the critical section (in the lock statement) is currently "Locked" or "Unlocked". 

        // It acts exactly like a traffic light that threads inspect before passing through.
        private readonly object balanceLock = new object();

        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        public void Withdraw(int amount)
        {
            // lock keyword is like a box where we put our code block and shared resource to be protected
            // the balanceLock object will act as the lock of that box,
            // once a thread gets inside the box, the box is locked and no other threads can enter untill it is unlocked

            // this will result in one withdrawl operation, sinc one will execut and the second will be waiting, then once the second is allowed to check the condition
            // it will find insufficient balacne and withdrawl will fail and no data currption will happen
            lock (balanceLock)
            {
                if (Bitcoins >= amount)
                {
                    Thread.Sleep(1000);

                    Bitcoins -= amount;
                }
            }
            
        }

        public void Deopsit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins += amount;
        }


        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }


}
