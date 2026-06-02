namespace _13__Observer_design_pattern_Example
{
    // this a simple implementation, can add more validations and adding constants for the keys and much more.
    internal class Broker
    {
        // this dictionaty will have each key representing a subject with values representing subscribers
        private Dictionary<string, List<Action<OrderArgs>>> _subscribersList;

        public Broker()
        {
            _subscribersList = new Dictionary<string, List<Action<OrderArgs>>>();
        }

        // this method will be used to store the event handler of the other services as value under the needed key
        // key will be subject as order, and event handler will be subscriber like email sending method to be invoked
        public void Subscribe(string subject, Action<OrderArgs> handler)
        {
            if (!_subscribersList.ContainsKey(subject))
            {
                _subscribersList[subject] = new List<Action<OrderArgs>>();
            }

            _subscribersList[subject].Add(handler);
        }
        public void UnSubscribe(string subject, Action<OrderArgs> handler)
        {
            if (!_subscribersList.ContainsKey(subject)) return;

            _subscribersList[subject].Remove(handler);
        }

        // this mehod will be used by the publisher to inform the broker to raise event to all subscribers stored under the needed subject (key in dictionary)
        public void Publish(string subject, OrderArgs data)
        {
            if (_subscribersList.ContainsKey(subject))
            {
                foreach (Action<OrderArgs> handler in _subscribersList[subject])
                {
                    handler?.Invoke(data);
                }
            }
        }
    }
}
