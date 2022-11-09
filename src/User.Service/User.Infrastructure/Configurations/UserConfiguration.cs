using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Abstraction;

namespace User.Infrastructure.Configurations;

public class UserConfiguration : EntityConfiguration<Domain.Domains.User>
{
  public override void Configure(EntityTypeBuilder<Domain.Domains.User> builder)
  {
    builder.Property(e => e.Name).IsRequired();
    builder.Property(e => e.Email).IsRequired();
    builder.Property(e => e.Password).IsRequired();

    base.Configure(builder);
  }
}