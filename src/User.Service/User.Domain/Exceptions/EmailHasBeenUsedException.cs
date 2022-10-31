namespace User.Domain.Exceptions;

public class EmailHasBeenUsedException : Exception
{
	public EmailHasBeenUsedException(string message): base(message)
	{
	}
}