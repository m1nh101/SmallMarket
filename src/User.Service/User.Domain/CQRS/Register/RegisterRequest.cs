using MediatR;
using User.Domain.Domains;

namespace User.Domain.CQRS.Register;

public sealed record RegisterRequest(
  string Name,
  string Email,
  Gender Gender,
  string Password) : IRequest<RegisterResponse>;