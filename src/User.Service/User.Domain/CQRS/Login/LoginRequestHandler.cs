using MediatR;
using Specification;
using User.Domain.Helpers;
using User.Domain.Interfaces;
using User.Domain.Specification;

namespace User.Domain.CQRS.Login;

public sealed class LoginRequestHandler
  : IRequestHandler<LoginRequest, LoginResponse>
{
  private readonly IUserContext _context;
  private readonly JwtHelper _jwtHelper;

  public LoginRequestHandler(IUserContext context, JwtHelper jwtHelper)
  {
    _context = context;
    _jwtHelper = jwtHelper;
  }

  public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
  {
    var user = Query.Get(_context.Users, new FindUserSpecification(request.Email));

    bool result = user.ComparePassword(request.Password);

    if(result)
    {
      string token = _jwtHelper
        .GetClaimsIdentity(user)
        .GenerateJwtToken();

      return Task.FromResult(new LoginResponse(token));
    }

    return Task.FromResult(new LoginResponse(string.Empty));
  }
}