using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace User.Domain.Helpers;

public class JwtHelper
{
  private readonly IConfiguration _configuration;

  public JwtHelper(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  private ClaimsIdentity? _claims;

  public JwtHelper GetClaimsIdentity(Domains.User user)
  {
    var claims = new Claim[]
    {
      new(ClaimTypes.Name, user.Name),
      new(ClaimTypes.Email, user.Email),
      new(ClaimTypes.NameIdentifier, user.Id.ToString())
    }.Union(user.Roles.Select(e => new Claim(ClaimTypes.Role, e.Name)));

    _claims = new ClaimsIdentity(claims);

    return this;
  }

  public string GenerateJwtToken()
  {
    if (_claims == null)
      throw new NullReferenceException();

    var tokenHandler = new JwtSecurityTokenHandler();
    var secretTokenKey = Encoding.UTF8.GetBytes(_configuration["JWT_SECRET_KEY"]);
    var tokenEffectiveDays = Convert.ToInt32(_configuration["JWT_EFFECTIVE_DAYS"]);
    var symmetricKey = new SymmetricSecurityKey(secretTokenKey);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = _claims,
      Expires = DateTime.UtcNow.AddDays(tokenEffectiveDays),
      SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}