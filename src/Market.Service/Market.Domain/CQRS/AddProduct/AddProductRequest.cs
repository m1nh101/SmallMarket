using Market.Domain.Domains;
using Market.Domain.Enums;
using MediatR;

namespace Market.Domain.CQRS.AddProduct;

public sealed record StockPayload(
  int Quantity,
  string Location);

public sealed record AddProductRequest(
  string Name,
  double Price,
  Category Category,
  string Unit,
  IEnumerable<StockPayload> Stocks,
  IEnumerable<string> Images
  ) : IRequest<AddedProductResponse>;