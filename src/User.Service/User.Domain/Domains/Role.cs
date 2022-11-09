using Service.Abstraction;

namespace User.Domain.Domains;

public class Role : Entity
{
  private Role() { }

  public Role(string name)
  {
    Name = name;
  }

  public string Name { get; private set; } = string.Empty;

  public virtual ICollection<UserRole> UserRoles { get; private set; } = default!;
  public virtual ICollection<User> Users { get; private set; } = default!;
}