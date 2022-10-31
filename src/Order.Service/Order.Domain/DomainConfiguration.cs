using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Domain;

public static class DomainConfiguration
{
  public static IServiceCollection ConfigureDomain(this IServiceCollection services)
  {
    services.AddMediatR(typeof(DomainConfiguration).Assembly);

    return services;
  }
}
