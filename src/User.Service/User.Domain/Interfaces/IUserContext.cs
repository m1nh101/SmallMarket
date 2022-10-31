using Microsoft.EntityFrameworkCore;
using Service.Abstraction;

namespace User.Domain.Interfaces;

public interface IUserContext : IContext
{
  DbSet<Domain.Domains.User> Users { get; }
}