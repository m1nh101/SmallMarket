using MediatR;

namespace Order.Domain.CQRS.AddItemToOrder;

public sealed record AddItemToOrderRequest(
  int UserId,
  int ProductId,
  int Quantity) : IRequest<AddItemToOrderResponse>;