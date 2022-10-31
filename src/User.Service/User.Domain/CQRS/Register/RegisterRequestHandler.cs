using MediatR;
using User.Domain.Exceptions;
using User.Domain.Interfaces;

namespace User.Domain.CQRS.Register;

public sealed class RegisterRequestHandler
  : IRequestHandler<RegisterRequest, RegisterResponse>
{
  private readonly IUserContext _context;

  public RegisterRequestHandler(IUserContext context)
  {
    _context = context;
  }

  public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
  {
    bool isEmailHasBeenUsed = _context.Users.Any(e => e.Email == request.Email);

    if (isEmailHasBeenUsed)
      throw new EmailHasBeenUsedException($"{request.Email} has been used");

    var user = new Domains.User(request.Name, request.Gender, request.Email, request.Password);

    await _context.Users.AddAsync(user, cancellationToken);

    await _context.Commit();

    return new RegisterResponse();
  }
}