namespace _13__New_Order_Event_Example
{
    public class Order
    {
        public event Action<OrderArgs> OnOrderCreated;

        public int OdrerID { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerPhoneNumber { get; private set; }
        public string CustomerAddress { get; private set; }
        public string CustomerEmail { get; private set; }

        public Order(int OdrerID, string CustomerName, string CustomerPhoneNumber, string CustomerAddress, string CustomerEmail)
        {
            this.OdrerID = OdrerID;
            this.CustomerName = CustomerName;
            this.CustomerPhoneNumber = CustomerPhoneNumber;
            this.CustomerAddress = CustomerAddress;
            this.CustomerEmail = CustomerEmail;
        }

        public void CreateOrder()
        {
            Console.WriteLine("\norder is created, and all subscribed services have been informed.");

            // add order to database or whatever then raise the event
            OnOrderCreated?.Invoke(new OrderArgs(this.OdrerID, this.CustomerName, this.CustomerPhoneNumber, this.CustomerAddress, this.CustomerEmail));
        }

    }
}
