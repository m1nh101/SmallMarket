using Market.Domain.Enums;

namespace Market.Domain.CQRS.AddProduct;

public sealed record AddedProductResponse(
  int Id,
  string Name,
  double Price,
  Category Category,
  string Unit,
  int Stock,
  IEnumerable<string> Images);