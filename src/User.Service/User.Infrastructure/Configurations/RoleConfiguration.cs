using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Abstraction;
using User.Domain.Domains;

namespace User.Infrastructure.Configurations;

public class RoleConfiguration : EntityConfiguration<Role>
{
  public override void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("Roles");

    builder.HasMany(e => e.Users)
      .WithMany(e => e.Roles)
      .UsingEntity<UserRole>(j =>
        j.HasOne(d => d.User)
          .WithMany(d => d.UserRoles)
          .HasForeignKey(d => d.UserId),
        j => j.HasOne(d => d.Role)
              .WithMany(d => d.UserRoles)
              .HasForeignKey(d => d.RoleId),
        j =>
        {
          j.ToTable("UserRoles");
          j.HasKey(e => new { e.UserId, e.RoleId });
        });

    base.Configure(builder);
  }
}