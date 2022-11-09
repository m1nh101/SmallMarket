using Service.Abstraction;

namespace Order.Domain.Domains;

public class Item : Entity
{
  private Item() { }

  public Item(int quantity, int productId)
  {
    Quantity = quantity;
    ProductId = productId;
  }

  public Item(int productId)
  {
    ProductId = productId;
  }

  public Item WithPrice(double price)
  {
    Price = price;
    return this;
  }

  public int Quantity { get; private set; }
  public int ProductId { get; private set; }

  public double Price { get; private set; }
  public double TotalPrice => Price * Quantity;

  public int CartId { get; private set; }
  public virtual Cart? Cart { get; private set; }

  /// <summary>
  /// update item quantity
  /// </summary>
  /// <param name="quantity"></param>
  /// <param name="price"></param>
  /// <returns>return the price value different</returns>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public double Update(int quantity)
  {
    if (quantity <= 0)
      throw new ArgumentOutOfRangeException($"{nameof(quantity)} cannot equal to zero or negative value");

    double newTotalPrice = quantity * Price;
    double oldTotalPrice = Quantity * Price;
    Quantity = quantity;

    return newTotalPrice - oldTotalPrice;
  }
}