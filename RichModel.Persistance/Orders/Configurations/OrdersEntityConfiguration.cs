using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichModel.Domain.Orders;

namespace RichModel.Persistance.Orders.Configurations
{
    internal sealed class OrdersEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "orders");
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Status).IsRequired();
            builder.HasMany<OrderItem>("Items").WithOne("Order").HasForeignKey("OrderId");
        }
    }
}