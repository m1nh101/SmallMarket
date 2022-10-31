using Microsoft.EntityFrameworkCore;
using Service.Abstraction;
using User.Domain.Interfaces;

namespace User.Infrastructure;

public class UserDbContext : AbstractDbContext<UserDbContext>, IUserContext
{
  public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Domain.Domains.User> Users => Set<Domain.Domains.User>();
}