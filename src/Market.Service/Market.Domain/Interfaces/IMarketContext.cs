using Market.Domain.Domains;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain.Interfaces;

public interface IMarketContext
{
  Task Commit();
  DbSet<Product> Products { get; }
}
