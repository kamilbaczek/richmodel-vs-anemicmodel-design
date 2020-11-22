using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichModel.Domain.Orders;

namespace RichModel.Persistance.Orders.Configurations
{
    internal sealed class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey("OrderId", "ProductId");
            builder.ToTable("Items", "orders");
        }
    }
}