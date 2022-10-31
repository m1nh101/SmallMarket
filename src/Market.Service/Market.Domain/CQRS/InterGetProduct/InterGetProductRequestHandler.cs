using Market.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain.CQRS.InterGetProduct;

public sealed class InterGetProductRequestHandler
  : IRequestHandler<InterGetProductRequest, InterGetProductResponse>
{
  private readonly IMarketContext _context;

  public InterGetProductRequestHandler(IMarketContext context)
  {
    _context = context;
  }

  public async Task<InterGetProductResponse> Handle(InterGetProductRequest request, CancellationToken cancellationToken)
  {
    var product = await _context.Products
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Id == request.ProductId, cancellationToken);

    if (product == null)
      throw new NullReferenceException($"{nameof(product)} cannot not be null");

    return new InterGetProductResponse(product.Price, product.Stock);
  }
}
