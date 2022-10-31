namespace Service.Abstraction;

public abstract class Entity
{
  public int Id { get; private set; }
  public DateTime UpdatedAt { get; set; }
}