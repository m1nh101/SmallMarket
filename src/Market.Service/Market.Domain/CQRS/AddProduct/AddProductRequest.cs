using Market.Domain.Domains;
using Market.Domain.Enums;
using MediatR;

namespace Market.Domain.CQRS.AddProduct;

public sealed record AddProductRequest(
  string Name,
  double Price,
  Category Category,
  string Unit,
  int Stock,
  IEnumerable<string> Images
  ) : IRequest<AddedProductResponse>;