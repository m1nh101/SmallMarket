using Market.Domain.Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastucture.Configurations;

public class ImageConfiguration : EntityConfiguration<Image>
{
  public override void Configure(EntityTypeBuilder<Image> builder)
  {
    builder.Property(e => e.Url).IsRequired();

    builder.HasOne(e => e.Product)
      .WithMany(e => e.Images)
      .HasForeignKey(e => e.ProductId);

    base.Configure(builder);
  }
}
