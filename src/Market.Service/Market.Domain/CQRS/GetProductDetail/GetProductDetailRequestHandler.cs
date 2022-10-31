using Market.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain.CQRS.GetProductDetail;

public sealed class GetProductDetailRequestHandler
  : IRequestHandler<GetProductDetailRequest, GetProductDetailResponse>
{
  private readonly IMarketContext _context;

  public GetProductDetailRequestHandler(IMarketContext context)
  {
    _context = context;
  }

  public async Task<GetProductDetailResponse> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
  {
    var response = await _context.Products
      .Include(e => e.Images)
      .Select(e => new GetProductDetailResponse(e.Id, e.Name, e.Unit, e.Price, e.Images.Select(d => d.Url)))
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

    if (response == null)
      throw new NullReferenceException();

    return response;
  }
}