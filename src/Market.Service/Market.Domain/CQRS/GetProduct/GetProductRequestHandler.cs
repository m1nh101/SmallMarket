using Market.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain.CQRS.GetProduct;

public sealed class GetProductRequestHandler
  : IRequestHandler<GetProductRequest, IEnumerable<GetProductResponse>>
{
  private readonly IMarketContext _context;
  private static readonly int ItemPerPage = 20;

  public GetProductRequestHandler(IMarketContext context)
  {
    _context = context;
  }

  public Task<IEnumerable<GetProductResponse>> Handle(GetProductRequest request, CancellationToken cancellationToken)
  {
    int currentPageIndex = 1;

    if (request.PageIndex >= 1)
      currentPageIndex = request.PageIndex - 1;

    var skipRecord = currentPageIndex * ItemPerPage;

    var query = _context.Products
      .Include(e => e.Images.Take(1))
      .Skip(skipRecord)
      .Take(ItemPerPage)
      .Select(e => new GetProductResponse(
        e.Id, e.Name, e.Price, e.Unit, e.Stock,
        e.Images.Select(e => e.Url))
      ).AsNoTracking()
      .AsEnumerable();

    return Task.FromResult(query);
  }
}
