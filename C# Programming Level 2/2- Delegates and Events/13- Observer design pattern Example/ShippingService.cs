namespace _13__New_Order_Event_Example
{
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
}
