using MediatR;

namespace Order.Domain.CQRS.GetOrderDetail;

public sealed record GetOrderDetailRequest(
  int UserId) : IRequest<GetOrderDetailResponse>;