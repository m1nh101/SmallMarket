using gRPC.Client;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Domains;
using Order.Domain.Interfaces;

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
    var order = await _context.Orders
      .Include(e => e.Items)
      .Where(e => !e.IsCheckout)
      .FirstOrDefaultAsync(e => e.UserId == request.UserId, cancellationToken);

    var product = await ProductgRPCClient.CheckingProduct(request.ProductId);

    if (!product.Exist)
      throw new NullReferenceException($"{nameof(product)} is null");

    if (order == null)
      throw new NullReferenceException($"{nameof(order)} is null");

    var item = new Item(product.Quantity, request.ProductId)
      .WithPrice(product.Price);

    order.AddItem(item);

    _context.Orders.Update(order);

    await _context.Commit();

    return new AddItemToOrderResponse();
  }
}