using Market.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Service.Abstraction;

namespace Market.Domain.Interfaces;

public interface IMarketContext : IContext
{
  DbSet<Product> Products { get; }
}
