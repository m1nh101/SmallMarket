using gRPC.Client.ProductClient;
using Grpc.Net.Client;

namespace gRPC.Client;

public static class ProductgRPCClient
{
  public static async Task<ProductResponse> CheckingProduct(int id)
  {
    using var channel = GrpcChannel.ForAddress("https://localhost:7265");
    var client = new Product.ProductClient(channel);
    var request = new ProductRequest { ProductId = id };
    var reply = await client.GetProductAsync(request);
    return reply;
  }
}