using Service.Abstraction;
using User.Domain.Helpers;

namespace User.Domain.Domains;

public enum Gender
{
  Male = 0,
  Female = 1
}

public class User : Entity
{
  private string _password = string.Empty;

  private User() { }

  public User(string name, Gender gender, string email, string password)
  {
    Name = name;
    Gender = gender;
    Email = email;
    Password = password;
  }

  public string Name { get; private set; } = string.Empty;
  public Gender Gender { get; private set; }
  public string Email { get; private set; } = string.Empty;

  public string Password
  {
    get => _password;
    set => _password = PasswordHashing.Hashing(value);
  }

  private readonly List<ShippingAddress> _addresses = new();
  public IReadOnlyCollection<ShippingAddress> Addresses => _addresses.AsReadOnly();

  private readonly List<Card> _cards = new();
  public IReadOnlyCollection<Card> Cards => _cards.AsReadOnly();

  public bool ComparePassword(string password)
  {
    var hashPassword = PasswordHashing.Hashing(password);
    return hashPassword.Equals(Password);
  }

  public void AddShippingAddress(string address, AddressType type)
  {
    var shippingAddress = new ShippingAddress(address, type);
    _addresses.Add(shippingAddress);
  }

  public void DeleteShippingAddress(int id)
  {
    var shippingAddress = _addresses.FirstOrDefault(e => e.Id == id);

    if (shippingAddress == null)
      throw new NullReferenceException();

    _addresses.Remove(shippingAddress);
  }
}
