using MediatR;
using Order.Domain.Interfaces;
using Order.Domain.Specifications;
using Specification;

namespace Order.Domain.CQRS.GetOrderDetail;

public sealed class GetOrderDetailRequestHandler
  : IRequestHandler<GetOrderDetailRequest, GetOrderDetailResponse>
{
  private readonly IOrderContext _context;

  public GetOrderDetailRequestHandler(IOrderContext context)
  {
    _context = context;
  }

  public Task<GetOrderDetailResponse> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
  {
    var order = Query.Get(_context.Orders, new CurrentOrderSpecification(request.UserId));

    var items = order.Items.Select(e => new ItemInOrder(e.ProductId, e.Id, e.Quantity, e.Price, e.TotalPrice));

    return Task.FromResult(new GetOrderDetailResponse(order.Total, items));
  }
}
