namespace Market.Domain.Domains;

public abstract class Entity
{
  public int Id { get; private set; }
  public DateTime UpdateAt { get; set; }
}