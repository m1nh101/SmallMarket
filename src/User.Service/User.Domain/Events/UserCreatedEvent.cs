namespace User.Domain.Events;

public sealed record UserCreatedEvent(
  int UserId);