using gRPC.Client;
using MediatR;
using Order.Domain.Domains;
using Order.Domain.Interfaces;
using Order.Domain.Specifications;
using Specification;

namespace Order.Domain.CQRS.AddItemToOrder;

public sealed class AddItemToOrderRequestHandler
  : IRequestHandler<AddItemToOrderRequest, AddItemToOrderResponse>
{
  private readonly IOrderContext _context;

  public AddItemToOrderRequestHandler(IOrderContext context)
  {
    _context = context;
  }

  public async Task<AddItemToOrderResponse> Handle(AddItemToOrderRequest request, CancellationToken cancellationToken)
  {
    var order = Query.Get(_context.Orders, new CurrentOrderSpecification(request.UserId));

    var product = await ProductgRPCClient.CheckingProduct(request.ProductId);

    if (!product.Exist)
      throw new NullReferenceException($"{nameof(product)} is null");

    var item = new Item(product.Quantity, request.ProductId)
      .WithPrice(product.Price);

    order.AddItem(item);

    _context.Orders.Update(order);

    await _context.Commit();

    return new AddItemToOrderResponse();
  }
}