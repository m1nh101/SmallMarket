using MediatR;

namespace Market.Domain.CQRS.GetProductDetail;

public sealed record GetProductDetailRequest(
  int Id) : IRequest<GetProductDetailResponse>;