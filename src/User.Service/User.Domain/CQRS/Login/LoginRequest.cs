using MediatR;

namespace User.Domain.CQRS.Login;

public sealed record LoginRequest(
  string Email,
  string Password) : IRequest<LoginResponse>;