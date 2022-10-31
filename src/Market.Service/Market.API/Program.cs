using Market.API.Services;
using Market.Domain;
using Market.Domain.CQRS.AddProduct;
using Market.Domain.CQRS.GetProduct;
using Market.Domain.CQRS.GetProductDetail;
using Market.Domain.CQRS.InterGetProduct;
using Market.Domain.Interfaces;
using Market.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketDbContext>(options =>
{
  options.UseNpgsql($"Host=localhost;Port=2345;Database=market_db;Username=postgres;Password=M1ng@2002", x => x.MigrationsAssembly(typeof(MarketDbContext).Assembly.FullName));
});

builder.Services.ConfigureDomain();

builder.Services.AddScoped<IMarketContext, MarketDbContext>();

builder.Services.AddGrpc();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGrpcService<ProductService>();

app.MapGet("/api/products", async ([FromQuery] int? page, IMediator mediator) =>
{
  GetProductRequest request;
  if (page == null)
    request = new GetProductRequest(1);
  else
    request = new GetProductRequest(Convert.ToInt32(page));

  var response = await mediator.Send(request);

  return response;
});

app.MapGet("/api/inter/products/{id:int}", async ([FromRoute] int id, IMediator mediator) =>
{
  var request = new InterGetProductRequest(id);
  var response = await mediator.Send(request);

  return response;
});

app.MapGet("/api/products/{id:int}", async ([FromRoute] int id, IMediator mediator) =>
{
  var request = new GetProductDetailRequest(id);
  var response = await mediator.Send(request);

  return response;
});

app.MapPost("/api/products", async ([FromBody] AddProductRequest request, IMediator mediator) =>
{
  var response = await mediator.Send(request);

  return response;
});

app.Run();