using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Domains;
using Service.Abstraction;

namespace Order.Infrastructure.Configurations;

public class ItemConfiguration : EntityConfiguration<Item>
{
  public override void Configure(EntityTypeBuilder<Item> builder)
  {
    builder.Ignore(e => e.Price);
    builder.Ignore(e => e.TotalPrice);

    builder.Property(e => e.ProductId).IsRequired();

    builder.HasOne(e => e.Cart)
      .WithMany(e => e.Items)
      .HasForeignKey(e => e.CartId);

    base.Configure(builder);
  }
}