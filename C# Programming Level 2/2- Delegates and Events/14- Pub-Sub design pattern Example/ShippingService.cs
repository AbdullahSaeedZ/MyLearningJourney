namespace _13__Observer_design_pattern_Example
{
    internal class ShippingService
    {
        public string ShipperName { get; private set; }

        public ShippingService(string ShipperName)
        {
            this.ShipperName = ShipperName;
        }

        public void Subscribe(Broker broker)
        {
            broker.Subscribe("OrderCreated", ShipOrderToCustomer);
        }
        public void UnSubscribe(Broker broker)
        {
            broker.UnSubscribe("OrderCreated", ShipOrderToCustomer);
        }

        private void ShipOrderToCustomer(OrderArgs e)
        {
            Console.WriteLine($"\n===== Shipping Services =====");
            Console.WriteLine($"Order with id={e.OdrerID} has been shipped to customer address = {e.CustomerAddress}\n");
        }
    }
}
