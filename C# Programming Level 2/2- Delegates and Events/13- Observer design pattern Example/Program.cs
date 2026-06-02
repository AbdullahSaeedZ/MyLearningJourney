namespace _13__New_Order_Event_Example
{

    /*
    this is the observer design pattern, where the subject (the class that will invoke the event) is directly connected to its subscribers, they are also called observers. (tight coupling)
    Observer Pattern(current implementation):

         Order
           |
           +--> ShippingService
           +--> EmailService
           +--> SMSService

        In this model, subscribers register directly with the publisher:

         order.OnOrderCreated += Handler;

    the observer pattern is so similar to the publisher/subscriber patter, but the difference is that pub/sub doesnt maintain a direct reference to the subscribers like in observer pattern,
    instead, the pub/sub has a broker or an intermediary between subject and subscribers, which is much helpful and scaleable for large and distributed systems  

     Order
           |
           v
        Broker
           |
           +--> ShippingService
           +--> EmailService
           +--> SMSService

        publishers and subscribers are completely unaware of each other and communicate only through the intermediary, resulting in a more loosely coupled and scalable design
        
    ================================ next lesson is about converting this observer pattern into pub/sub pattern with a broker class.
    */

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
        }
    }
}
