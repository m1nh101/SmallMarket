using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Service.Abstraction;

public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
  where TEntity : Entity
{
  public virtual void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.HasKey(e => e.Id);

    builder.Property(e => e.Id).ValueGeneratedOnAdd();
  }
}
