using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Domains;
using Service.Abstraction;

namespace Order.Infrastructure.Configurations;

public class CartConfiguration : EntityConfiguration<Cart>
{
  public override void Configure(EntityTypeBuilder<Cart> builder)
  {
    builder.Ignore(e => e.IsCheckout);

    base.Configure(builder);
  }
}