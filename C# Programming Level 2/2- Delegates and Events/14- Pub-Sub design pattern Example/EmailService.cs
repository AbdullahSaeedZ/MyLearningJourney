namespace _13__Observer_design_pattern_Example
{
    internal class EmailService
    {
        public string ServiceName { get; private set; }

        public EmailService(string ServiceName)
        {
            this.ServiceName = ServiceName;
        }

        public void Subscribe(Broker broker)
        {
            broker.Subscribe("OrderCreated", SendOrderDetailsToCustomerEmail);
        }
        public void UnSubscribe(Broker broker)
        {
            broker.UnSubscribe("OrderCreated", SendOrderDetailsToCustomerEmail);
        }

        private void SendOrderDetailsToCustomerEmail(OrderArgs e)
        {
            Console.WriteLine($"\n===== Email Services =====");
            Console.WriteLine($"Email Sent To {e.CustomerEmail}");
            Console.WriteLine($"Order with id={e.OdrerID} has been created and will be shipped to you at {e.CustomerAddress}\n");
        }
    }
}
