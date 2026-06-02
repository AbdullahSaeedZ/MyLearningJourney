namespace _13__Observer_design_pattern_Example
{
    internal class OrderArgs : EventArgs
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
}
