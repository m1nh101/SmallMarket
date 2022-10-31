using Market.Domain.Domains;
using Market.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Abstraction;

namespace Market.Infrastructure;

public class MarketDbContext : AbstractDbContext<MarketDbContext>, IMarketContext
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
}
