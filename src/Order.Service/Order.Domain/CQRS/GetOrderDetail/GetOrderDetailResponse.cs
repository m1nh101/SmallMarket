namespace Order.Domain.CQRS.GetOrderDetail;

public sealed record GetOrderDetailResponse(
  double Total,
  IEnumerable<ItemInOrder> Items);

public sealed record ItemInOrder(
  int ProductId,
  int Id,
  int Quantity,
  double Price,
  double TotalPrice);