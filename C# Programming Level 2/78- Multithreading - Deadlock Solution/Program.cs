namespace _78__Multithreading___Deadlock_Solution
{
    // a Deadlock is a situation where two or more threads are frozen in theie execution because they are waiting for each other to finish
    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet1 = new Wallet(1, "Abdullah", 100);
            var wallet2 = new Wallet(2, "Ali", 50);

            Console.WriteLine("Before Transaction:");
            Console.Write(wallet1); Console.Write("\t" + wallet2);

            Console.WriteLine("\n\n---------------------------------------------------------------");
            Console.WriteLine("Transaction Started...");

            // two transactions on both accounts
            var transferManager1 = new TransferManager(wallet1, wallet2, 50);
            var transferManager2 = new TransferManager(wallet2, wallet1, 30);

            // -------- im using the safeTransfer method which avoids deadlocks
            var t1 = new Thread(transferManager1.SafeTransfer);
            t1.Name = "t1";
            var t2 = new Thread(transferManager2.SafeTransfer);
            t2.Name = "t2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
           
            Console.WriteLine("after Transaction:\n");
            Console.Write(wallet1); Console.Write("\t" + wallet2);


            Console.ReadKey();
        }
    }

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

        // there are multiple ways to solve this, easist is this:
       
        public void SafeTransfer()
        {
            // 2. THE SOLUTION:
            // To guarantee a deadlock can NEVER happen, we must force EVERY thread to acquire 
            // locks in the exact same resource sequence, no matter who is sending or receiving money.
            //
            // 3. HOW IT WORKS INTERNALLY:
            // We use the unique 'Id' property of the wallets to sort them deterministically 
            // from lowest ID to highest ID before any locking occurs.
            //
            // - 'lock1' will ALWAYS point to the Wallet object with the smaller ID.
            // - 'lock2' will ALWAYS point to the Wallet object with the larger ID.
            //
            // 4. THE TRACE (Why this makes deadlocks physically impossible):
            // Let's assume Wallet A has ID 1 and Wallet B has ID 2.
            //
            // Scenario: Two opposite transactions happen at the exact same millisecond:
            // -> Thread 1 transfers from Wallet 1 to Wallet 2.
            // -> Thread 2 transfers from Wallet 2 to Wallet 1.
            //
            // - Thread 1 evaluates: (1 < 2) is TRUE  -> lock1 = Wallet 1, lock2 = Wallet 2
            // - Thread 2 evaluates: (2 < 1) is FALSE -> lock1 = Wallet 1, lock2 = Wallet 2
            //
            // Notice that BOTH threads selected Wallet 1 as 'lock1'. 
            // Whichever thread executes its 'lock (lock1)' statement first wins Wallet 1. 
            // The other thread is safely blocked at line 1, cleanly waiting outside before it 
            // can even try to touch Wallet 2. No intersection, no deadlock!
            //
            // 5. CRITICAL CAVEAT / COMMON OVER-ENGINEERING MISTAKE:
            // For this pattern to work, IDs MUST BE ABSOLUTELY UNIQUE. If two distinct objects 
            // share the same ID (e.g., ID 1 and ID 1), the '<' comparison returns false for both.
            // This causes the threads to sort them inconsistently, completely breaking the mechanism 
            // and recreating the deadlock.
            var lock1 = from.Id < to.Id ? from : to;
            var lock2 = from.Id < to.Id ? to : from;

            Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock ... {from}");
            lock (lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} lock acquired ... {from}");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock ... {to}");

                lock (lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} lock acquired ... {to}");
                    from.Withdraw(amountToransfer);
                    to.Deopsit(amountToransfer);
                }
            }
        }
    }

    class Wallet
    {
        private readonly object balanceLock = new object();

        public Wallet(int id, string name, int bitcoins)
        {
            this.Name = name;
            this.Bitcoins = bitcoins;
            this.Id = id;
        }

        public int Id { get; set; }
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
