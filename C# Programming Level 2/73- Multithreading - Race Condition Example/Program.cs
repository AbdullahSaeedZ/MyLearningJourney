namespace _73__Multithreading___Race_Condition_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet("Abdullah", 50);

            Console.WriteLine("using normal synchronous programming (no Race Condition):");
            Console.WriteLine($"Balance: {wallet.Bitcoins}");

            wallet.Withdraw(40);
            Console.WriteLine($"withdrew 40");
            wallet.Withdraw(30); // < will fail cuz no sufficient balance, and will still have 10 coins
            Console.WriteLine($"withdrew 30");

            Console.WriteLine(wallet);



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
            Console.WriteLine(wallet1); // cuz of cpu scheduler, race condition might not occur, re run the app multiple times to see the race condition causnig negative balance

            // RACE CONDITION!! see below for timing issue that caused negative balance

            // solution for this is in thread synchronization example lesson


        }
    }

    class Wallet
    {
        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        public void Withdraw(int amount)
        {
            if (Bitcoins >= amount)// 1. t1 checks condition, balance is 50, proceed to withdraw
            {
                Thread.Sleep(1000); // 2. t1 sleeps for 1 sec, still didnt withdraw, in this moment t2 comes to check condition

                Bitcoins -= amount; // 3. t1 proceed and withdraw, balance is 10 now, but t2 has passed the condition and sleeping for 1 sec and thinks balance is still 50, then withdraws from 10 to become -20
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
