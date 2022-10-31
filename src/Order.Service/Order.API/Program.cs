using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Domain.CQRS.AddItemToOrder;
using Order.Domain.Interfaces;
using Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(options =>
{
  options.UseNpgsql($"Host=localhost;Port=2345;Database=order_db;Username=postgres;Password=M1ng@2002",
    x => x.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName));
});

builder.Services.ConfigureDomain();

builder.Services.AddScoped<IOrderContext, OrderDbContext>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("api/orders", async ([FromBody] AddItemToOrderRequest request, IMediator mediator) =>
{
  var response = await mediator.Send(request);
  return response;
});

app.Run();