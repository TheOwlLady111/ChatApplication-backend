namespace Chat.BLL.Exceptions;

public class LoginException : Exception
{
    public LoginException(string message) : base(message){}
}