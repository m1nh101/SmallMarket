using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Abstraction;
using User.Domain.Domains;

namespace User.Infrastructure.Configurations;

public class ShippingAddressConfiguration : EntityConfiguration<ShippingAddress>
{
  public override void Configure(EntityTypeBuilder<ShippingAddress> builder)
  {
    builder.HasOne(e => e.User)
      .WithMany(e => e.Addresses)
      .HasForeignKey(e => e.UserId);

    base.Configure(builder);
  }
}