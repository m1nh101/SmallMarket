using MediatR;
using Order.Domain.Interfaces;
using Order.Domain.Specifications;
using Specification;

namespace Order.Domain.CQRS.RemoveItemFromOrder;

public sealed class RemoveItemFromOrderRequestHandler
  : IRequestHandler<RemoveItemFromOrderRequest, RemoveItemFromOrderResponse>
{
  private readonly IOrderContext _context;

  public RemoveItemFromOrderRequestHandler(IOrderContext context)
  {
    _context = context;
  }

  public async Task<RemoveItemFromOrderResponse> Handle(RemoveItemFromOrderRequest request, CancellationToken cancellationToken)
  {
    var order = Query.Get(_context.Orders, new CurrentOrderSpecification(request.UserId));

    order.RemoveItem(request.ProductId);

    _context.Orders.Update(order);

    await _context.Commit();

    throw new NotImplementedException();
  }
}