namespace Market.Domain.CQRS.InterGetProduct;

public sealed record InterGetProductResponse(
  double Price,
  int Quantity);
