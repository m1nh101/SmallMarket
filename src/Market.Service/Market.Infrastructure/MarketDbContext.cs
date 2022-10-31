using Market.Domain.Domains;
using Market.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure;

public class MarketDbContext : DbContext, IMarketContext
{
  public MarketDbContext(DbContextOptions<MarketDbContext> options)
    :base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Product> Products => Set<Product>();

  public Task Commit()
  {
    foreach(var entry in ChangeTracker.Entries<Entity>())
    {
      bool stateChanged = entry.State == EntityState.Added || entry.State == EntityState.Modified;

      if (stateChanged)
        entry.Entity.UpdateAt = DateTime.UtcNow;
    }

    return base.SaveChangesAsync();
  }
}
