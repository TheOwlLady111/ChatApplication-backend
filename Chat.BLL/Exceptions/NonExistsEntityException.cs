namespace Chat.BLL.Exceptions;

public class NonExistsEntityException : Exception
{
    public NonExistsEntityException(string message) : base(message) { }
}