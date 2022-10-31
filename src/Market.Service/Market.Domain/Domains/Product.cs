using Market.Domain.Enums;

namespace Market.Domain.Domains;

public class Product : Entity
{
  private Product() { }

  public Product(string name, string unit, double price,
    Category category)
  {
    Name = name;
    Unit = unit;
    Price = price;
    Category = category;
  }

  public string Name { get; private set; } = string.Empty;
  public string Unit { get; private set; } = string.Empty;
  public double Price { get; private set; } 
  public Category Category { get; private set; }

  public readonly List<Image> _images = new();
  public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

  public readonly List<Stock> _stocks = new();
  public IReadOnlyCollection<Stock> Stocks => _stocks.AsReadOnly();

  public Product WithImages(IEnumerable<Image> images)
  {
    _images.AddRange(images);
    return this;
  }

  public Product WithImages(IEnumerable<string> urls)
  {
    var images = urls.Select(e => new Image(e));
    _images.AddRange(images);
    return this;
  }

  public Product WithStock(IEnumerable<Stock> stocks)
  {
    _stocks.AddRange(stocks);
    return this;
  }
}