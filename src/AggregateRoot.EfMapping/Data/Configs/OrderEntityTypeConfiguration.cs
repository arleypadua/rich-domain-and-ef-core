using AggregateRoot.EfMapping.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AggregateRoot.EfMapping.Data.Configs
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.Id)
                .UseHiLo(name: "order-id-sequence");

            builder
                .OwnsOne(o => o.Buyer, r =>
                {
                    r.Property("OrderId")
                        .UseHiLo(name: "order-id-sequence");
                });

            builder
                .OwnsMany(o => o.Items, r =>
                {
                    r.WithOwner().HasForeignKey("OrderId");
                    r.Property<int>("Id");
                    r.HasKey("Id");
                });

            builder
                .Metadata
                .FindNavigation(nameof(Order.Items))
                .SetField("_orderItems");
        }
    }
}