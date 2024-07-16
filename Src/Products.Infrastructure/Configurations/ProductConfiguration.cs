using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;
using Products.Domain.Products.ValueObjects;

namespace Products.Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(product => product.Name, nameBuilder =>
        {
            nameBuilder.WithOwner();

            nameBuilder.Property(name => name.Value)
                .HasColumnName(nameof(Product.Name))
                .HasMaxLength(Name.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(product => product.Description, descriptionBuilder =>
        {
            descriptionBuilder.WithOwner();

            descriptionBuilder.Property(description => description.Value)
                .HasColumnName(nameof(Product.Description))
                .HasMaxLength(Description.MaxLenght)
                .IsRequired();
        });

        builder.OwnsOne(product => product.Price, priceBuilder =>
        {
            priceBuilder.WithOwner();

            priceBuilder.Property(price => price.Value)
                .HasColumnName(nameof(Product.Price))
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        });

        builder.OwnsOne(product => product.Stock, stockBuilder =>
        {
            stockBuilder.WithOwner();

            stockBuilder.Property(stock => stock.Value)
                .HasColumnName(nameof(Product.Stock))
                .IsRequired();
        });

        builder.Property(product => product.CreatedAt).IsRequired();

        builder.Property(product => product.UpdatedAt);
    }
}
