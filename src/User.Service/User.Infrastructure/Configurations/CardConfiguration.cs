using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Abstraction;
using User.Domain.Domains;

namespace User.Infrastructure.Configurations;

public class CardConfiguration : EntityConfiguration<Card>
{
  public override void Configure(EntityTypeBuilder<Card> builder)
  {
    builder.HasOne(e => e.User)
      .WithMany(e => e.Cards)
      .HasForeignKey(e => e.UserId);

    base.Configure(builder);
  }
}