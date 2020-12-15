using System;

namespace AggregateRoot.EfMapping.Domain.OrderAggregate
{
    public class Buyer
    {
        private Buyer() { }

        public static Buyer New(string customerId, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return new Buyer
            {
                CustomerId = customerId,
                Name = name
            };
        }

        public string CustomerId { get; private set; }
        public string Name { get; private set; }
    }
}