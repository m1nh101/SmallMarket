using System.Security.Cryptography;
using System.Text;

namespace User.Domain.Helpers;

public static class PasswordHashing
{
	public static string Hashing(string rawPassword)
	{
		var hashPassword = new StringBuilder();

    SHA1 sha = SHA1.Create();
    var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
    
		foreach(var b in hash)
      hashPassword.Append(b.ToString("x2").ToLower());

		return hashPassword.ToString();
  }
}