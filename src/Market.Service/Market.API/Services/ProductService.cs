using Grpc.Core;
using Market.API.Protobuf;
using Market.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Market.API.Protobuf.Product;

namespace Market.API.Services;

public class ProductService : ProductBase
{
  private readonly IMarketContext _context;

  public ProductService(IMarketContext context)
  {
    _context = context;
  }

  public override async Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
  {
    var product = await _context.Products
      .FirstOrDefaultAsync(e => e.Id == request.ProductId);

    if (product == null)
      return new ProductResponse()
      {
        Exist = false
      };

    return new ProductResponse()
    {
      Exist = true,
      Price = product.Price,
      Quantity = product.Stock
    };
  }
}