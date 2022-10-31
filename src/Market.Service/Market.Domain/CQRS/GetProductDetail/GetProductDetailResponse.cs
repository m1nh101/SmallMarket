namespace Market.Domain.CQRS.GetProductDetail;

public sealed record GetProductDetailResponse(
  int Id,
  string Name,
  string Unit,
  double Price,
  int Stock,
  IEnumerable<string> Images);