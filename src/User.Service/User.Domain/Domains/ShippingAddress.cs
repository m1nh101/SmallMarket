using Service.Abstraction;

namespace User.Domain.Domains;

public enum AddressType
{
  Office = 0,
  Home = 1
}

public class ShippingAddress : Entity
{
  private ShippingAddress() { }

  public ShippingAddress(string address, AddressType type)
  {
    Address = address;
    AddressType = type;
  }

  public AddressType AddressType { get; private set; }

  public string Address { get; private set; } = string.Empty;

  public int UserId { get; private set; }
  public virtual User? User { get; private set; }
}