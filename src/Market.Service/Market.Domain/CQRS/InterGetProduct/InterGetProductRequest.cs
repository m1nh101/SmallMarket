using MediatR;

namespace Market.Domain.CQRS.InterGetProduct;

public sealed record InterGetProductRequest(
  int ProductId) : IRequest<InterGetProductResponse>;