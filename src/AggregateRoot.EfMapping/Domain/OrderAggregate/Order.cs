using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AggregateRoot.EfMapping.Domain.OrderAggregate
{
    public class Order
    {
        private Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public static Order New(Buyer buyer, OrderItem[] items)
        {
            return new Order
            {
                Id = 0, // transient
                Buyer = buyer,
                _orderItems = items.ToList()
            };
        }

        public void AddItem(OrderItem newItem)
        {
            var existingItem = _orderItems.FirstOrDefault(i => i.ProductId == newItem.ProductId);
            if (existingItem is null)
            {
                _orderItems.Add(newItem);
            }
            else
            {
                existingItem.AddQuantity(newItem.Quantity);
            }
        }

        public void RemoveProduct(string productId)
        {
            var existingItem = _orderItems.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem is null) return;

            _orderItems.Remove(existingItem);
        }

        public int Id { get; private set; }
        public Buyer Buyer { get; private set; }

        private List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> Items => new ReadOnlyCollection<OrderItem>(_orderItems);
    }
}