using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Domain.Interfaces;

namespace User.Domain.CQRS.Login;

public sealed record LoginRequest(
  string Email,
  string Password) : IRequest<LoginResponse>;

public sealed record LoginResponse;

public sealed class LoginRequestHandler
  : IRequestHandler<LoginRequest, LoginResponse>
{
  private readonly IUserContext _context;

  public LoginRequestHandler(IUserContext context)
  {
    _context = context;
  }

  public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
  {
    var user = await _context.Users
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Email == request.Email, cancellationToken);

    if (user == null)
      throw new NullReferenceException();

    bool result = user.ComparePassword(request.Password);

    if(result)
    {

    }

    throw new NotImplementedException();
  }
}