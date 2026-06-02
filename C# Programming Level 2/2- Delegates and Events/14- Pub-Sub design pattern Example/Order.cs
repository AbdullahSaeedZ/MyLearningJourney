namespace _13__Observer_design_pattern_Example
{
    // this is the publisher class, so we composite the broker here to deal with it and link them together
    internal class Order
    {
        private Broker _broker;

        public int OdrerID { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerPhoneNumber { get; private set; }
        public string CustomerAddress { get; private set; }
        public string CustomerEmail { get; private set; }

        public Order(Broker broker, int OdrerID, string CustomerName, string CustomerPhoneNumber, string CustomerAddress, string CustomerEmail)
        {
            this._broker = broker;
            this.OdrerID = OdrerID;
            this.CustomerName = CustomerName;
            this.CustomerPhoneNumber = CustomerPhoneNumber;
            this.CustomerAddress = CustomerAddress;
            this.CustomerEmail = CustomerEmail;

        }

        public void CreateOrder()
        {
            Console.WriteLine("\norder is created, and broker is now notified to do his part and inform subscribed services");

            // add order to database or whatever then raise the event
            _broker.Publish("OrderCreated", new OrderArgs(this.OdrerID, this.CustomerName, this.CustomerPhoneNumber, this.CustomerAddress, this.CustomerEmail));
        }

    }
}
