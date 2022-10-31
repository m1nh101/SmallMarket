using Market.Domain.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastucture.Configurations;

public class ProductConfiguration : EntityConfiguration<Product>
{
  public override void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.Property(e => e.Name).HasMaxLength(2000).IsRequired();

    builder.Property(e => e.Unit).HasMaxLength(500).IsRequired();

    base.Configure(builder);
  }
}