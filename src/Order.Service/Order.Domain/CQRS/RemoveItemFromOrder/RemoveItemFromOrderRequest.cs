using MediatR;

namespace Order.Domain.CQRS.RemoveItemFromOrder;

public sealed record RemoveItemFromOrderRequest(
  int UserId,
  int ProductId) : IRequest<RemoveItemFromOrderResponse>;