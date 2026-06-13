using System.Reflection;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount(1, "Abdullah", 100);
            myAccount.OnNegativeBalance += MyAccount_OnNegativeBalance;
            Console.WriteLine(myAccount);
            myAccount.Withdraw(50);
            myAccount.Withdraw(51);


            Console.WriteLine("\n\n=========== Reflecting all PUBLIC members only ============");
            MemberInfo[] publicMembers = typeof(BankAccount).GetMembers();
            foreach (MemberInfo member in publicMembers)
            {
                Console.WriteLine(member);
            }

            // we use binding flags to determine which members will be returned
            // binding flags are flagged enums, which means they use bitwise ops to include multiple values to search for
            // we also use BindingFlags.Instance to indicate non-static members
            Console.WriteLine("\n\n=========== Reflecting all Public+Private members ============");
            MemberInfo[] privateAndPublicMembers = typeof(BankAccount).GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MemberInfo member in privateAndPublicMembers)
            {
                Console.WriteLine(member);
            }


            Console.WriteLine("\n\n=========== Reflecting all private fields ============");
            FieldInfo[] privateFields = typeof(BankAccount).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in privateFields)
            {
                Console.WriteLine(field);
            }


            Console.WriteLine("\n\n=========== Reflecting all properties ============");
            PropertyInfo[] properties = typeof(BankAccount).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property);
                // since properties are syntactic sugar which will be setters and getters methods, we can see them here:
                Console.WriteLine(property.GetGetMethod());
                Console.WriteLine(property.GetSetMethod());
            }


            Console.WriteLine("\n\n=========== Reflecting all methods ============");
            MethodInfo[] methods = typeof(BankAccount).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo m in methods)
            {
                Console.WriteLine(m);
            }


            Console.WriteLine("\n\n=========== Reflecting all events ============");
            EventInfo[] events = typeof(BankAccount).GetEvents(BindingFlags.Public | BindingFlags.Instance);
            foreach (EventInfo e in events)
            {
                Console.WriteLine(e);
            }


            Console.WriteLine("\n\n=========== Reflecting all constructors ============");
            ConstructorInfo[] ctors = typeof(BankAccount).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (ConstructorInfo c in ctors)
            {
                Console.WriteLine(c);
            }


            Console.WriteLine("\n\n=========== Reflecting a member by name ============");
            MemberInfo[] members = typeof(BankAccount).GetMember("_balance", BindingFlags.NonPublic | BindingFlags.Instance); // in array cuz member might have overloading
            foreach (MemberInfo member in members)
            {
                Console.WriteLine(member);
            }



        }

        private static void MyAccount_OnNegativeBalance(decimal balance, decimal amount)
        {
            Console.WriteLine($"Cant withdraw {amount}, your balance is {balance} SAR");
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

        public override string ToString()
        {
            return $"Name: {_holder}, Account Number: {_accountNumber}, Balance: {_balance}";
        }
    }
}
