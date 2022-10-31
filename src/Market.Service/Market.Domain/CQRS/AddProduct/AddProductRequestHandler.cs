using Market.Domain.Domains;
using Market.Domain.Interfaces;
using MediatR;

namespace Market.Domain.CQRS.AddProduct;

public sealed class AddProductRequestHandler
  : IRequestHandler<AddProductRequest, AddedProductResponse>
{
  private readonly IMarketContext _context;

  public AddProductRequestHandler(IMarketContext context)
  {
    _context = context;
  }

  public async Task<AddedProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
  {
    var stocks = request.Stocks.Select(e => new Stock(e.Quantity, e.Location));

    var product = new Product(request.Name, request.Unit, request.Price, request.Category)
      .WithImages(request.Images)
      .WithStock(stocks);

    await _context.Products.AddAsync(product, cancellationToken);

    await _context.Commit();

    return new AddedProductResponse(product.Id, product.Name, product.Price, product.Category, product.Unit,
      request.Stocks, request.Images);
  }
}