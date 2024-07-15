using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;

namespace Products.Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(p => p.Stock).IsRequired();

        builder.Property(p => p.CreatedAt).IsRequired();

        builder.Property(p => p.UpdatedAt).IsRequired();
    }
}
