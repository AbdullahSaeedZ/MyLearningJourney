namespace _13__New_Order_Event_Example
{
    public class EmailService
    {
        public string ServiceName { get; private set; }

        public EmailService(string ServiceName)
        {
            this.ServiceName = ServiceName;
        }

        public void Subscribe(Order order)
        {
            order.OnOrderCreated += SendOrderDetailsToCustomerEmail;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= SendOrderDetailsToCustomerEmail;
        }

        private void SendOrderDetailsToCustomerEmail(OrderArgs e)
        {
            Console.WriteLine($"\n===== Email Services =====");
            Console.WriteLine($"Email Sent To {e.CustomerEmail}");
            Console.WriteLine($"Order with id={e.OdrerID} has been created and will be shipped to you at {e.CustomerAddress}\n");
        }
    }
}
