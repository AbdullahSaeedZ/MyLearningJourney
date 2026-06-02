namespace _13__Observer_design_pattern_Example
{

    /*
        check observer pattern lesson to see difference of both patterns:

        pub/sub :
        Publisher ---> Broker ---> Subscribers

        observer:
        Subject ---> Observers
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            Broker broker = new Broker();

            ShippingService Shipper1 = new ShippingService("Aramex");
            EmailService EmailService1 = new EmailService("Gmail");
            SMSService SMSService = new SMSService("STC");

            Order Order1 = new Order(broker, 1, "Abdullah", "0500000", "KSA-Dammam", "mail@mail.com");

            // now those subscriber are subscribing to the broker list, then the publisher (order) will publish to the broker
            // so publisher and subscribers are indirectly connected, loosely coupled.
            Shipper1.Subscribe(broker);
            EmailService1.Subscribe(broker);
            SMSService.Subscribe(broker);

            // will raise an event to the broker then he will publish to the subscribers stored in the broker dictionary
            Order1.CreateOrder();

        }
    }
}
