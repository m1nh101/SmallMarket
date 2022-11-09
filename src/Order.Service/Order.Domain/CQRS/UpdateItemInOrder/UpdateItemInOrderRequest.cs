using MediatR;

namespace Order.Domain.CQRS.UpdateItemInOrder;

public sealed record UpdateItemInOrderRequest(
  int ProductId,
  int Quantity) : IRequest<UpdateItemInOrderResponse>;

public sealed class UpdateItemInOrderRequestHandler
  : IRequestHandler<UpdateItemInOrderRequest, UpdateItemInOrderResponse>
{
  public Task<UpdateItemInOrderResponse> Handle(UpdateItemInOrderRequest request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}