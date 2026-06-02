namespace _13__Observer_design_pattern_Example
{
    internal class SMSService
    {
        public string ServiceName { get; private set; }

        public SMSService(string ServiceName)
        {
            this.ServiceName = ServiceName;
        }

        public void Subscribe(Broker broker)
        {
            broker.Subscribe("OrderCreated", SendOrderDetailsToCustomerPhone);
        }
        public void UnSubscribe(Broker broker)
        {
            broker.UnSubscribe("OrderCreated", SendOrderDetailsToCustomerPhone);
        }

        private void SendOrderDetailsToCustomerPhone(OrderArgs e)
        {
            Console.WriteLine($"\n===== SMS Services =====");
            Console.WriteLine($"SMS Sent To {e.CustomerPhoneNumber}");
            Console.WriteLine($"Order with id={e.OdrerID} has been created and will be shipped to you at {e.CustomerAddress}\n");
        }
    }
}
