using Market.Domain.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastucture.Configurations;

public class StockConfiguration : EntityConfiguration<Stock>
{
  public override void Configure(EntityTypeBuilder<Stock> builder)
  {
    builder.Property(e => e.Location).IsRequired();

    builder.HasOne(e => e.Product)
      .WithMany(e => e.Stocks)
      .HasForeignKey(e => e.ProductId);

    base.Configure(builder);
  }
}