namespace Market.Domain.Domains;

public class Image : Entity
{
  private Image() { }

  public Image(string url)
  {
    Url = url;
  }

  public string Url { get; private set; } = string.Empty;

  public int ProductId { get; private set; }
  public virtual Product? Product { get; private set; }
}
