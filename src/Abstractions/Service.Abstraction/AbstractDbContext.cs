using Microsoft.EntityFrameworkCore;

namespace Service.Abstraction;

public abstract class AbstractDbContext<TContext> : DbContext, IContext
  where TContext : DbContext
{
  public AbstractDbContext(DbContextOptions<TContext> options): base(options)
  {
  }

  public virtual Task Commit()
  {
    foreach(var entry in ChangeTracker.Entries<Entity>())
    {
      bool isAttached = entry.State == EntityState.Modified || entry.State == EntityState.Added;

      if(isAttached)
        entry.Entity.UpdatedAt = DateTime.UtcNow;
    }

    return base.SaveChangesAsync(default);
  }
}