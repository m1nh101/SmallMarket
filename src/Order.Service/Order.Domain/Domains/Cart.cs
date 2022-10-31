using Service.Abstraction;

namespace Order.Domain.Domains;

public enum OrderState
{
  OnProcessing = 0,
  HasCheckout = 1
}

public class Cart : Entity
{
  private Cart() { }

  public Cart(string userId)
  {
    UserId = userId;
  }

  public string UserId { get; private set; } = string.Empty;

  public double Total { get; private set; }

  public readonly List<Item> _items = new();
  public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

  public OrderState Status { get; private set; }
  public bool IsCheckout => Status == OrderState.HasCheckout;

  public double AddItem(Item item)
  {
    var cartItem = _items.FirstOrDefault(e => e.ProductId == item.ProductId);

    if(cartItem == null)
    {
      _items.Add(item);
      Total += item.TotalPrice;
    } else
      Total += cartItem.Update(item.Quantity, item.Price);

    return Total;
  }

  public double RemoveItem(Item item)
  {
    var cartItem = _items.FirstOrDefault(e => e.ProductId == item.ProductId);

    if (cartItem == null)
      throw new NullReferenceException($"{nameof(item)} cannot be null");

    Total -= item.TotalPrice;

    _items.Remove(cartItem);

    return Total;
  }
}