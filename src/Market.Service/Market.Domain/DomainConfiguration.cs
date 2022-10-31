using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Market.Domain;

public static class DomainConfiguration
{
  public static IServiceCollection ConfigureDomain(this IServiceCollection services)
  {
    services.AddMediatR(Assembly.GetExecutingAssembly());

    return services;
  }
}