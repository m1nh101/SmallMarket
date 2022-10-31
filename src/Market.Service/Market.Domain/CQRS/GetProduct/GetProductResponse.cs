namespace Market.Domain.CQRS.GetProduct;

public sealed record StockResponse(
  int Quantity,
  string Location);

public sealed record GetProductResponse(
  int Id,
  string Name,
  double Price,
  string Unit,
  IEnumerable<string> Images);