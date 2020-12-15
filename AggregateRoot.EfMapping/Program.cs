using AggregateRoot.EfMapping.Data;
using System;
using System.Threading.Tasks;
using AggregateRoot.EfMapping.Domain.OrderAggregate;

namespace AggregateRoot.EfMapping
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var context = new DesignTimeDbContextFactory().CreateDbContext(args);

            Order newOrder = Order.New(
                Buyer.New(Guid.NewGuid().ToString(), "Test Customer"),
                new[]
                {
                    OrderItem.For("product-id", 1, 10),
                });

            await context.Orders.AddAsync(newOrder);
            await context.SaveChangesAsync();

            Order justStoredOrder = await context.Orders.FindAsync(newOrder.Id);
            OrderItem newItem = OrderItem.For("product-id-2", 3, 15);
            justStoredOrder.AddItem(newItem);

            await context.SaveChangesAsync();

            Order justUpdatedOrder = await context.Orders.FindAsync(newOrder.Id);
            justUpdatedOrder.AddItem(newItem);

            await context.SaveChangesAsync();

            Order orderToRemoveItems = await context.Orders.FindAsync(newOrder.Id);
            orderToRemoveItems.RemoveProduct(newItem.ProductId);

            await context.SaveChangesAsync();
        }
    }
}
