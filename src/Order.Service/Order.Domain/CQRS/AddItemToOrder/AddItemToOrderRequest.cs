using MediatR;

namespace Order.Domain.CQRS.AddItemToOrder;

public sealed record AddItemToOrderRequest(
  string UserId,
  int ProductId,
  int Quantity) : IRequest<AddItemToOrderResponse>;