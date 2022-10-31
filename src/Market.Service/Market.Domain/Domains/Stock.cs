namespace Market.Domain.Domains;

public class Stock : Entity
{
  private Stock() { }

  public Stock(int quantity, string location)
  {
    Quantity = quantity;
    Location = location;
  }

  public int Quantity { get; private set; }
  public string Location { get; private set; } = string.Empty;
  //public bool IsSoldOut { get; private set; }

  public int ProductId { get; private set; }
  public virtual Product? Product { get; private set; }
}