using Microsoft.EntityFrameworkCore;
using Order.Domain.Domains;
using Order.Domain.Interfaces;
using Service.Abstraction;

namespace Order.Infrastructure;

public class OrderDbContext : AbstractDbContext<OrderDbContext>, IOrderContext
{
  public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Cart> Orders => Set<Cart>();
}