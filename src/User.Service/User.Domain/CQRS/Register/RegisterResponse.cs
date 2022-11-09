namespace User.Domain.CQRS.Register;

public sealed record RegisterResponse(
  int Id,
  string Email,
  string Name);
