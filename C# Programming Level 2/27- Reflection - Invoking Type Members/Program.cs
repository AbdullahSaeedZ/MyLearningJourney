using System.Reflection;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // getting Type of the needed class:
            Type BankAccountType = typeof(BankAccount);


            // preparing the object which we want to invoke methods on:
            BankAccount account1 = new BankAccount(1, "Abdullah", 100); // at compile time
            BankAccount account2 = (BankAccount)Activator.CreateInstance(BankAccountType, new object[] {2,"Ali", 1000m}); // or at run time


            Console.WriteLine("==================  invoking a parameterless method  =================");
            MethodInfo voidMethodToInvoke = BankAccountType.GetMethod("TestPrint");
            voidMethodToInvoke.Invoke(account1, null);


            Console.WriteLine("\n\n==================  invoking a parameterized method  =================");
            MethodInfo MethodToInvoke = BankAccountType.GetMethod("Deposit");
            // preparing parameters in an object array:
            object[] parameters = { 400m };
            MethodToInvoke.Invoke(account1, parameters); // method invoked and money deposited


            Console.WriteLine("\n\n==================  getting values of a property =================");
            PropertyInfo property = BankAccountType.GetProperty("Balance");
            decimal acc2Balance = (decimal)property.GetValue(account2);
            Console.WriteLine($"Account2 balance = {acc2Balance}");


            Console.WriteLine("\n\n==================  setting values to a property =================");
            PropertyInfo property1 = BankAccountType.GetProperty("Balance");
            property1.SetValue(account2, (decimal)2000);
            Console.WriteLine(account2);
        }
    }

    public class BankAccount
    {
        private int _accountNumber;
        private string _holder;
        private decimal _balance;

        public int AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string Holder { get => _holder; set => _holder = value; }
        public decimal Balance { get => _balance; set => _balance = value; }

        public event Action<decimal, decimal> OnNegativeBalance;

        private BankAccount() { }

        public BankAccount(int accountNumber, string holder, decimal balance)
        {
            _accountNumber = accountNumber;
            _holder = holder;
            _balance = balance;
        }

        public void Deposit(decimal amount)
        {
            this._balance += amount;
            Console.WriteLine($"You Deposited {amount}, new balance is {_balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (( this._balance - amount ) < 0)
            {
                OnNegativeBalance?.Invoke(_balance, amount);
                return;
            }
            this._balance -= amount;
            Console.WriteLine($"You withdrew {amount}, new balance is {_balance}");
        }

        public void TestPrint()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"Name: {_holder}, Account Number: {_accountNumber}, Balance: {_balance}";
        }
    }
}
