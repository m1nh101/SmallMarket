using MediatR;

namespace Market.Domain.CQRS.GetProduct;

public sealed record GetProductRequest(
  int PageIndex) : IRequest<IEnumerable<GetProductResponse>>;