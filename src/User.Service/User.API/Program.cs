using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Domain.CQRS.Login;
using User.Domain.CQRS.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapPost("api/users/auth", async ([FromBody] LoginRequest request, IMediator mediator, HttpContext http) =>
{
  var response = await mediator.Send(request);

  if(response.Token != string.Empty)
  {
    http.Response.Cookies.Append("token", response.Token);
    return Results.Ok();
  }

  return Results.Unauthorized();
});

app.MapPost("api/users/register", async ([FromBody] RegisterRequest request, IMediator mediator) =>
{
  var response = await mediator.Send(request);

  return Results.Ok(response);
});

app.MapPost("api/users/logout", (HttpContext http) =>
{
  http.Response.Cookies.Delete("token");
  return Results.NoContent();
});

app.UseHttpsRedirection();

app.Run();