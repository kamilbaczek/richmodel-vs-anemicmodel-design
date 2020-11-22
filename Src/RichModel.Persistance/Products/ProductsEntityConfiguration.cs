using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichModel.Domain.Orders;
using RichModel.Domain.Products;

namespace RichModel.Persistance.Products
{
    internal sealed class ProductsEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey("Id");
            builder.ToTable("Products", "products");
            builder.Property("Name").IsRequired().HasMaxLength(255);
            builder.Property("Price").IsRequired().HasPrecision(15, 2);
            builder.HasMany<OrderItem>("Items")
                .WithOne("Product")
                .HasForeignKey("ProductId");
        }
    }
}