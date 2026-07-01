namespace _77__Multithreading___Thread_Deadlock
{

    // a Deadlock is a situation where two or more threads are frozen in theie execution because they are waiting for each other to finish


    internal class Program
    {
        static void Main(string[] args)
        {
            // normal process in single thread, no deadlock issue:
            var wallet1 = new Wallet("Abdullah", 100);
            var wallet2 = new Wallet("Ali", 50);
            Thread.CurrentThread.Name = "Main Thread";

            Console.WriteLine("single-thread, no dedadlock:\n");
            Console.WriteLine("Before Transaction:");
            Console.Write(wallet1); Console.Write("\t" + wallet2);

            Console.WriteLine("\n\n---------------------------------------------------------------");
            Console.WriteLine("Transaction Started...");

            var transferManager = new TransferManager(wallet1, wallet2, 50);
            transferManager.Transfer();
            Console.WriteLine("\nafter Transaction:");
            Console.Write(wallet1); Console.Write("\t" + wallet2);

            Console.WriteLine("\n\n\n\n\nPress enter to see multi-threading deadlock issue:\n");
            Console.ReadKey();



            // multi-threading process with deadlock issue:



            var wallet3 = new Wallet("Ahmed", 100);
            var wallet4 = new Wallet("Fahad", 50);

            Console.WriteLine("Before Transaction:");
            Console.Write(wallet3); Console.Write("\t" + wallet4);

            Console.WriteLine("\n\n---------------------------------------------------------------");
            Console.WriteLine("Transaction Started...");

            // two transactions on both accounts
            var transferManager1 = new TransferManager(wallet3, wallet4, 30);
            var transferManager2 = new TransferManager(wallet4, wallet3, 40);

            var t1 = new Thread(transferManager1.Transfer);
            t1.Name = "t1";
            var t2 = new Thread(transferManager2.Transfer);
            t2.Name = "t2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


            // now both threads will try to lock a wallet oject that is already locked by the other thread
            // which will cause the app to freeze and wait for both threads, which is a deadlock issue!
            Console.WriteLine("after Transaction:\n");
            Console.Write(wallet2); Console.Write("\t" + wallet3);

            // solution is in next lesson
        }
    }

    // a Manager Class is used to manage a set of objects of another class, which is a best practice
    // for the sake of the example, will create a manager class that manages transactions between two wallet objects


    class TransferManager
    {
        private Wallet from;
        private Wallet to;
        private int amountToransfer;

        public TransferManager(Wallet from, Wallet to, int amountToransfer)
        {
            this.from = from;
            this.to = to;
            this.amountToransfer = amountToransfer;
        }

        public void Transfer()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is trying to lock.. {from}");
            Thread.Sleep(1000);
            lock (from)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} aquired the lock .. {from}");
                Thread.Sleep(1000);


                Console.WriteLine($"{Thread.CurrentThread.Name} is trying to lock.. {to}");
                Thread.Sleep(1000);
                lock (to)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} aquired the lock .. {to}");
                    // after locking both objects involved in the transfer process, we do the process
                    from.Withdraw(amountToransfer);
                    to.Deopsit(amountToransfer);
                }
            }
        }
    }


    class Wallet
    {
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
