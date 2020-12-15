namespace AggregateRoot.EfMapping.Domain.OrderAggregate
{
    public class OrderItem
    {
        private OrderItem() { }

        internal static OrderItem For(string productId, int quantity, decimal unitPrice)
        {
            return new OrderItem
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice
            };
        }

        public string ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public void AddQuantity(int amountToAdd)
        {
            if(amountToAdd > 0)
                Quantity += amountToAdd;
        }
    }
}