using Service.Abstraction;

namespace User.Domain.Domains;

public class Card : Entity
{
  private Card() { }
  
  public Card(string cardNumber, string verificationCode)
  {
    CardNumber = cardNumber;
    VerificationCode = verificationCode;
  }

  public string CardNumber { get; private set; } = string.Empty;
  public string VerificationCode { get; private set; } = string.Empty;

  public int UserId { get; private set; }
  public virtual User? User { get; private set; }
}