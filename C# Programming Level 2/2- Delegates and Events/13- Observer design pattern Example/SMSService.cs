namespace _13__New_Order_Event_Example
{
    public class SMSService
    {
        public string ServiceName { get; private set; }

        public SMSService(string ServiceName)
        {
            this.ServiceName = ServiceName;
        }

        public void Subscribe(Order order)
        {
            order.OnOrderCreated += SendOrderDetailsToCustomerPhone;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= SendOrderDetailsToCustomerPhone;
        }

        private void SendOrderDetailsToCustomerPhone(OrderArgs e)
        {
            Console.WriteLine($"\n===== SMS Services =====");
            Console.WriteLine($"SMS Sent To {e.CustomerPhoneNumber}");
            Console.WriteLine($"Order with id={e.OdrerID} has been created and will be shipped to you at {e.CustomerAddress}\n");
        }
    }
}
