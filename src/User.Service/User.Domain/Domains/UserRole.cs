namespace User.Domain.Domains;

public class UserRole
{
  public int RoleId { get; private set; }
  public int UserId { get; private set; }
  public virtual User User { get; private set; } = default!;
  public virtual Role Role { get; private set; } = default!;
}