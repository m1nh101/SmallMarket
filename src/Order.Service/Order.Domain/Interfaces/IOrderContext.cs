using Microsoft.EntityFrameworkCore;
using Order.Domain.Domains;
using Service.Abstraction;

namespace Order.Domain.Interfaces;

public interface IOrderContext : IContext
{
  DbSet<Cart> Orders { get; }
}