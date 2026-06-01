namespace _13__New_Order_Event_Example
{
    public class OrderArgs : EventArgs
    {
        public int OdrerID { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerPhoneNumber { get; private set; }
        public string CustomerAddress { get; private set; }
        public string CustomerEmail { get; private set; }

        public OrderArgs(int OdrerID, string CustomerName, string CustomerPhoneNumber, string CustomerAddress, string CustomerEmail)
        {
            this.OdrerID = OdrerID;
            this.CustomerName = CustomerName;
            this.CustomerPhoneNumber = CustomerPhoneNumber;
            this.CustomerAddress = CustomerAddress;
            this.CustomerEmail = CustomerEmail;
        }
    }
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

    public class ShippingService
    {
        public string ShipperName { get; private set; }

        public ShippingService(string ShipperName)
        {
            this.ShipperName = ShipperName;
        }

        public void Subscribe(Order order)
        {
            order.OnOrderCreated += ShipOrderToCustomer;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= ShipOrderToCustomer;
        }

        private void ShipOrderToCustomer(OrderArgs e)
        {
            Console.WriteLine($"\n===== Shipping Services =====");
            Console.WriteLine($"Order with id={e.OdrerID} has been shipped to customer address = {e.CustomerAddress}\n");
        }
    }
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


    internal class Program
    {
        static void Main(string[] args)
        {
            ShippingService Shipper1 = new ShippingService("Aramex");
            EmailService EmailService1 = new EmailService("Gmail");
            SMSService SMSService = new SMSService("STC");

            Order Order1 = new Order(1, "Abdullah", "0500000", "KSA-Dammam", "mail@mail.com");

            
            Shipper1.Subscribe(Order1);
            EmailService1.Subscribe(Order1);
            SMSService.Subscribe(Order1);

            Order1.CreateOrder();

            // another solution is to have the services inside the order object, and they get invoked once order is created, but the downside is that when we need to 
            // change the shipper or any services and do modifications, then we have to edit the order class code, which is a tightly coupled design and will make it a bit messy
            // so better to make the objects loosely coupled to have more freedom and ease of modifying the code


            // finally, this code design is called publisher subscriber design pattern (Pub/Sub)

        }
    }

        /*
        This implementation follows the Observer Pattern using C# events.
        The Order object acts as the publisher (subject), while the services
        act as observers (subscribers) that are notified when an order is created.

        Observer Pattern (current implementation):

         Order
           |
           +--> ShippingService
           +--> EmailService
           +--> SMSService

        In this model, subscribers register directly with the publisher:

         order.OnOrderCreated += Handler;

        Although this is often described as Publish-Subscribe, it is technically
        an Observer Pattern implementation because the publisher maintains direct
        references to its subscribers through the event's invocation list.

        A true Publish-Subscribe architecture introduces an intermediary such as
        an event bus or message broker:

         Order
           |
           v
        Event Bus
           |
           +--> ShippingService
           +--> EmailService
           +--> SMSService

        In that model, publishers and subscribers are completely unaware of each
        other and communicate only through the intermediary, resulting in a more
        loosely coupled and scalable design.
        */

}
